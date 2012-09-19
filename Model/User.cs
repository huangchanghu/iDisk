using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 用户信息
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
		/// 用户ID
		/// </summary>
		public int UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 登录名
		/// </summary>
		public string ULoginName
		{
			set{ _uloginname=value;}
			get{return _uloginname;}
		}
		/// <summary>
		/// 真实名称
		/// </summary>
		public string URealName
		{
			set{ _urealname=value;}
			get{return _urealname;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string UEmail
		{
			set{ _uemail=value;}
			get{return _uemail;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string UPassWord
		{
			set{ _upassword=value;}
			get{return _upassword;}
		}
		#endregion Model

	}
}

