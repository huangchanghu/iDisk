using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ServiceModel;
using Hch.iDisk.Model;
using Hch.iDisk;


namespace iDiskMainServer
{
    public partial class Form1 : Form
    {
        ServiceHost userServiceHost;
        ServiceHost fileServiceHost;
        ServiceHost fsserviceHost;
        Hch.iDisk.Services.UserService us = new Hch.iDisk.Services.UserService();
        Hch.iDisk.Services.FileService fs = new Hch.iDisk.Services.FileService();
        Hch.iDisk.Services.FSService fss = new Hch.iDisk.Services.FSService();
        
        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                userServiceHost = new ServiceHost(typeof(Hch.iDisk.Services.UserService));
                userServiceHost.Opened += delegate
                {
                    //MessageBox.Show("用户服务已启动！");
                };
                userServiceHost.Open();
                fileServiceHost = new ServiceHost(typeof(Hch.iDisk.Services.FileService));
                fileServiceHost.Opened += delegate
                {
                    // MessageBox.Show("文件服务已启动！");
                };
                fileServiceHost.Open();
                fsserviceHost = new ServiceHost(typeof(Hch.iDisk.Services.FSService));
                fsserviceHost.Opened += delegate
                {
                    // MessageBox.Show("文件服务器服务已启动");
                };
                fsserviceHost.Open();
                MessageBox.Show(this, "服务已启动！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务启动失败！\r\n" + ex.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(fs.AddFile(new File { FId="huhu", FDesc = "新增的文件", FName = "新文件", FSize = 200, FUrl = "htp://", FUserId = 9, DirId = 15, FDate = DateTime.Now, FVisibility = 2 }, new User {  UId=9}).ToString());
            //FileServer fs = new FileServer { FSDirtory="dirtory", FSHost="202.1180.215:80", FSPass="123456", FSSize=2000, FSValidSize=145};
            //int id = fss.Register(fs);

            //MessageBox.Show(fs.GetDownLoadUrl(new File { FId = "实习重要dd文件.rar", FSize=10 }, new User { UId = 9 }).ToString());
           // MessageBox.Show(fs.GetDirtory(new User {  UId=5}).DirId.ToString());
            //List<File> file = fs.QueryFiles(string.Format("FName like '%{0}%' and FVisibility=2", textBox1.Text.Trim()), new User { UId = 5 });
            //dataGridView1.DataSource = file.ToArray();
            MessageBox.Show(us.DeleteUser(new User { UId = 7 }, new User { UId = 6 }).ToString());
        }
    }
}
