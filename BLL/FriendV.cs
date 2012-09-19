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
	/// �û���Ϣ
	/// </summary>
	public partial class FriendV
	{
		private readonly IFriendV dal=DataAccess.CreateFriendV();
		public FriendV()
		{}
		#region  Method

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Hch.iDisk.Model.FriendV model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.FriendV model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.Delete();
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Hch.iDisk.Model.FriendV GetModel()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.GetModel();
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Hch.iDisk.Model.FriendV GetModelByCache()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			string CacheKey = "FriendVModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.FriendV)objModel;
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
		public List<Hch.iDisk.Model.FriendV> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Hch.iDisk.Model.FriendV> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.FriendV> modelList = new List<Hch.iDisk.Model.FriendV>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.FriendV model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.FriendV();
					if(dt.Rows[n]["FrOwnerId"].ToString()!="")
					{
						model.FrOwnerId=int.Parse(dt.Rows[n]["FrOwnerId"].ToString());
					}
					if(dt.Rows[n]["FrFriendId"].ToString()!="")
					{
						model.FrFriendId=int.Parse(dt.Rows[n]["FrFriendId"].ToString());
					}
					model.ULoginName=dt.Rows[n]["ULoginName"].ToString();
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

