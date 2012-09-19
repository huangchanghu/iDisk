using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// �ӿڲ��ļ���������Ϣ
	/// </summary>
	public interface IFileServer
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int FSId);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Hch.iDisk.Model.FileServer model);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Update(Hch.iDisk.Model.FileServer model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete(int FSId);
		bool DeleteList(string FSIdlist );
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Hch.iDisk.Model.FileServer GetModel(int FSId);
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
