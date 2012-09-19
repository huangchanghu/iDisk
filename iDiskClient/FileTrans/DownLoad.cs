using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;

namespace iDiskClient
{
    public delegate void DownLoadEventHandler(object sender, DownLoadEventArgs args);

    public abstract class DownLoader
    {
        protected string url;               //待下载文件URI
        protected string fileName;          //文件保存的名称
        protected string localFileName;     //本地文件名
        protected long fileSize = 0;        //文件大小
        protected long currentSize = 0;     //已下载文件大小
        protected string[] subFileNames;    //每个线程下载的文件名
        protected Thread[] threads;         //下载线程集
        protected int[] subFileStart;       //每个线程接收文件的起始位置
        protected int[] subFileEnd;         //每个线程应该接收文件的大小
        protected int count;                //线程数
        protected bool initialized = false; //是否已初始化,成功调用Init()方法
        protected bool[] threadEndFlag;     //线程结束标志
        protected bool begin = false;       //下载开始标志，若下载已经开始则为true
        protected bool finished = false;    //下载结束标志，若下载已经结束则为true

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
        /// 获取本地文件名
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

        public DownLoader(string url, string fileName, string localFileName, int threadCount)
        {
            this.url = url;
            this.fileName = fileName;
            this.localFileName = localFileName;
            this.count = threadCount;
            threads = new Thread[count];
            subFileNames = new string[count];
            subFileStart = new int[count];
            subFileEnd = new int[count];
            threadEndFlag = new bool[count];

            for (int i = 0; i < count; i++)
            {
                subFileNames[i] = fileName + "_part" + i + ".dat";    //初始化每个线程下载的子文件名
                threadEndFlag[i] = false;                   //初始化线程结束标志
            }
            Init();
        }

        private object obj = new object();
        /// <summary>
        /// 改变已下载的量
        /// </summary>
        /// <param name="value">value将被加到currentSize上</param>
        protected void AddCurrentSize(int value)
        {
            lock (obj)
            {
                if ((currentSize + value) >= fileSize)
                    currentSize = fileSize;
                else
                    currentSize += value;
            }
        }

        #region 抽象方法
        public abstract void BeginDownLoad();
        protected abstract void Init(); 
        #endregion

        #region 事件
        /// <summary>
        /// 下载开始
        /// </summary>
        public event DownLoadEventHandler DownLoadBegin;
        /// <summary>
        /// 下载完成
        /// </summary>
        public event DownLoadEventHandler DownLoadFinished;
        /// <summary>
        /// 每下载设定量的文件大小都被激发一次，下载过程中将被多次激发，可用于查看下载进度
        /// </summary>
        public event DownLoadEventHandler DownLoading;
        /// <summary>
        /// 每个子线程下载开始前激发此事件
        /// </summary>
        public event DownLoadEventHandler PartBegin;
        /// <summary>
        /// 每个子线程下载完成时激发此事件
        /// </summary>
        public event DownLoadEventHandler PartEnded;

        /// <summary>
        /// 下载开始
        /// </summary>
        protected void InvokeDownLoadBegin(object sender)
        {
            if(DownLoadBegin != null)
                DownLoadBegin(sender, new DownLoadEventArgs(url,fileName,localFileName,fileSize,currentSize, begin, finished));
        }
        /// <summary>
        /// 下载完成
        /// </summary>
        protected void InvokeDownLoadFinished(object sender)
        {
            if(DownLoadFinished != null)
                DownLoadFinished(sender, new DownLoadEventArgs(url, fileName, localFileName, fileSize, currentSize, begin, finished));
        }
        /// <summary>
        /// 每下载设定量的文件大小都被激发一次，下载过程中将被多次激发，可用于查看下载进度
        /// </summary>
        protected void InvokeDownLoading(object sender)
        {
            if(DownLoading != null)
                DownLoading(sender, new DownLoadEventArgs(url, fileName, localFileName, fileSize, currentSize, begin, finished));
        }
        /// <summary>
        /// 子线程下载开始
        /// </summary>
        protected void InvokePartBegin(object sender)
        {
            if(PartBegin != null)
                PartBegin(sender, new DownLoadEventArgs(url, fileName, localFileName, fileSize, currentSize, begin, finished));
        }
        /// <summary>
        /// 每个子线程下载完成时激发此事件
        /// </summary>
        protected void InvokePartEnded(object sender)
        {
            if(PartEnded != null)
                PartEnded(sender, new DownLoadEventArgs(url, fileName, localFileName, fileSize, currentSize, begin, finished));
        }
        #endregion
    }
}
