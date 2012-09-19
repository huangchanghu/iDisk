using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// �ļ���������Ϣ��ÿ����������һ���ļ�����ڵ㣬ÿ���ڵ�������洢Ŀ¼
	/// </summary>
	[Serializable]
	public partial class FileServer
	{
		public FileServer()
		{}
		#region Model
		private int _fsid;
		private string _fshost;
		private string _fsdirtory;
		private long? _fssize;
		private long? _fsvalidsize;
		private string _fspass;
		/// <summary>
		/// 
		/// </summary>
		public int FSId
		{
			set{ _fsid=value;}
			get{return _fsid;}
		}
		/// <summary>
		/// �ļ�������ip��������(�磺222.27.255.59��555)
		/// </summary>
		public string FSHost
		{
			set{ _fshost=value;}
			get{return _fshost;}
		}
		/// <summary>
		/// �ļ��������ϴ洢�ļ���Ŀ¼��
		/// </summary>
		public string FSDirtory
		{
			set{ _fsdirtory=value;}
			get{return _fsdirtory;}
		}
		/// <summary>
		/// �洢�ļ��Ŀռ��С
		/// </summary>
		public long? FSSize
		{
			set{ _fssize=value;}
			get{return _fssize;}
		}
		/// <summary>
		/// ���ÿռ�
		/// </summary>
		public long? FSValidSize
		{
			set{ _fsvalidsize=value;}
			get{return _fsvalidsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FSPass
		{
			set{ _fspass=value;}
			get{return _fspass;}
		}
		#endregion Model

	}
}

