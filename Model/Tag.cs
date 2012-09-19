using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 文件标签，每个文件可有多个标签
	/// </summary>
	[Serializable]
	public partial class Tag
	{
		public Tag()
		{}
		#region Model
		private string _tname;
		private int _tuserid;
		private int _tfileid;
		/// <summary>
		/// 标签名
		/// </summary>
		public string TName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int TUserId
		{
			set{ _tuserid=value;}
			get{return _tuserid;}
		}
		/// <summary>
		/// 文件ID
		/// </summary>
		public int TFileId
		{
			set{ _tfileid=value;}
			get{return _tfileid;}
		}
		#endregion Model

	}
}

