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
	public partial class FriendTempV
	{
		private readonly IFriendTempV dal=DataAccess.CreateFriendTempV();
		public FriendTempV()
		{}
		#region  Method

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Hch.iDisk.Model.FriendTempV model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.FriendTempV model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(Hch.iDisk.Model.FriendTempV model)
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.Delete(model);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Hch.iDisk.Model.FriendTempV GetModel(int senderId, int receiverId)
		{
			return dal.GetModel(senderId, receiverId);
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
		public List<Hch.iDisk.Model.FriendTempV> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

