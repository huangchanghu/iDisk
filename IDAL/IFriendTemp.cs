using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// �ӿڲ���������¼
	/// </summary>
	public interface IFriendTemp
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int SenderId,int Receiver);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Add(Hch.iDisk.Model.FriendTemp model);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Update(Hch.iDisk.Model.FriendTemp model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete(int SenderId,int Receiver);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Hch.iDisk.Model.FriendTemp GetModel(int SenderId,int Receiver);
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
