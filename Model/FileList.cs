using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// �ϴ����ļ���Ϣ
	/// </summary>
	[Serializable]
	public partial class FileList
	{
		public FileList()
		{}
		#region Model
		private string _fileid;
		private int _serverid;
		/// <summary>
		/// 
		/// </summary>
		public string FileId
		{
			set{ _fileid=value;}
			get{return _fileid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ServerId
		{
			set{ _serverid=value;}
			get{return _serverid;}
		}
		#endregion Model

	}
}

