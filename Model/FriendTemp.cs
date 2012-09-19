using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 好友申请记录
	/// </summary>
	[Serializable]
	public partial class FriendTemp
	{
		public FriendTemp()
		{}
		#region Model
		private int _senderid;
		private int _receiver;
		private bool? _confirmed;
		private string _message;
		/// <summary>
		/// 发送者ID
		/// </summary>
		public int SenderId
		{
			set{ _senderid=value;}
			get{return _senderid;}
		}
		/// <summary>
		/// 接收者ID
		/// </summary>
		public int Receiver
		{
			set{ _receiver=value;}
			get{return _receiver;}
		}
		/// <summary>
		/// 处理标志(true为拒绝，false为等待确认)
		/// </summary>
		public bool? Confirmed
		{
			set{ _confirmed=value;}
			get{return _confirmed;}
		}
		/// <summary>
		/// 备注信息
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
		}
		#endregion Model

	}
}

