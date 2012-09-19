using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// �ӿڲ�Admin
	/// </summary>
	public interface IAdmin
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int UserId);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Add(Hch.iDisk.Model.Admin model);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Update(Hch.iDisk.Model.Admin model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete(int UserId);
		bool DeleteList(string UserIdlist );
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Hch.iDisk.Model.Admin GetModel(int UserId);
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
