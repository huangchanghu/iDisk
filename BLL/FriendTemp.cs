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
	/// 好友申请记录
	/// </summary>
	public partial class FriendTemp
	{
		private readonly IFriendTemp dal=DataAccess.CreateFriendTemp();
		public FriendTemp()
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
		public bool Exists(int SenderId,int Receiver)
		{
			return dal.Exists(SenderId,Receiver);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.FriendTemp model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.FriendTemp model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SenderId,int Receiver)
		{
			
			return dal.Delete(SenderId,Receiver);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hch.iDisk.Model.FriendTemp GetModel(int SenderId,int Receiver)
		{
			
			return dal.GetModel(SenderId,Receiver);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hch.iDisk.Model.FriendTemp GetModelByCache(int SenderId,int Receiver)
		{
			
			string CacheKey = "FriendTempModel-" + SenderId+Receiver;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SenderId,Receiver);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.FriendTemp)objModel;
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
		public List<Hch.iDisk.Model.FriendTemp> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hch.iDisk.Model.FriendTemp> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.FriendTemp> modelList = new List<Hch.iDisk.Model.FriendTemp>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.FriendTemp model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.FriendTemp();
					if(dt.Rows[n]["SenderId"].ToString()!="")
					{
						model.SenderId=int.Parse(dt.Rows[n]["SenderId"].ToString());
					}
					if(dt.Rows[n]["Receiver"].ToString()!="")
					{
						model.Receiver=int.Parse(dt.Rows[n]["Receiver"].ToString());
					}
					if(dt.Rows[n]["Confirmed"].ToString()!="")
					{
						if((dt.Rows[n]["Confirmed"].ToString()=="1")||(dt.Rows[n]["Confirmed"].ToString().ToLower()=="true"))
						{
						model.Confirmed=true;
						}
						else
						{
							model.Confirmed=false;
						}
					}
					model.Message=dt.Rows[n]["Message"].ToString();
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

