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
	/// �ļ���ǩ
	/// </summary>
	public partial class Tag
	{
		private readonly ITag dal=DataAccess.CreateTag();
		public Tag()
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
		public bool Exists(string TName,int TUserId,int TFileId)
		{
			return dal.Exists(TName,TUserId,TFileId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Hch.iDisk.Model.Tag model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.Tag model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string TName,int TUserId,int TFileId)
		{
			
			return dal.Delete(TName,TUserId,TFileId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Hch.iDisk.Model.Tag GetModel(string TName,int TUserId,int TFileId)
		{
			
			return dal.GetModel(TName,TUserId,TFileId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Hch.iDisk.Model.Tag GetModelByCache(string TName,int TUserId,int TFileId)
		{
			
			string CacheKey = "TagModel-" + TName+TUserId+TFileId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(TName,TUserId,TFileId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.Tag)objModel;
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
		public List<Hch.iDisk.Model.Tag> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Hch.iDisk.Model.Tag> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.Tag> modelList = new List<Hch.iDisk.Model.Tag>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.Tag model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.Tag();
					model.TName=dt.Rows[n]["TName"].ToString();
					if(dt.Rows[n]["TUserId"].ToString()!="")
					{
						model.TUserId=int.Parse(dt.Rows[n]["TUserId"].ToString());
					}
					if(dt.Rows[n]["TFileId"].ToString()!="")
					{
						model.TFileId=int.Parse(dt.Rows[n]["TFileId"].ToString());
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

