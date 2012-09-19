using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// ���������¼
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
		/// ������ID
		/// </summary>
		public int SenderId
		{
			set{ _senderid=value;}
			get{return _senderid;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int Receiver
		{
			set{ _receiver=value;}
			get{return _receiver;}
		}
		/// <summary>
		/// �����־(trueΪ�ܾ���falseΪ�ȴ�ȷ��)
		/// </summary>
		public bool? Confirmed
		{
			set{ _confirmed=value;}
			get{return _confirmed;}
		}
		/// <summary>
		/// ��ע��Ϣ
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
		}
		#endregion Model

	}
}

