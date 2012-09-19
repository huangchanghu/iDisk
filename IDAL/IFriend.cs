using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// �ӿڲ���Ѽ�¼
	/// </summary>
	public interface IFriend
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int FrOwnerId,int FrFriendId);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Add(Hch.iDisk.Model.Friend model);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Update(Hch.iDisk.Model.Friend model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete(int FrOwnerId,int FrFriendId);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Hch.iDisk.Model.Friend GetModel(int FrOwnerId,int FrFriendId);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	} 
}
