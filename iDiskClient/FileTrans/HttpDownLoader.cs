using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace iDiskClient
{
    public class HttpDownLoader : DownLoader
    {
        public HttpDownLoader(string url, string fileName, string localFileName, int threadCount)
            :base(url, fileName, localFileName, threadCount)
    {

    }
        public override void BeginDownLoad()
        {
            if (!initialized)
                throw new Exception("无法读取文件，请检查网络或是否有此文件的读取权限！");
            begin = true;
            InvokeDownLoadBegin(this);
            threads = new Thread[count];
            for (int i = 0; i < count; i++)
            {
                threads[i] = new Thread(DownLoad);
                threads[i].Start(i.ToString());
            }
            //合并文件
            Thread mThread = new Thread(Merge);
            mThread.Start();
        }
        /// <summary>
        /// 下载线程调用
        /// </summary>
        /// <param name="obj"></param>
        private void DownLoad(object obj)
        {
            int index = int.Parse(obj.ToString());
            try
            {
                InvokePartBegin(this);
                using (FileStream fs = new FileStream(subFileNames[index], FileMode.Create))
                {
                    HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(url);
                    wr.AddRange(subFileStart[index], subFileEnd[index]);
                    Stream ns = wr.GetResponse().GetResponseStream();
                    byte[] buff = new byte[1024];
                    int len = 0;    //成功下载的字节数
                    len = ns.Read(buff, 0, 1024);
                    while (len > 0)
                    {
                        AddCurrentSize(len);    //将新下载的量添加到currentSize中
                        InvokeDownLoading(this);    //激发正在下载的事件
                        fs.Write(buff, 0, len);
                        len = ns.Read(buff, 0, 1024);
                    }
                    ns.Close();
                    wr.Abort();
                }
                threadEndFlag[index] = true;
                InvokePartEnded(this);
            }
            catch (Exception ex)
            {
                throw new Exception("线程"+ index + ":\r\n" + ex.Message);
            }
        }

        #region 合并文件
        /// <summary>
        /// 合并子线程下载的文件
        /// </summary>
        private void Merge()
        {
            FileStream fs = new FileStream(fileName + ".temp", FileMode.Create);
            try
            {
                int jd = 0;
                while (jd < count)
                {
                    //按顺将每一部份进行合并
                    for (int i = jd; i < count; i++)//有未结束线程，等待 
                    {
                        if (!threadEndFlag[i])
                            break;
                        try
                        {
                            WriteFile(fs, subFileNames[i]); //将子文件写入主文件
                        }
                        catch (Exception er)
                        {
                            //终止所有正在执行的线程
                            foreach (var t in threads)
                            {
                                if (t.IsAlive)
                                    t.Abort();
                            }
                            throw er;
                        }
                        ++jd;
                    }
                    Thread.Sleep(100);
                }
                fs.Close();
                if (File.Exists(fileName))
                    File.Delete(fileName);
                File.Move(fileName + ".temp", fileName);
                finished = true;
                InvokeDownLoadFinished(this);
            }
            catch (Exception ex)
            {
                fs.Close();
                //删除已下载的文件
                if (File.Exists(fileName))
                    File.Delete(fileName);
                if (File.Exists(fileName + ".temp"))
                    File.Delete(fileName + ".temp");
                foreach (var f in subFileNames)
                {
                    if (File.Exists(f))
                        File.Delete(f);
                }
                throw new Exception("合并文件过程中出现异常：\r\n" + ex.Message);
            }
        }
        private void WriteFile(FileStream fs, string fileName)
        {
            try
            {
                FileInfo file = new FileInfo(fileName);
                FileStream srcFile = file.OpenRead();
                Byte[] bytes = new Byte[1024];
                int len = srcFile.Read(bytes, 0, 1024);
                while (len > 0)
                {
                    fs.Write(bytes, 0, len);
                    len = srcFile.Read(bytes, 0, 512);
                }
                srcFile.Close();
                File.Delete(fileName);
            }
            catch
            {
                throw;
            }
        }  
        #endregion

        /// <summary>
        /// 初始化下载文件大小及各线程的下载文件量
        /// </summary>
        protected override void Init()
        {
            try
            {
                HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(url);
                fileSize = wr.GetResponse().ContentLength;  //取得目标文件的长度
                wr.Abort();

                //计算每个线程应该接收文件的大小  
                int avgSize = (int)fileSize / count;            //平均分配  
                int lastSzie = avgSize + (int)fileSize % count; //剩余部分由最后一个线程完成  

                for (int i = 0; i < count; i++)
                {
                    if (i < count - 1)
                    {
                        subFileStart[i] = avgSize * i;  //接收文件的起始位置
                        subFileEnd[i] = subFileStart[i] + avgSize - 1;    //接收文件的终点位置
                    }
                    else
                    {
                        subFileStart[i] = avgSize * i;  //接收文件的起始位置
                        subFileEnd[i] = subFileStart[i] + lastSzie - 1;   //接收文件的终点位置
                    }
                }
               initialized = true;
            }
            catch (Exception ex)
            {
                initialized = false;
                throw ex;
            }
        }
    }
}
