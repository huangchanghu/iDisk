using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// �ļ���ǩ��ÿ���ļ����ж����ǩ
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
		/// ��ǩ��
		/// </summary>
		public string TName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		/// <summary>
		/// �û�ID
		/// </summary>
		public int TUserId
		{
			set{ _tuserid=value;}
			get{return _tuserid;}
		}
		/// <summary>
		/// �ļ�ID
		/// </summary>
		public int TFileId
		{
			set{ _tfileid=value;}
			get{return _tfileid;}
		}
		#endregion Model

	}
}

