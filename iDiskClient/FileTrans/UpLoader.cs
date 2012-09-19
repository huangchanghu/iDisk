using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDiskClient
{
    public delegate void UpLoadDelete(object obj,UpLoadEventArgs args);
    /// <summary>
    /// 上传事件参数
    /// </summary>
    public class UpLoadEventArgs:EventArgs
    {
        protected string url;
        protected string localFileName;
        protected long fileSize;
        protected long currentSize;
        protected bool begin = false;
        protected bool finished = false;
        public UpLoadEventArgs(string url, string localFileName, long fileSize, long currentSize, bool begin, bool finished)
        {
            this.url = url;
            this.localFileName = localFileName;
            this.fileSize = fileSize;
            this.currentSize = currentSize;
            this.begin = begin;
            this.finished = finished;

        }
        /// <summary>
        /// 上传地址
        /// </summary>
        public string Url{get{return url;}}
        /// <summary>
        /// 本地文件名称
        /// </summary>
        public string LocalFileName { get { return localFileName;}}
        /// <summary>
        /// 上传文件大小
        /// </summary>
        public long FileSize { get { return fileSize;}}
        /// <summary>
        /// 已上传文件大小
        /// </summary>
        public long CurrentSize { get { return currentSize;}}
        /// <summary>
        /// 上传是否已开始
        /// </summary>
        public bool Begin { get { return begin;}}
        /// <summary>
        /// 上传是否已结束
        /// </summary>
        public bool Finished { get { return finished;}}
    }

    abstract class UpLoader
    {
        protected string url;
        protected string localFileName;
        protected long fileSize;
        protected long currentSize;
        protected bool begin = false;
        protected bool finished = false;

        public UpLoader(string url, string localFileName)
        {
            this.url = url;
            this.localFileName = localFileName;
        }

        public abstract void BeginUpLoad();
        /// <summary>
        /// 上传开始时被激发
        /// </summary>
        public event UpLoadDelete UpLoadBegin;
        /// <summary>
        /// 每传送1024字节数据被激发一次
        /// </summary>
        public event UpLoadDelete UpLoading;
        /// <summary>
        /// 上传完成时被激发
        /// </summary>
        public event UpLoadDelete UpLoadFinished;

        protected void InvokeUpLoadBegin(object sender)
        {
            if (UpLoadBegin != null)
                UpLoadBegin(sender, new UpLoadEventArgs(url, localFileName, fileSize,currentSize,begin,finished));
        }
        protected void InvokeUpLoading(object sender)
        {
            if(UpLoading != null)
                UpLoading(sender, new UpLoadEventArgs(url, localFileName, fileSize,currentSize,begin,finished));
        }
        protected void InvokeUpLoadFinished(object sender)
        {
            if (UpLoadFinished != null)
                UpLoadFinished(sender, new UpLoadEventArgs(url, localFileName, fileSize,currentSize,begin,finished));
        }
    }
}
