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
	/// Admin
	/// </summary>
	public partial class Admin
	{
		private readonly IAdmin dal=DataAccess.CreateAdmin();
		public Admin()
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
		public bool Exists(int UserId)
		{
			return dal.Exists(UserId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.Admin model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.Admin model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserId)
		{
			
			return dal.Delete(UserId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIdlist )
		{
			return dal.DeleteList(UserIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hch.iDisk.Model.Admin GetModel(int UserId)
		{
			
			return dal.GetModel(UserId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hch.iDisk.Model.Admin GetModelByCache(int UserId)
		{
			
			string CacheKey = "AdminModel-" + UserId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.Admin)objModel;
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
		public List<Hch.iDisk.Model.Admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hch.iDisk.Model.Admin> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.Admin> modelList = new List<Hch.iDisk.Model.Admin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.Admin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.Admin();
					if(dt.Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
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

