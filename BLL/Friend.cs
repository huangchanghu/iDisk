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
	/// 好友记录
	/// </summary>
	public partial class Friend
	{
		private readonly IFriend dal=DataAccess.CreateFriend();
		public Friend()
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
		public bool Exists(int FrOwnerId,int FrFriendId)
		{
			return dal.Exists(FrOwnerId,FrFriendId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.Friend model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.Friend model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FrOwnerId,int FrFriendId)
		{
			
			return dal.Delete(FrOwnerId,FrFriendId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hch.iDisk.Model.Friend GetModel(int FrOwnerId,int FrFriendId)
		{
			
			return dal.GetModel(FrOwnerId,FrFriendId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hch.iDisk.Model.Friend GetModelByCache(int FrOwnerId,int FrFriendId)
		{
			
			string CacheKey = "FriendModel-" + FrOwnerId+FrFriendId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FrOwnerId,FrFriendId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.Friend)objModel;
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
		public List<Hch.iDisk.Model.Friend> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hch.iDisk.Model.Friend> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.Friend> modelList = new List<Hch.iDisk.Model.Friend>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.Friend model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.Friend();
					if(dt.Rows[n]["FrOwnerId"].ToString()!="")
					{
						model.FrOwnerId=int.Parse(dt.Rows[n]["FrOwnerId"].ToString());
					}
					if(dt.Rows[n]["FrFriendId"].ToString()!="")
					{
						model.FrFriendId=int.Parse(dt.Rows[n]["FrFriendId"].ToString());
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

