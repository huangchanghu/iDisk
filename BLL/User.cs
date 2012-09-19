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
	/// 用户信息
	/// </summary>
	public partial class User
	{
		private readonly IUser dal=DataAccess.CreateUser();
		public User()
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
		public bool Exists(int UId)
		{
			return dal.Exists(UId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hch.iDisk.Model.User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.User model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UId)
		{
			
			return dal.Delete(UId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UIdlist )
		{
			return dal.DeleteList(UIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hch.iDisk.Model.User GetModel(int UId)
		{
			
			return dal.GetModel(UId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hch.iDisk.Model.User GetModelByCache(int UId)
		{
			
			string CacheKey = "UserModel-" + UId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.User)objModel;
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
		public List<Hch.iDisk.Model.User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hch.iDisk.Model.User> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.User> modelList = new List<Hch.iDisk.Model.User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.User();
					if(dt.Rows[n]["UId"].ToString()!="")
					{
						model.UId=int.Parse(dt.Rows[n]["UId"].ToString());
					}
					model.ULoginName=dt.Rows[n]["ULoginName"].ToString();
					model.URealName=dt.Rows[n]["URealName"].ToString();
					model.UEmail=dt.Rows[n]["UEmail"].ToString();
					model.UPassWord=dt.Rows[n]["UPassWord"].ToString();
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

