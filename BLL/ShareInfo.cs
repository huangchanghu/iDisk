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
	/// 文件分享信息
	/// </summary>
	public partial class ShareInfo
	{
		private readonly IShareInfo dal=DataAccess.CreateShareInfo();
		public ShareInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SId)
		{
			return dal.Exists(SId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hch.iDisk.Model.ShareInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.ShareInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SId)
		{
			
			return dal.Delete(SId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SIdlist )
		{
			return dal.DeleteList(SIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hch.iDisk.Model.ShareInfo GetModel(int SId)
		{
			
			return dal.GetModel(SId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hch.iDisk.Model.ShareInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

