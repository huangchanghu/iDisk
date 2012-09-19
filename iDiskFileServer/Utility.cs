using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using System.Windows.Forms;

namespace iDiskFileServer
{
    public class Utility
    {
        public static string configPath = "iDiskFileServer.exe.config";

        public static void SetAdd(string key, string value)
        {
            XDocument doc = XDocument.Load(configPath);
            var ele = doc.Root.Element("appSettings").Elements("add");//.Elements("add");
            foreach (var e in ele)
            {
                if (e.Attribute("key").Value == key)
                {
                    e.Attribute("value").Value = value;
                    break;
                }
            }
            doc.Save("iDiskFileServer.exe.config");
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void SetId(int id)
        {
            SetAdd("ID",id.ToString());
        }

        public static void SetIp(string ip)
        {
            SetAdd("IP",ip);
        }

        public static void SetPort(string port)
        {
            SetAdd("Port",port);
        }

        public static void SetDirtory(string dirtory)
        {
            SetAdd("Dirtory",dirtory);
        }

        public static void SetDirtorySize(string size)
        {
            SetAdd("Size",size);
        }

        public static void SetValidSize(string size)
        {
         //   SetAdd();
        }
        public static void SetPass(string pass)
        {
            SetAdd("Pass",pass);
        }
        public static void SetListenCount(string count)
        {
            SetAdd("ListenCount",count);
        }

        public static byte[] GetIp()
        {
            string ip = ConfigurationManager.AppSettings["IP"];
            string[] ips = ip.Split(".".ToCharArray());
            byte[] bip = new byte[4];
            try
            {
                bip[0] = byte.Parse(ips[0]);
                bip[1] = byte.Parse(ips[1]);
                bip[2] = byte.Parse(ips[2]);
                bip[3] = byte.Parse(ips[3]);
            }
            catch
            {
                MessageBox.Show("ip地址格式错误!");
                Application.Exit();
            }
            return bip;
        }

        public static int GetPort()
        {
            try
            {
                int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                if (port > 1023 && port < 65536)
                    return port;
                else
                {
                    MessageBox.Show("端口号必需在1024～65535之间！");
                    Application.Exit();
                    return 0;
                }
            }
            catch
            {
                MessageBox.Show("端口格式错误！");
                Application.Exit();
                return 0;
            }
        }

        public static string GetDirtory()
        {
            return ConfigurationManager.AppSettings["Dirtory"];
        }

        public static long GetDirtorySize()
        {
            string ssize = ConfigurationManager.AppSettings["Size"];
            long size = 0;
            try
            {
                size = long.Parse(ssize);
            }
            catch
            {
                MessageBox.Show("目录大小中有无效的数字！","提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            return size;
        }

        public static int GetId()
        {
            string ids = ConfigurationManager.AppSettings["ID"];
            int id = 0;
            try
            {
                id = int.Parse(ids);
            }
            catch
            {
                MessageBox.Show("id必需是效的整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            return id;
        }

        public static string GetPass()
        {
            return ConfigurationManager.AppSettings["Pass"]; 
        }
        public static int GetListenCount()
        {
            string counts = ConfigurationManager.AppSettings["ListenCount"];
            int count = 0;
            try
            {
                count = int.Parse(counts);
            }
            catch
            {
                MessageBox.Show("监听客户端数量必需是有效的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            return count;
        }

        public static string GetIpAndPort()
        {
            return ConfigurationManager.AppSettings["IP"] + ":" + GetPort();
        }
    
    }

}
