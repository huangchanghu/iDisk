using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 用户信息
	/// </summary>
	[Serializable]
	public partial class FriendTempV
	{
		public FriendTempV()
		{}
		#region Model
		private int _senderid;
		private int _receiver;
		private bool _confirmed;
		private string _message;
		private string _receivername;
		private string _sendername;
		/// <summary>
		/// 
		/// </summary>
		public int SenderId
		{
			set{ _senderid=value;}
			get{return _senderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Receiver
		{
			set{ _receiver=value;}
			get{return _receiver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Confirmed
		{
			set{ _confirmed=value;}
			get{return _confirmed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceiverName
		{
			set{ _receivername=value;}
			get{return _receivername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SenderName
		{
			set{ _sendername=value;}
			get{return _sendername;}
		}
		#endregion Model

	}
}

