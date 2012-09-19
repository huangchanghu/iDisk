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
	/// �ļ�������Ϣ
	/// </summary>
	public partial class ShareInfo
	{
		private readonly IShareInfo dal=DataAccess.CreateShareInfo();
		public ShareInfo()
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
		public bool Exists(int SId)
		{
			return dal.Exists(SId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Hch.iDisk.Model.ShareInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.ShareInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int SId)
		{
			
			return dal.Delete(SId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string SIdlist )
		{
			return dal.DeleteList(SIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Hch.iDisk.Model.ShareInfo GetModel(int SId)
		{
			
			return dal.GetModel(SId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Hch.iDisk.Model.ShareInfo GetModelByCache(int SId)
		{
			
			string CacheKey = "ShareInfoModel-" + SId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.ShareInfo)objModel;
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
		public List<Hch.iDisk.Model.ShareInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Hch.iDisk.Model.ShareInfo> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.ShareInfo> modelList = new List<Hch.iDisk.Model.ShareInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.ShareInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.ShareInfo();
					if(dt.Rows[n]["SId"].ToString()!="")
					{
						model.SId=int.Parse(dt.Rows[n]["SId"].ToString());
					}
					if(dt.Rows[n]["SSender"].ToString()!="")
					{
						model.SSender=int.Parse(dt.Rows[n]["SSender"].ToString());
					}
					if(dt.Rows[n]["SReceive"].ToString()!="")
					{
						model.SReceive=int.Parse(dt.Rows[n]["SReceive"].ToString());
					}
					if(dt.Rows[n]["SDate"].ToString()!="")
					{
						model.SDate=DateTime.Parse(dt.Rows[n]["SDate"].ToString());
					}
					if(dt.Rows[n]["SFileId"].ToString()!="")
					{
						model.SFileId=int.Parse(dt.Rows[n]["SFileId"].ToString());
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

