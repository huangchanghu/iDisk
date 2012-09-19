using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 用户信息
	/// </summary>
	[Serializable]
	public partial class FriendV
	{
		public FriendV()
		{}
		#region Model
		private int _frownerid;
		private int _frfriendid;
		private string _uloginname;
		/// <summary>
		/// 
		/// </summary>
		public int FrOwnerId
		{
			set{ _frownerid=value;}
			get{return _frownerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FrFriendId
		{
			set{ _frfriendid=value;}
			get{return _frfriendid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ULoginName
		{
			set{ _uloginname=value;}
			get{return _uloginname;}
		}
		#endregion Model

	}
}

