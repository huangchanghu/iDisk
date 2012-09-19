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
	/// 目录(每个用户拥有一个主目录
	/// </summary>
	public partial class Dirtory
	{
		private readonly IDirtory dal=DataAccess.CreateDirtory();
		public Dirtory()
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
		public bool Exists(int DirId)
		{
			return dal.Exists(DirId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hch.iDisk.Model.Dirtory model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.Dirtory model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DirId)
		{
			
			return dal.Delete(DirId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DirIdlist )
		{
			return dal.DeleteList(DirIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hch.iDisk.Model.Dirtory GetModel(int DirId)
		{
			
			return dal.GetModel(DirId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hch.iDisk.Model.Dirtory GetModelByCache(int DirId)
		{
			
			string CacheKey = "DirtoryModel-" + DirId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DirId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.Dirtory)objModel;
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
		public List<Hch.iDisk.Model.Dirtory> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hch.iDisk.Model.Dirtory> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.Dirtory> modelList = new List<Hch.iDisk.Model.Dirtory>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.Dirtory model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.Dirtory();
					if(dt.Rows[n]["DirId"].ToString()!="")
					{
						model.DirId=int.Parse(dt.Rows[n]["DirId"].ToString());
					}
					if(dt.Rows[n]["ParentDirId"].ToString()!="")
					{
						model.ParentDirId=int.Parse(dt.Rows[n]["ParentDirId"].ToString());
					}
					if(dt.Rows[n]["UId"].ToString()!="")
					{
						model.UId=int.Parse(dt.Rows[n]["UId"].ToString());
					}
					model.DirName=dt.Rows[n]["DirName"].ToString();
					model.DirDesc=dt.Rows[n]["DirDesc"].ToString();
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

