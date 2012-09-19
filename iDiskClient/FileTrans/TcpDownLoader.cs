using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using iDiskClient;
using System.Windows.Forms;

namespace iDiskClient
{
    public class TcpDownLoader : DownLoader
    {
        string ip = string.Empty;//字符串形式的Ip
        int port = 0;
        string dirtory = "";
        TcpClient client;
        FileServices.User user;
        FileServices.File file;
        Thread thread;
        public TcpDownLoader(string url, string fileName, string localFileName, FileServices.User user, FileServices.File file)
            : base(url, fileName, localFileName, 1)
        {
            this.user = user;
            this.file = file;
            #region 初始化ip和端口号
            string[] tem = url.Split(new char[] { ':', '/' });
            ip = tem[0];
            port = int.Parse(tem[1]);
            dirtory = tem[2];
            fileSize = (long)file._fsize;
            #endregion  初始化ip和端口号
        }

        public override void BeginDownLoad()
        {
            thread = new Thread(DownLoad2);
            thread.Start();
        }

        private void DownLoad2()
        {
            client = new TcpClient(ip, port);
            FileStream fs = new FileStream(localFileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            BinaryWriter writer = new BinaryWriter(client.GetStream());
            writer.Write("download");
            writer.Write(file._fid);
            writer.Write(user._uloginname);
            writer.Write(user._upassword);
            begin = true;
            new Thread(InvokeDownLoadBegin).Start(this);
            byte[] buff = new byte[1024];
            int count;
            while ((count = client.Client.Receive(buff, 1024, SocketFlags.None)) != 0)
            {
                currentSize += count;
                new Thread(InvokeDownLoading).Start(this);
                bw.Write(buff, 0, count);
            }
            bw.Flush();
            bw.Close();
            fs.Close();
            writer.Close();
            client.Close();
            finished = true;
            new Thread(InvokeDownLoadFinished).Start(this);
        }

        private void DownLoad()
        {
            try
            {
                client = new TcpClient(ip, port);
                int time = 30;
                while (true)
                {
                    if (client.Connected)
                        break;
                    Thread.Sleep(1000);
                    --time;
                    if (time < 0)
                        throw new Exception(string.Format("文件：{0}\r\n无法下载！\r\n无法连接下载服务器！"));
                }
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());
                //进行握手协议、建立链接
                writer.WriteLine("userclient");
                string msg = reader.ReadLine();
                if (msg != "ok")
                {
                    reader.Close();
                    writer.Close();
                    client.Close();
                    throw new Exception("连接服务器出现故障！");
                }
                writer.WriteLine("user=" + user._uloginname);
                writer.WriteLine("pass=" + user._upassword);
                msg = reader.ReadLine();
                if (msg != "success")
                {
                    reader.Close();
                    writer.Close();
                    client.Close();
                    throw new Exception("连接服务器出现故障！");
                }
                writer.WriteLine("download");
                writer.WriteLine("id" + file._fid);
                msg = reader.ReadLine();
                if (msg == "file not found")
                {
                    client.Close();
                    reader.Close();
                    writer.Close();
                    throw new Exception("找不到您要下载的文件！");
                }
                if (msg.Split("=".ToCharArray())[0] != "size")
                {
                    reader.Close();
                    writer.Close();
                    client.Close();
                    throw new Exception("连接服务器出现故障！");
                }
                fileSize = int.Parse(msg.Split("=".ToCharArray())[1]);

                //开始传输文件
                begin = true;
                new Thread(InvokeDownLoadBegin).Start(this);//触发下载开始事件
                FileStream stream = new FileStream(localFileName, FileMode.Create, FileAccess.Write);
                byte[] buff = new byte[1024];
                int count = 0;
                count = reader.BaseStream.Read(buff, 0, 1024);
                while (count > 0)
                {
                    currentSize += count;
                    new Thread(InvokeDownLoading).Start(this);//触发正在下载事件
                    stream.Write(buff, 0, count);
                    count = reader.BaseStream.Read(buff, 0, 1024);
                }
                stream.Flush();
                stream.Close();
                msg = reader.ReadLine();
                bool mark = true;//下载完成标志
                if (msg != "finished")
                {
                    File.Delete(localFileName);
                    mark = false;
                }
                writer.Close();
                reader.Close();
                client.Close();
                if (!mark)
                    throw new Exception("下载失败！");
                finished = true;
                new Thread(InvokeDownLoadFinished).Start(this);//触发下载完成事件

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        protected override void Init()
        {
            
        }

        public void StopDownLoad()
        {
            thread.Abort();
        }
    }
}
