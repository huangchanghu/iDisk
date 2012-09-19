using System;
using System.Data;
namespace Hch.iDisk.IDAL
{
	/// <summary>
	/// 接口层用户信息
	/// </summary>
	public interface IFriendTempV
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(Hch.iDisk.Model.FriendTempV model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Hch.iDisk.Model.FriendTempV model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(Hch.iDisk.Model.FriendTempV model);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Hch.iDisk.Model.FriendTempV GetModel(int senderId, int receiverId);
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
