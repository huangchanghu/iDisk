using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// 接口层文件标签
	/// </summary>
	public interface ITag
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string TName,int TUserId,int TFileId);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(Hch.iDisk.Model.Tag model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Hch.iDisk.Model.Tag model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string TName,int TUserId,int TFileId);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Hch.iDisk.Model.Tag GetModel(string TName,int TUserId,int TFileId);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
	} 
}
