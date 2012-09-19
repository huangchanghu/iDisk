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
	public partial class FriendTempV
	{
		private readonly IFriendTempV dal=DataAccess.CreateFriendTempV();
		public FriendTempV()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.FriendTempV model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.FriendTempV model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Hch.iDisk.Model.FriendTempV model)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hch.iDisk.Model.FriendTempV GetModel(int senderId, int receiverId)
		{
			return dal.GetModel(senderId, receiverId);
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
		public List<Hch.iDisk.Model.FriendTempV> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hch.iDisk.Model.FriendTempV> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.FriendTempV> modelList = new List<Hch.iDisk.Model.FriendTempV>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.FriendTempV model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.FriendTempV();
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
					model.ReceiverName=dt.Rows[n]["ReceiverName"].ToString();
					model.SenderName=dt.Rows[n]["SenderName"].ToString();
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

