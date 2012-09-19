using System;
using System.Collections.Generic;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// 目录(每个用户拥有一个主目录，每个目录可有多个子目录)
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
		/// 目录ID
		/// </summary>
		public int DirId
		{
			set{ _dirid=value;}
			get{return _dirid;}
		}
		/// <summary>
		/// 上级目录ID
		/// </summary>
		public int? ParentDirId
		{
			set{ _parentdirid=value;}
			get{return _parentdirid;}
		}
		/// <summary>
		/// 所属用户ID
		/// </summary>
		public int UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 目录名称
		/// </summary>
		public string DirName
		{
			set{ _dirname=value;}
			get{return _dirname;}
		}
		/// <summary>
		/// 目录描述
		/// </summary>
		public string DirDesc
		{
			set{ _dirdesc=value;}
			get{return _dirdesc;}
		}

        /// <summary>
        /// 子目录集
        /// </summary>
        public List<Dirtory> Dirtories
        {
            get { return this._dirotories; }
            set { this._dirotories = value; }
        }

        /// <summary>
        /// 添加一个目录
        /// </summary>
        public void AddDirtory(Dirtory dir)
        {
            Dirtories.Add(dir);
        }
        /// <summary>
        /// 移除一个目录
        /// </summary>
        /// <param name="dir"></param>
        public void RemoveDirtory(Dirtory dir)
        {
            Dirtories.Remove(dir);
        }
        /// <summary>
        /// 获取一个指定ID的目录
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
        /// 搜索具有指定名称的目录
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
        /// 文件集合
        /// </summary>
        public List<File> Files
        {
            get { return _files; }
            set { _files = value; }
        }
        /// <summary>
        /// 添加一个文件
        /// </summary>
        /// <param name="file"></param>
        public void AddFile(File file)
        {
            Files.Add(file);
        }
        /// <summary>
        /// 移除一个文件
        /// </summary>
        /// <param name="file"></param>
        public void Remove(File file)
        {
            Files.Remove(file);
        }
		#endregion Model

	}
}

