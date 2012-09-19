using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iDiskClient;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace iDiskClient
{
    class TcpUpLoader:UpLoader
    {
        string ip = string.Empty;
        int port = 0;
        string dirtory = "";
        FileServices.File file;
        FileServices.User user;
        TcpClient client;
        Thread thread;
        ListBox listBox;
        public TcpUpLoader(string url, string localFileName, FileServices.File file, FileServices.User user, ListBox list)
            : base(url, localFileName)
        {
            listBox = list;
            this.file = file;
            this.user = user;
            string[] tem = url.Split(new char[]{':','/'});
            ip = tem[0];
            port = int.Parse(tem[1]);
            dirtory = tem[2];
        }
        public override void BeginUpLoad()
        {
            //listBox.Items.Add("启动...");
            thread = new Thread(UpLaod2);
            thread.Start();
           
        }

        private void UpLaod2()
        {
            try
            {
                client = new TcpClient(ip, port);
                FileInfo fino = new FileInfo(localFileName);
                fileSize = fino.Length;
                FileStream fs = new FileStream(localFileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                BinaryWriter bw = new BinaryWriter(client.GetStream());
                bw.Write("upload");
                bw.Write(file._fid);
                bw.Write(user._uloginname);
                bw.Write(user._upassword);
                byte[] buff = new byte[1024];
                int count;
                begin = true;
                InvokeUpLoadBegin(this);//触发上传开始事件
                while ((count = br.Read(buff, 0, 1024)) != 0)
                {
                    currentSize += count;
                    InvokeUpLoading(this);//触发下载进行中事件
                    client.Client.Send(buff, count, SocketFlags.None);
                }
                client.Client.Shutdown(SocketShutdown.Both);
                br.Close();
                bw.Close();
                fs.Close();
                finished = true; 
                InvokeUpLoadFinished(this);//触发下载完成事件
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n可能是由于网络故障或用户非法!","上传失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new FileServices.FileServiceClient().DeleteFile(file,user);
            }
        }

        private void UpLoad()
        {
            client = new TcpClient(ip, port); listBox.Items.Add("连接...");
            FileInfo fileInof = new FileInfo(localFileName);
            fileSize = fileInof.Length;//读取文件大小
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());
            sw.WriteLine("userclient"); listBox.Items.Add("发送：userclient");
            string msg = sr.ReadLine(); listBox.Items.Add("接收：" + msg);
            if (msg != "ok")    
            {
                sr.Close();
                sw.Close();
                client.Close();
                throw new Exception("连接文件服务器失败！");
            }
            sw.WriteLine("user=" + user._uloginname); listBox.Items.Add("发送：user=" + user._uloginname);
            sw.WriteLine("pass=" + user._upassword); listBox.Items.Add("发送：pass=" + user._upassword);
            msg = sr.ReadLine(); listBox.Items.Add("接收：" + msg);
            if (msg == "invalid user")
            {
                sw.Close();
                sr.Close();
                client.Close();
                throw new Exception("用户验证失败！");
            }
            if (msg != "success")
            {
                sw.Close();
                sr.Close();
                client.Close();
                throw new Exception("用户验证失败！");
            }
            sw.WriteLine("upload");
            sw.WriteLine("id=" + file._fid);
            sw.WriteLine("size=" + fileSize);
            msg = sr.ReadLine();
            if (msg != "begin")
            {
                sw.Close();
                sr.Close();
                client.Close();
                throw new Exception("用户验证失败！");
            }
            //开始传输文件
            FileStream stream = fileInof.OpenRead();
            begin = true;
            new Thread(InvokeUpLoadBegin).Start(this);//激发上传开始事件
            byte[] buff = new byte[1024];
            int count;
            count = stream.Read(buff,0,1024);
            while (count > 0)
            {
                currentSize += count;
                new Thread(InvokeUpLoading).Start(this);//激发上传进行中事件
                sw.BaseStream.Write(buff,0,count);
                count = stream.Read(buff, 0, 1024);
            }
            //sw.WriteLine("finished");
            //msg = sr.ReadLine();
            //bool mark = true;
            //if (msg != "receive")
            //{
            //    mark = false;
            //}
            sw.Close();
            sr.Close();
            client.Close();
            stream.Close();
            //if(!mark)
            //    throw new Exception("上传过程中遇到故障，请重新上传！");
            new Thread(InvokeUpLoadFinished).Start(this);//激发上传完成事件
        }

        /// <summary>
        /// 停止上传
        /// </summary>
        public void StopUpLoad()
        {
            thread.Abort();
        }
    }
}
