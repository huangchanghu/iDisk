using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// �ӿڲ��û���Ϣ
	/// </summary>
	public interface IFriendV
	{
		#region  ��Ա����
		/// <summary>
		/// ����һ������
		/// </summary>
		void Add(Hch.iDisk.Model.FriendV model);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Update(Hch.iDisk.Model.FriendV model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete();
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Hch.iDisk.Model.FriendV GetModel();
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
