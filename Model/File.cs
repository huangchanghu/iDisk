using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// �ϴ����ļ���Ϣ
	/// </summary>
	[Serializable]
	public partial class File
	{
		public File()
		{}
		#region Model
		private string _fid;
		private int? _dirid;
		private string _fname;
		private DateTime? _fdate;
		private long? _fsize;
		private int? _fvisibility;
		private string _furl;
		private string _fdesc;
		private int _fuserid;
		/// <summary>
		/// �ļ�ID
		/// </summary>
		public string FId
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// ����Ŀ¼ID
		/// </summary>
		public int? DirId
		{
			set{ _dirid=value;}
			get{return _dirid;}
		}
		/// <summary>
		/// �ļ�����
		/// </summary>
		public string FName
		{
			set{ _fname=value;}
			get{return _fname;}
		}
		/// <summary>
		/// �ϴ�����
		/// </summary>
		public DateTime? FDate
		{
			set{ _fdate=value;}
			get{return _fdate;}
		}
		/// <summary>
		/// �ļ���С
		/// </summary>
		public long? FSize
		{
			set{ _fsize=value;}
			get{return _fsize;}
		}
		/// <summary>
		/// �ļ��Ŀɼ��ԣ�������˽�У����ѿɼ���
		/// </summary>
		public int? FVisibility
		{
			set{ _fvisibility=value;}
			get{return _fvisibility;}
		}
		/// <summary>
		/// �ļ������ص�ַ
		/// </summary>
		public string FUrl
		{
			set{ _furl=value;}
			get{return _furl;}
		}
		/// <summary>
		/// �ļ�����,С��100����
		/// </summary>
		public string FDesc
		{
			set{ _fdesc=value;}
			get{return _fdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FUserId
		{
			set{ _fuserid=value;}
			get{return _fuserid;}
		}
		#endregion Model

	}
}

