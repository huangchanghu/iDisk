using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// ���Ѽ�¼
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
		/// ����ӵ����ID
		/// </summary>
		public int FrOwnerId
		{
			set{ _frownerid=value;}
			get{return _frownerid;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int FrFriendId
		{
			set{ _frfriendid=value;}
			get{return _frfriendid;}
		}
		#endregion Model

	}
}

