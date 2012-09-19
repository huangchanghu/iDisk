using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Admin
	/// </summary>
	public partial class Admin:IAdmin
	{
		public Admin()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UserId", "Admin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Admin");
			strSql.Append(" where UserId=@UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)};
			parameters[0].Value = UserId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Admin(");
			strSql.Append("UserId)");
			strSql.Append(" values (");
			strSql.Append("@UserId)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Admin set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("UserId=@UserId");
			strSql.Append(" where UserId=@UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Admin ");
			strSql.Append(" where UserId=@UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)};
			parameters[0].Value = UserId;

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
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Admin ");
			strSql.Append(" where UserId in ("+UserIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Hch.iDisk.Model.Admin GetModel(int UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserId from Admin ");
			strSql.Append(" where UserId=@UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)};
			parameters[0].Value = UserId;

			Hch.iDisk.Model.Admin model=new Hch.iDisk.Model.Admin();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
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
			strSql.Append("select UserId ");
			strSql.Append(" FROM Admin ");
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
			strSql.Append(" UserId ");
			strSql.Append(" FROM Admin ");
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
			parameters[0].Value = "Admin";
			parameters[1].Value = "UserId";
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

