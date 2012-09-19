using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hch.iDisk.Model;
using Hch.iDisk.DALFactory;
using Hch.iDisk.IDAL;
namespace Hch.iDisk.BLL
{
	/// <summary>
	/// �ϴ����ļ���Ϣ
	/// </summary>
	public partial class FileList
	{
		private readonly IFileList dal=DataAccess.CreateFileList();
		public FileList()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string FileId,int ServerId)
		{
			return dal.Exists(FileId,ServerId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Hch.iDisk.Model.FileList model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.FileList model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string FileId,int ServerId)
		{
			
			return dal.Delete(FileId,ServerId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Hch.iDisk.Model.FileList GetModel(string FileId,int ServerId)
		{
			
			return dal.GetModel(FileId,ServerId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Hch.iDisk.Model.FileList GetModelByCache(string FileId,int ServerId)
		{
			
			string CacheKey = "FileListModel-" + FileId+ServerId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FileId,ServerId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.FileList)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Hch.iDisk.Model.FileList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Hch.iDisk.Model.FileList> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.FileList> modelList = new List<Hch.iDisk.Model.FileList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.FileList model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.FileList();
					model.FileId=dt.Rows[n]["FileId"].ToString();
					if(dt.Rows[n]["ServerId"].ToString()!="")
					{
						model.ServerId=int.Parse(dt.Rows[n]["ServerId"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

