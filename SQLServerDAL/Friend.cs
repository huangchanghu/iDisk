using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Friend
	/// </summary>
	public partial class Friend:IFriend
	{
		public Friend()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FrOwnerId", "Friend"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FrOwnerId,int FrFriendId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Friend");
			strSql.Append(" where FrOwnerId=@FrOwnerId and FrFriendId=@FrFriendId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FrOwnerId", SqlDbType.Int,4),
					new SqlParameter("@FrFriendId", SqlDbType.Int,4)};
			parameters[0].Value = FrOwnerId;
			parameters[1].Value = FrFriendId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.Friend model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Friend(");
			strSql.Append("FrOwnerId,FrFriendId)");
			strSql.Append(" values (");
			strSql.Append("@FrOwnerId,@FrFriendId)");
			SqlParameter[] parameters = {
					new SqlParameter("@FrOwnerId", SqlDbType.Int,4),
					new SqlParameter("@FrFriendId", SqlDbType.Int,4)};
			parameters[0].Value = model.FrOwnerId;
			parameters[1].Value = model.FrFriendId;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.Friend model)
		{
//            StringBuilder strSql=new StringBuilder();
//            strSql.Append("update Friend set ");
//#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
//            strSql.Append("FrOwnerId=@FrOwnerId,");
//            strSql.Append("FrFriendId=@FrFriendId");
//            strSql.Append(" where FrOwnerId=@FrOwnerId and FrFriendId=@FrFriendId ");
//            SqlParameter[] parameters = {
//                    new SqlParameter("@FrOwnerId", SqlDbType.Int,4),
//                    new SqlParameter("@FrFriendId", SqlDbType.Int,4)};
//            parameters[0].Value = model.FrOwnerId;
//            parameters[1].Value = model.FrFriendId;

//            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
//            if (rows > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
            throw new NotImplementedException();
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FrOwnerId,int FrFriendId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Friend ");
			strSql.Append(" where FrOwnerId=@FrOwnerId and FrFriendId=@FrFriendId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FrOwnerId", SqlDbType.Int,4),
					new SqlParameter("@FrFriendId", SqlDbType.Int,4)};
			parameters[0].Value = FrOwnerId;
			parameters[1].Value = FrFriendId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hch.iDisk.Model.Friend GetModel(int FrOwnerId,int FrFriendId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FrOwnerId,FrFriendId from Friend ");
			strSql.Append(" where FrOwnerId=@FrOwnerId and FrFriendId=@FrFriendId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FrOwnerId", SqlDbType.Int,4),
					new SqlParameter("@FrFriendId", SqlDbType.Int,4)};
			parameters[0].Value = FrOwnerId;
			parameters[1].Value = FrFriendId;

			Hch.iDisk.Model.Friend model=new Hch.iDisk.Model.Friend();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FrOwnerId"].ToString()!="")
				{
					model.FrOwnerId=int.Parse(ds.Tables[0].Rows[0]["FrOwnerId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FrFriendId"].ToString()!="")
				{
					model.FrFriendId=int.Parse(ds.Tables[0].Rows[0]["FrFriendId"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FrOwnerId,FrFriendId ");
			strSql.Append(" FROM Friend ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" FrOwnerId,FrFriendId ");
			strSql.Append(" FROM Friend ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Friend";
			parameters[1].Value = "FrFriendId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

