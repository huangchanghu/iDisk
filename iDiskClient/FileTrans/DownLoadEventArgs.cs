using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDiskClient
{
    public class DownLoadEventArgs:EventArgs
    {
        string url;
        string fileName;
        string localFileName;
        long fileSize;
        long currentSize;
        bool begin;
        bool finished;
        public DownLoadEventArgs(string url, string fileName, string localFileName, long fileSize, long currentSize, bool begin, bool finished)
        {
            this.url = url;
            this.fileName = fileName;
            this.localFileName = localFileName;
            this.fileSize = fileSize;
            this.currentSize = currentSize;
            this.begin = begin;
            this.finished = finished;
        }
        #region 公开的属性
        /// <summary>
        /// 获取下载文件的url
        /// </summary>
        public string Url { get { return url; } }
        /// <summary>
        /// 获取保存为的文件名
        /// </summary>
        public string FileName { get { return fileName; } }
        /// <summary>
        /// 获取本地存储文件名
        /// </summary>
        public string LocalFileName { get { return localFileName; } }
        /// <summary>
        /// 获取文件的大小
        /// </summary>
        public long FileSize { get { return fileSize; } }
        /// <summary>
        /// 获取当前已下载文件的大小
        /// </summary>
        public long CurrentSize { get { return currentSize; } }
        /// <summary>
        /// 下载开始标志，若下载已经开始则为true
        /// </summary>
        public bool Begin { get { return begin; } }
        /// <summary>
        /// 下载结束标志，若下载已经结束则为true
        /// </summary>
        public bool Finished { get { return finished; } }

        #endregion
    }
}
