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
	/// �ļ���������Ϣ
	/// </summary>
	public partial class FileServer
	{
		private readonly IFileServer dal=DataAccess.CreateFileServer();
		public FileServer()
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
		public bool Exists(int FSId)
		{
			return dal.Exists(FSId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Hch.iDisk.Model.FileServer model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.FileServer model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int FSId)
		{
			
			return dal.Delete(FSId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string FSIdlist )
		{
			return dal.DeleteList(FSIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Hch.iDisk.Model.FileServer GetModel(int FSId)
		{
			
			return dal.GetModel(FSId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Hch.iDisk.Model.FileServer GetModelByCache(int FSId)
		{
			
			string CacheKey = "FileServerModel-" + FSId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FSId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.FileServer)objModel;
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
		public List<Hch.iDisk.Model.FileServer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Hch.iDisk.Model.FileServer> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.FileServer> modelList = new List<Hch.iDisk.Model.FileServer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.FileServer model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.FileServer();
					if(dt.Rows[n]["FSId"].ToString()!="")
					{
						model.FSId=int.Parse(dt.Rows[n]["FSId"].ToString());
					}
					model.FSHost=dt.Rows[n]["FSHost"].ToString();
					model.FSDirtory=dt.Rows[n]["FSDirtory"].ToString();
					if(dt.Rows[n]["FSSize"].ToString()!="")
					{
						model.FSSize=long.Parse(dt.Rows[n]["FSSize"].ToString());
					}
					if(dt.Rows[n]["FSValidSize"].ToString()!="")
					{
						model.FSValidSize=long.Parse(dt.Rows[n]["FSValidSize"].ToString());
					}
					model.FSPass=dt.Rows[n]["FSPass"].ToString();
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

