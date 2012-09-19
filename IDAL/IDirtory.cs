using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// �ӿڲ�Ŀ¼(ÿ���û�ӵ��һ����Ŀ¼
	/// </summary>
	public interface IDirtory
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int DirId);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Hch.iDisk.Model.Dirtory model);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Update(Hch.iDisk.Model.Dirtory model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete(int DirId);
		bool DeleteList(string DirIdlist );
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Hch.iDisk.Model.Dirtory GetModel(int DirId);
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
