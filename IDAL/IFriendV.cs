using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// 接口层用户信息
	/// </summary>
	public interface IFriendV
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(Hch.iDisk.Model.FriendV model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Hch.iDisk.Model.FriendV model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete();
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Hch.iDisk.Model.FriendV GetModel();
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
