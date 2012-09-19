using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 文件服务器信息，每个主机代表一个文件服务节点，每个节点可设多个存储目录
	/// </summary>
	[Serializable]
	public partial class FileServer
	{
		public FileServer()
		{}
		#region Model
		private int _fsid;
		private string _fshost;
		private string _fsdirtory;
		private long? _fssize;
		private long? _fsvalidsize;
		private string _fspass;
		/// <summary>
		/// 
		/// </summary>
		public int FSId
		{
			set{ _fsid=value;}
			get{return _fsid;}
		}
		/// <summary>
		/// 文件服务器ip或主机名(如：222.27.255.59：555)
		/// </summary>
		public string FSHost
		{
			set{ _fshost=value;}
			get{return _fshost;}
		}
		/// <summary>
		/// 文件服务器上存储文件的目录名
		/// </summary>
		public string FSDirtory
		{
			set{ _fsdirtory=value;}
			get{return _fsdirtory;}
		}
		/// <summary>
		/// 存储文件的空间大小
		/// </summary>
		public long? FSSize
		{
			set{ _fssize=value;}
			get{return _fssize;}
		}
		/// <summary>
		/// 可用空间
		/// </summary>
		public long? FSValidSize
		{
			set{ _fsvalidsize=value;}
			get{return _fsvalidsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FSPass
		{
			set{ _fspass=value;}
			get{return _fspass;}
		}
		#endregion Model

	}
}

