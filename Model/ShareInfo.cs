using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// �ļ�������Ϣ
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
		/// ������Ϣ������ID
		/// </summary>
		public int? SSender
		{
			set{ _ssender=value;}
			get{return _ssender;}
		}
		/// <summary>
		/// ������Ϣ������ID
		/// </summary>
		public int? SReceive
		{
			set{ _sreceive=value;}
			get{return _sreceive;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public DateTime? SDate
		{
			set{ _sdate=value;}
			get{return _sdate;}
		}
		/// <summary>
		/// �ļ�ID
		/// </summary>
		public int SFileId
		{
			set{ _sfileid=value;}
			get{return _sfileid;}
		}
		#endregion Model

	}
}

