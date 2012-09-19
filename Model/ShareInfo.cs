using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 文件分享信息
	/// </summary>
	[Serializable]
	public partial class ShareInfo
	{
		public ShareInfo()
		{}
		#region Model
		private int _sid;
		private int? _ssender;
		private int? _sreceive;
		private DateTime? _sdate;
		private int _sfileid;
		/// <summary>
		/// 
		/// </summary>
		public int SId
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 分享信息发送者ID
		/// </summary>
		public int? SSender
		{
			set{ _ssender=value;}
			get{return _ssender;}
		}
		/// <summary>
		/// 分享信息接收者ID
		/// </summary>
		public int? SReceive
		{
			set{ _sreceive=value;}
			get{return _sreceive;}
		}
		/// <summary>
		/// 分享日期
		/// </summary>
		public DateTime? SDate
		{
			set{ _sdate=value;}
			get{return _sdate;}
		}
		/// <summary>
		/// 文件ID
		/// </summary>
		public int SFileId
		{
			set{ _sfileid=value;}
			get{return _sfileid;}
		}
		#endregion Model

	}
}

