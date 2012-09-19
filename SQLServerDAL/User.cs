using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:User
	/// </summary>
	public partial class User:IUser
	{
		public User()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UId", "[User]"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [User]");
			strSql.Append(" where UId=@UId");
			SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4)
};
			parameters[0].Value = UId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hch.iDisk.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [User](");
			strSql.Append("ULoginName,URealName,UEmail,UPassWord)");
			strSql.Append(" values (");
			strSql.Append("@ULoginName,@URealName,@UEmail,@UPassWord)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ULoginName", SqlDbType.VarChar,20),
					new SqlParameter("@URealName", SqlDbType.VarChar,20),
					new SqlParameter("@UEmail", SqlDbType.VarChar,50),
					new SqlParameter("@UPassWord", SqlDbType.VarChar,128)};
			parameters[0].Value = model.ULoginName;
			parameters[1].Value = model.URealName;
			parameters[2].Value = model.UEmail;
			parameters[3].Value = model.UPassWord;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [User] set ");
			strSql.Append("ULoginName=@ULoginName,");
			strSql.Append("URealName=@URealName,");
			strSql.Append("UEmail=@UEmail,");
			strSql.Append("UPassWord=@UPassWord");
			strSql.Append(" where UId=@UId");
			SqlParameter[] parameters = {
					new SqlParameter("@ULoginName", SqlDbType.VarChar,20),
					new SqlParameter("@URealName", SqlDbType.VarChar,20),
					new SqlParameter("@UEmail", SqlDbType.VarChar,50),
					new SqlParameter("@UPassWord", SqlDbType.VarChar,128),
					new SqlParameter("@UId", SqlDbType.Int,4)};
			parameters[0].Value = model.ULoginName;
			parameters[1].Value = model.URealName;
			parameters[2].Value = model.UEmail;
			parameters[3].Value = model.UPassWord;
			parameters[4].Value = model.UId;

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
		public bool Delete(int UId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [User] ");
			strSql.Append(" where UId=@UId");
			SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4)
};
			parameters[0].Value = UId;

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
		public bool DeleteList(string UIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [User] ");
			strSql.Append(" where UId in ("+UIdlist + ")  ");
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
		public Hch.iDisk.Model.User GetModel(int UId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UId,ULoginName,URealName,UEmail,UPassWord from [User] ");
			strSql.Append(" where UId=@UId");
			SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4)
};
			parameters[0].Value = UId;

			Hch.iDisk.Model.User model=new Hch.iDisk.Model.User();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UId"].ToString()!="")
				{
					model.UId=int.Parse(ds.Tables[0].Rows[0]["UId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ULoginName"]!=null)
				{
				model.ULoginName=ds.Tables[0].Rows[0]["ULoginName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["URealName"]!=null)
				{
				model.URealName=ds.Tables[0].Rows[0]["URealName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UEmail"]!=null)
				{
				model.UEmail=ds.Tables[0].Rows[0]["UEmail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UPassWord"]!=null)
				{
				model.UPassWord=ds.Tables[0].Rows[0]["UPassWord"].ToString();
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
			strSql.Append("select UId,ULoginName,URealName,UEmail,UPassWord ");
			strSql.Append(" FROM [User] ");
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
			strSql.Append(" UId,ULoginName,URealName,UEmail,UPassWord ");
			strSql.Append(" FROM [User] ");
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
			parameters[0].Value = "User";
			parameters[1].Value = "UId";
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

