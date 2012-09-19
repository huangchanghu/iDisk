using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// 接口层文件分享信息
	/// </summary>
	public interface IShareInfo
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int SId);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Hch.iDisk.Model.ShareInfo model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Hch.iDisk.Model.ShareInfo model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int SId);
		bool DeleteList(string SIdlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Hch.iDisk.Model.ShareInfo GetModel(int SId);
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
