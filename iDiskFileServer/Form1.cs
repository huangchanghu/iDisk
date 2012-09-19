using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using iDiskFileServer.FSServices;
using System.Configuration;
using System.Xml.Linq;
using System.Xml;
using System.Reflection;
using System.Threading;
using System.IO;
using System;

namespace iDiskFileServer
{
    public partial class Form1 : Form
    {
        FileServer server;
        TcpListener listener;
        Thread listenThread;
        FSServices.UserServiceClient fss;
        public Form1()
        {
            InitializeComponent();
            fss = new FSServices.UserServiceClient();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            if (Utility.GetId() < 0)
            {
                if (!Register())
                {
                    MessageBox.Show(this, "无法注册服务器", "注册", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            if (!LoginServer())
            {
                MessageBox.Show(this, "无法登录主服务器!\r\n这可能是由于手动修改配置文件造成的.", "登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            else
            {
                listener = new TcpListener(new IPAddress(Utility.GetIp()), Utility.GetPort());
                listener.Start(Utility.GetListenCount());
                listenThread = new Thread(StartService);
                listenThread.Start();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listener != null)
            {
                listener.Stop();
                listenThread.Abort();
            }
        }

        //开启服务
        private void StartService()
        {
            TcpClient client = null;
            listBox1.Items.Add("开始监听...");
            while (true)
            {
                client = listener.AcceptTcpClient();
                Thread t = new Thread(Operation);
                t.Start(client);
            }
        }
        private void Operation(object state)
        {
            TcpClient client = state as TcpClient;
            listBox1.Items.Add("新客户端：" + client.Client.RemoteEndPoint.ToString());
            BinaryReader br = new BinaryReader(client.GetStream());
            string msg = br.ReadString(); 
            listBox1.Items.Add("处理类型：" + msg);
            if (msg == "upload")
                UpLoad(client);
            else if (msg == "download")
                DownLoad(state);
            else
            {
                br.Close();
                client.Close();
            }
        }

        private void DownLoad(object state)
        {
            try
            {
                TcpClient client = state as TcpClient;
                BinaryReader br = new BinaryReader(client.GetStream());
                string id = br.ReadString();
                string user = br.ReadString();
                string pass = br.ReadString();
                if (!fss.CheckedUser(user, pass))
                {
                    client.Close();
                    br.Close();
                    listBox1.Items.Add("用户验证失败!");
                    return;
                }
                string path = Utility.GetDirtory() + "\\" + id + ".idf";
                listBox1.Items.Add(string.Format("正在下载文件:{0}！", path));
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(fs);
                byte[] buff = new byte[1024];
                int count;
                while ((count = reader.Read(buff, 0, 1024)) != 0)
                {
                    client.Client.Send(buff, count, SocketFlags.None);
                }
                listBox1.Items.Add(string.Format("下载文件:{0}完成！", path));
                client.Client.Shutdown(SocketShutdown.Both);
                br.Close();
                reader.Close();
                fs.Close();
            }
            catch (Exception e)
            {

                listBox1.Items.Add(e.Message);
            }
        }
        //客户端上传文件
        private void UpLoad(object state)
        {
            
                TcpClient client = state as TcpClient;
                BinaryReader br = new BinaryReader(client.GetStream());
                try
                {
                string id = br.ReadString();
                string user = br.ReadString();
                string pass = br.ReadString();
                listBox1.Items.Add("文件Id=" + id);
                listBox1.Items.Add("User=" + user);
                listBox1.Items.Add("Pass=" + pass);
                if (!fss.CheckedUser(user, pass))
                {
                    client.Close();
                    br.Close();
                    listBox1.Items.Add("用户验证失败!");
                    return;
                }
                
                //将fileID 和filesererID 添加到表FileList
                string path = Utility.GetDirtory() + "\\" + id + ".idf";
                listBox1.Items.Add("开始接收文件..."); listBox1.Items.Add("文件保存路径：" + path);
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                int count;
                byte[] buff = new byte[1024];
                try
                {
                    while ((count = client.Client.Receive(buff, 1024, SocketFlags.None)) != 0)
                    {
                        bw.Write(buff, 0, count);
                    }
                    bw.Close();
                }
                catch (Exception e)
                {
                    listBox1.Items.Add("文件传输失败:\r\n" + e.Message);
                    fss.DeleteFile(id, user);
                }
                fs.Close();
                client.Close();
                listBox1.Items.Add("接收完成！");
                fss.AddFileList(new FileList { _fileid = id, _serverid = Utility.GetId() });
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("上传文件过程中发生异常：" + ex.Message + "\r\n客户端终节点：" + client.Client.RemoteEndPoint);
            }
        }
        //客户端操作
        private void ClientOperation(object param)
        {
            TcpClient client = param as TcpClient;
            if (client == null) return;
            listBox1.Items.Add("连接状态：" + client.Connected.ToString());
            listBox1.Items.Add("客户机：" + client.Client.RemoteEndPoint.Serialize().ToString());
           
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns); listBox1.Items.Add("进行握手...");
            string msg = string.Empty;
            msg = sr.ReadLine();
            listBox1.Items.Add("Receive:" + msg);
            if (msg == "userclient")
                UserClientOperation(client);
            else
                if (msg == "mainserver")
                    MainServerOperation(client);
                else
                {
                    sw.WriteLine("unknow client");
                    sr.Close();
                    sw.Close();
                    client.Close();
                }
        }
        //用户客户端操作
        private void UserClientOperation(TcpClient client)
        {
            listBox1.Items.Add("进行用户客户端操作");
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream()); 
            writer.WriteLine("ok");
            listBox1.Items.Add("Send:ok");
            string user = string.Empty;
            user = reader.ReadLine(); listBox1.Items.Add("Receive:" + user);
            user = user.Substring(user.IndexOf("=" + 1));
            string pass = reader.ReadLine();listBox1.Items.Add("Receive:" + pass);
            pass = pass.Substring(pass.IndexOf("="));
            if (!fss.CheckedUser(user, pass))
            {
                writer.WriteLine("invalid user"); listBox1.Items.Add("Send:invalid user");
                client.Close();
                return;
            }
            writer.WriteLine("success"); listBox1.Items.Add("Send:success");
            string type = reader.ReadLine(); listBox1.Items.Add("Receice(type):" + type);
            if (type == "upload")
                UserUpLoad(client);
            else if (type == "download")
                UserDownLoad(client);
            else
            {
                writer.WriteLine("unknow type"); listBox1.Items.Add("Send:unknow type");
                reader.Close();
                writer.Close();
                client.Close();
            }
        }
        //用户上传文件
        private void UserUpLoad(TcpClient client)
        {
            listBox1.Items.Add("进行用户上传操作");
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            //接收文件前的确认
            string fid = reader.ReadLine(); listBox1.Items.Add("Receive:" + fid);
            string ssize = reader.ReadLine(); listBox1.Items.Add("Receive:" + ssize);
            string[] fids = fid.Split("=".ToCharArray());
            string[] sizes = ssize.Split("=".ToCharArray());
            bool mark = true;
            if (fids[0] != "id")
            {
                writer.WriteLine("unrealized id"); listBox1.Items.Add("Send:unrealized id");
                mark = false;
            }
            if (sizes[0] != "size")
            {
                writer.WriteLine("unrealized size"); listBox1.Items.Add("Send:unrealized size");
                mark = false;
            }
            if (!mark)
            {
                reader.Close();
                writer.Close();
                client.Close();
                return;
            }
            writer.WriteLine("begin"); listBox1.Items.Add("Send:begin");

            //开始接收文件
            int size = int.Parse(sizes[1]);
            string filename = Utility.GetDirtory() + "\\" + fids[1] + ".idisk";
            FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            byte[] buff = new byte[1024];
            int count = 0;
            long sum = 0;
            count = client.GetStream().Read(buff, 0, 1024); listBox1.Items.Add("正在接收文件...");
            sum += count;
            while (sum < size)
            {
                stream.Write(buff, 0, count);
                count = client.GetStream().Read(buff, 0, 1024);
                sum += count;
            }
            stream.Flush();
            stream.Close();
            reader.Close();
            writer.Close();
            //string msg = reader.ReadLine();
            //if (msg == "finished")
            //    writer.WriteLine("receive");
            //else
            //    writer.WriteLine("receive fail");
            client.Close(); listBox1.Items.Add("文件接收完成");
        }

        ///用户下载文件
        private void UserDownLoad(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            //接收文件前的确认
            string fid = reader.ReadLine();
            string[] fids = fid.Split("=".ToCharArray());
            if (fids[0] != "id")
            {
                writer.WriteLine("unrealized id");
                client.Close();
                return;
            }
            //判断文件是否存在
            string filename = Utility.GetDirtory() + "\\" + fids[1] + ".idisk";
            FileInfo file = new FileInfo(filename);
            if (!file.Exists)
            {
                writer.WriteLine("file not found");
                client.Close();
                return;
            }
            long size = file.Length;
            writer.WriteLine("size=" + size.ToString());
            //开始传输文件
            FileStream stream = file.OpenRead();
            byte[] buff = new byte[1024];
            int count = 0;
            count = stream.Read(buff, 0, 1024);
            while (count > 0)
            {
                client.GetStream().Write(buff,0,count);
                count = stream.Read(buff, 0, 1024);
            }
            //writer.WriteLine("finished");
            stream.Close();
            reader.Close();
            writer.Close();
            client.Close();
        }

        //主服务器相关操作
        private void MainServerOperation(TcpClient client)
        {
 
        }

        //文件服务器登录
        private bool LoginServer()
        {
            server = fss.Login(Utility.GetId(), Utility.GetPass());
            return server != null;
        }
        ///注册文件服务器
        private bool Register()
        {
            FileServer fs = new FileServer { 
                _fsdirtory = "Dirtory", 
                _fshost = Utility.GetIpAndPort(), 
                _fspass = Utility.GetPass(),
                _fssize = Utility.GetDirtorySize(),
                _fsvalidsize = 0//字段已更改用途，改为已使用空间
            };
            int id = fss.Register(fs);
            if (id == 0)
                return false;
            Utility.SetId(id);
            return true;
        }
        ///更新文件服务器配置
        private bool UpdateFileServer()
        {
            server._fsdirtory = Utility.GetDirtory();
            server._fshost = Utility.GetIpAndPort();
            server._fspass = Utility.GetPass();
            server._fssize = Utility.GetDirtorySize();
            return fss.UpdateFileServer(server);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (!LoginServer())
            {
                MessageBox.Show("登录失败");
                return;
            }
            MessageBox.Show(UpdateFileServer().ToString());
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            listener.Stop();
            listenThread.Abort();
            Application.Exit();
        }

        

        
    }
}
