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
	/// ���Ѽ�¼
	/// </summary>
	public partial class Friend
	{
		private readonly IFriend dal=DataAccess.CreateFriend();
		public Friend()
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
		public bool Exists(int FrOwnerId,int FrFriendId)
		{
			return dal.Exists(FrOwnerId,FrFriendId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Hch.iDisk.Model.Friend model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.Friend model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int FrOwnerId,int FrFriendId)
		{
			
			return dal.Delete(FrOwnerId,FrFriendId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Hch.iDisk.Model.Friend GetModel(int FrOwnerId,int FrFriendId)
		{
			
			return dal.GetModel(FrOwnerId,FrFriendId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
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
		public List<Hch.iDisk.Model.Friend> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

