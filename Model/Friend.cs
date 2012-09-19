using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 好友记录
	/// </summary>
	[Serializable]
	public partial class Friend
	{
		public Friend()
		{}
		#region Model
		private int _frownerid;
		private int _frfriendid;
		/// <summary>
		/// 好友拥有者ID
		/// </summary>
		public int FrOwnerId
		{
			set{ _frownerid=value;}
			get{return _frownerid;}
		}
		/// <summary>
		/// 好友ID
		/// </summary>
		public int FrFriendId
		{
			set{ _frfriendid=value;}
			get{return _frfriendid;}
		}
		#endregion Model

	}
}

