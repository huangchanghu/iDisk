using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using System.Security.Cryptography;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace iDiskClient
{
    public class Utility
    {
        ///文件可见性字串到数字的映射
        public static int StrToInt(string visibility)
        {
            switch(visibility)
            {
                case "公开":
                    return 2;
                case "好友可见":
                    return 1;
                case "私有":
                    return 0;
                default:
                    return 0;
            }
        }
        ///文件可见性数字到字串的映射
        public static string IntToStr(int visibility)
        {
            switch (visibility)
            {
                case 0:
                    return "私有";
                case 1:
                    return "好友可见";
                case 2:
                    return "公开";
                default:
                    return "私有";
            }
        }
        //获取文件MD5值
        public static string GetFileId(string filePath)
        {
            //return filePath.Substring(filePath.LastIndexOf("\\") + 1);
            return MakeFileMD5(filePath);
        }
        /// <summary>
        /// 获取文件名称
        /// </summary>
        /// <param name="filePath">文件的完整路径</param>
        /// <returns></returns>
        public static string GetFileName(string filePath)
        {
            return filePath.Substring(filePath.LastIndexOf("\\") + 1);
        }
        //获取文件大小
        public static long GetFileSize(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            return fi.Length;
        }

        public static string configPath = Application.StartupPath + "\\iDiskClient.exe.config";

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
            doc.Save(configPath);
            ConfigurationManager.RefreshSection("appSettings");
        }
        //获取已保存的用户名
        public static string GetUserName()
        {
            return ConfigurationManager.AppSettings["Name"];
        }
        //获取已保存的密码
        public static string GetPass()
        {
            return ConfigurationManager.AppSettings["Pass"];
        }
        //获取“保存密码”的选中状态
        public static bool GetKeepPass()
        {
            return bool.Parse(ConfigurationManager.AppSettings["KeepPass"]);
        }
        //获取“自动登录”的选中状态
        public static bool GetAutoLogin()
        {
            return bool.Parse(ConfigurationManager.AppSettings["AutoLogin"]);
        }
        public static string ConvertSize(long size)
        {
            string rect = "";
            size /= 1024;
            if(size < 1024)
                rect = size.ToString("0.00") + "KB";
            else
                rect = Convert.ToDouble(size/1024).ToString("0.00") + "MB";
            return rect;
        }
        //获取缺省路径
        public static string GetDefaultPath()
        {
            string dir = ConfigurationManager.AppSettings["DefaultPath"];
            if (dir == "" || !Directory.Exists(dir))
                Directory.CreateDirectory(Application.StartupPath + "\\DownLoad");
            return Application.StartupPath + "\\DownLoad";
        }
        //设置缺省路径
        public static void SetDefaultPath(string path)
        {
            SetAdd("DefaultPath", path);
        }
        //设置“保存密码”的选中状态
        public static void SetKeepPass(bool keepPass)
        {
            SetAdd("KeepPass",keepPass.ToString());
        }
        //设置“自动登录”的选中状态
        public static void SetAutoLogin(bool autoLogin)
        {
            SetAdd("AutoLogin", autoLogin.ToString());
        }
        //保存用户名
        public static void SetUserName(string name)
        {
            SetAdd("Name",Encrypt(name));
        }
        //保存用户密码
        public static void SetPass(string pass)
        {
            SetAdd("Pass",Encrypt(pass));
        }
        //加密字符串
        public static string Encrypt(string str)
        {
            return str;
        }
        //解密经Encrypt()加密的字符串
        public static string Decrypt(string str)
        {
            return str;
        }
        ///获取文件的MD5值
        public static string MakeFileMD5(string filePath)
        {
            string strResult = string.Empty;

            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 1024);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(stream);

            byte[] hash = md5.Hash;

            strResult = System.BitConverter.ToString(hash);

            strResult = strResult.Replace("-", "");
            return strResult;
        }
        ///获取文件类型
        public static string GetFileType(string fileName)
        {
            int index = fileName.LastIndexOf(".");
            return index<0?"":fileName.Substring(index).ToLower();
        }
        private static List<string> fileTypes = new List<string>();
        ///判断是否已处理过此文件类型的图标
        public static bool FileTypeExists(string type, bool isFileName)
        {
            string t = isFileName ? GetFileType(type) : type;
            if (fileTypes.Contains(t))
                return true;
            else
            {
                //MessageBox.Show(t);
                fileTypes.Add(t);
                return false;
            }
        }
        
            [DllImport("Shell32.dll", EntryPoint = "SHGetFileInfo", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
            [DllImport("User32.dll", EntryPoint = "DestroyIcon")]
            private static extern int DestroyIcon(IntPtr hIcon);
            #region API 参数的常量定义
            private const uint SHGFI_ICON = 0x100;
            private const uint SHGFI_LARGEICON = 0x0; //大图标 32×32
            private const uint SHGFI_SMALLICON = 0x1; //小图标 16×16
            private const uint SHGFI_USEFILEATTRIBUTES = 0x10;
            #endregion
            /// <summary>
            /// 保存文件信息的结构体
            /// </summary>
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            struct SHFILEINFO
            {
                public IntPtr hIcon;
                public int iIcon;
            }
            /// <summary>
            /// 获取文件类型的关联图标
            /// </summary>
            /// <param name="fileName">文件类型的扩展名或文件的绝对路径</param>
            /// <param name="isLargeIcon">是否返回大图标</param>
            /// <returns>获取到的图标</returns>
            public static Icon GetIcon(string fileName, bool isLargeIcon)
            {
                SHFILEINFO shfi = new SHFILEINFO();
                IntPtr hI;
                if (isLargeIcon)
                {
                    hI = SHGetFileInfo(fileName, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | SHGFI_LARGEICON);
                }
                else
                {
                    hI = SHGetFileInfo(fileName, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | SHGFI_SMALLICON);
                }
                Icon icon = Icon.FromHandle(shfi.hIcon).Clone() as Icon;
                DestroyIcon(shfi.hIcon); //释放资源
                return icon;
            }
    }
}
