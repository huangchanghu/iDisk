using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace iDiskClient
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string filePath = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                
            }

            try
            {
                if (filePath == "") return;
                TcpUpLoader up = new TcpUpLoader("127.0.0.1:8887/Dirtory", filePath, new FileServices.File { _fid = filePath.Substring(filePath.LastIndexOf("\\") + 1) }, new FileServices.User { _uloginname = "qiaoer", _upassword = "qiaoer" }, listBox1);
                up.UpLoadBegin += UpLoadBegin;
                up.UpLoadFinished += UpLoadFinished;
                up.UpLoading += UpLoading;
                up.BeginUpLoad();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }
        private void UpLoadBegin(object sender, UpLoadEventArgs args)
        {
            
            listBox1.Items.Add(string.Format("文件：{0}\r\n上传开始...",args.LocalFileName));
        }
        private void UpLoading(object sender, UpLoadEventArgs args)
        {
           // MessageBox.Show("UpLoading...");
        }
        private void UpLoadFinished(object sender, UpLoadEventArgs args)
        {
            //MessageBox.Show("finished");
            listBox1.Items.Add("上传完成");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TcpDownLoader ld = new TcpDownLoader("127.0.0.1:8887/dirtory", "", saveFileDialog1.FileName, new FileServices.User { _uloginname = "qiaoer", _upassword = "qiaoer" }, new FileServices.File { _fid = textBox1.Text.Trim(), _fsize=123 });
                ld.DownLoadFinished += DownLoadFinish;
                ld.BeginDownLoad();
            }
        }
        private void DownLoadFinish(object sender, DownLoadEventArgs args)
        {
            listBox1.Items.Add(string.Format("文件：{0}-下载完成！",args.LocalFileName));
        }
    }
}
