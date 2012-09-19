using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 上传的文件信息
	/// </summary>
	[Serializable]
	public partial class File
	{
		public File()
		{}
		#region Model
		private string _fid;
		private int? _dirid;
		private string _fname;
		private DateTime? _fdate;
		private long? _fsize;
		private int? _fvisibility;
		private string _furl;
		private string _fdesc;
		private int _fuserid;
		/// <summary>
		/// 文件ID
		/// </summary>
		public string FId
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 所在目录ID
		/// </summary>
		public int? DirId
		{
			set{ _dirid=value;}
			get{return _dirid;}
		}
		/// <summary>
		/// 文件名称
		/// </summary>
		public string FName
		{
			set{ _fname=value;}
			get{return _fname;}
		}
		/// <summary>
		/// 上传日期
		/// </summary>
		public DateTime? FDate
		{
			set{ _fdate=value;}
			get{return _fdate;}
		}
		/// <summary>
		/// 文件大小
		/// </summary>
		public long? FSize
		{
			set{ _fsize=value;}
			get{return _fsize;}
		}
		/// <summary>
		/// 文件的可见性（公开，私有，好友可见）
		/// </summary>
		public int? FVisibility
		{
			set{ _fvisibility=value;}
			get{return _fvisibility;}
		}
		/// <summary>
		/// 文件的下载地址
		/// </summary>
		public string FUrl
		{
			set{ _furl=value;}
			get{return _furl;}
		}
		/// <summary>
		/// 文件描述,小于100个字
		/// </summary>
		public string FDesc
		{
			set{ _fdesc=value;}
			get{return _fdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FUserId
		{
			set{ _fuserid=value;}
			get{return _fuserid;}
		}
		#endregion Model

	}
}

