using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// �û���Ϣ
	/// </summary>
	[Serializable]
	public partial class User
	{
		public User()
		{}
		#region Model
		private int _uid;
		private string _uloginname;
		private string _urealname;
		private string _uemail;
		private string _upassword;
		/// <summary>
		/// �û�ID
		/// </summary>
		public int UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// ��¼��
		/// </summary>
		public string ULoginName
		{
			set{ _uloginname=value;}
			get{return _uloginname;}
		}
		/// <summary>
		/// ��ʵ����
		/// </summary>
		public string URealName
		{
			set{ _urealname=value;}
			get{return _urealname;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string UEmail
		{
			set{ _uemail=value;}
			get{return _uemail;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string UPassWord
		{
			set{ _upassword=value;}
			get{return _upassword;}
		}
		#endregion Model

	}
}

