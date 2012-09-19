using System;
using System.Collections.Generic;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// Ŀ¼(ÿ���û�ӵ��һ����Ŀ¼��ÿ��Ŀ¼���ж����Ŀ¼)
	/// </summary>
	[Serializable]
	public partial class Dirtory
	{
		public Dirtory()
		{}
		#region Model
		private int _dirid;
		private int? _parentdirid;
		private int _uid;
		private string _dirname;
		private string _dirdesc;
        List<Dirtory> _dirotories  = new List<Dirtory>();
        List<File> _files = new List<File>();
		/// <summary>
		/// Ŀ¼ID
		/// </summary>
		public int DirId
		{
			set{ _dirid=value;}
			get{return _dirid;}
		}
		/// <summary>
		/// �ϼ�Ŀ¼ID
		/// </summary>
		public int? ParentDirId
		{
			set{ _parentdirid=value;}
			get{return _parentdirid;}
		}
		/// <summary>
		/// �����û�ID
		/// </summary>
		public int UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// Ŀ¼����
		/// </summary>
		public string DirName
		{
			set{ _dirname=value;}
			get{return _dirname;}
		}
		/// <summary>
		/// Ŀ¼����
		/// </summary>
		public string DirDesc
		{
			set{ _dirdesc=value;}
			get{return _dirdesc;}
		}

        /// <summary>
        /// ��Ŀ¼��
        /// </summary>
        public List<Dirtory> Dirtories
        {
            get { return this._dirotories; }
            set { this._dirotories = value; }
        }

        /// <summary>
        /// ���һ��Ŀ¼
        /// </summary>
        public void AddDirtory(Dirtory dir)
        {
            Dirtories.Add(dir);
        }
        /// <summary>
        /// �Ƴ�һ��Ŀ¼
        /// </summary>
        /// <param name="dir"></param>
        public void RemoveDirtory(Dirtory dir)
        {
            Dirtories.Remove(dir);
        }
        /// <summary>
        /// ��ȡһ��ָ��ID��Ŀ¼
        /// </summary>
        /// <param name="DirId"></param>
        /// <returns></returns>
        public Dirtory SearchDirtory(int DirId)
        {
            Dirtory dir = null;
            Dirtories.ForEach(e =>
                {
                    if (e.DirId == DirId)
                        dir = e;
                });
            return dir;
        }
        /// <summary>
        /// ��������ָ�����Ƶ�Ŀ¼
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public List<Dirtory> SearchDirtories(string dirName)
        {
            List<Dirtory> dirs = new List<Dirtory>();
            Dirtories.ForEach(e =>
                {
                    if (e.DirName == dirName)
                        dirs.Add(e);
                    SearchDir(e, dirName, dirs);
                });
            return dirs;
        }
        private void SearchDir(Dirtory dir,string dirName, List<Dirtory> dirs)
        {
            dir.Dirtories.ForEach(e =>
                {
                    if (e.DirName == dirName)
                        dirs.Add(e);
                    SearchDir(e, dirName, dirs);
                });
        }
        /// <summary>
        /// �ļ�����
        /// </summary>
        public List<File> Files
        {
            get { return _files; }
            set { _files = value; }
        }
        /// <summary>
        /// ���һ���ļ�
        /// </summary>
        /// <param name="file"></param>
        public void AddFile(File file)
        {
            Files.Add(file);
        }
        /// <summary>
        /// �Ƴ�һ���ļ�
        /// </summary>
        /// <param name="file"></param>
        public void Remove(File file)
        {
            Files.Remove(file);
        }
		#endregion Model

	}
}

