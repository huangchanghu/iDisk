using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:FileServer
	/// </summary>
	public partial class FileServer:IFileServer
	{
		public FileServer()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FSId", "FileServer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FSId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FileServer");
			strSql.Append(" where FSId=@FSId");
			SqlParameter[] parameters = {
					new SqlParameter("@FSId", SqlDbType.Int,4)
};
			parameters[0].Value = FSId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hch.iDisk.Model.FileServer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FileServer(");
			strSql.Append("FSHost,FSDirtory,FSSize,FSValidSize,FSPass)");
			strSql.Append(" values (");
			strSql.Append("@FSHost,@FSDirtory,@FSSize,@FSValidSize,@FSPass)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FSHost", SqlDbType.VarChar,100),
					new SqlParameter("@FSDirtory", SqlDbType.VarChar,50),
					new SqlParameter("@FSSize", SqlDbType.BigInt,8),
					new SqlParameter("@FSValidSize", SqlDbType.BigInt,8),
					new SqlParameter("@FSPass", SqlDbType.VarChar,130)};
			parameters[0].Value = model.FSHost;
			parameters[1].Value = model.FSDirtory;
			parameters[2].Value = model.FSSize;
			parameters[3].Value = model.FSValidSize;
			parameters[4].Value = model.FSPass;

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
		public bool Update(Hch.iDisk.Model.FileServer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FileServer set ");
			strSql.Append("FSHost=@FSHost,");
			strSql.Append("FSDirtory=@FSDirtory,");
			strSql.Append("FSSize=@FSSize,");
			strSql.Append("FSValidSize=@FSValidSize,");
			strSql.Append("FSPass=@FSPass");
			strSql.Append(" where FSId=@FSId");
			SqlParameter[] parameters = {
					new SqlParameter("@FSHost", SqlDbType.VarChar,100),
					new SqlParameter("@FSDirtory", SqlDbType.VarChar,50),
					new SqlParameter("@FSSize", SqlDbType.BigInt,8),
					new SqlParameter("@FSValidSize", SqlDbType.BigInt,8),
					new SqlParameter("@FSPass", SqlDbType.VarChar,130),
					new SqlParameter("@FSId", SqlDbType.Int,4)};
			parameters[0].Value = model.FSHost;
			parameters[1].Value = model.FSDirtory;
			parameters[2].Value = model.FSSize;
			parameters[3].Value = model.FSValidSize;
			parameters[4].Value = model.FSPass;
			parameters[5].Value = model.FSId;

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
		public bool Delete(int FSId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FileServer ");
			strSql.Append(" where FSId=@FSId");
			SqlParameter[] parameters = {
					new SqlParameter("@FSId", SqlDbType.Int,4)
};
			parameters[0].Value = FSId;

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
		public bool DeleteList(string FSIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FileServer ");
			strSql.Append(" where FSId in ("+FSIdlist + ")  ");
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
		public Hch.iDisk.Model.FileServer GetModel(int FSId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FSId,FSHost,FSDirtory,FSSize,FSValidSize,FSPass from FileServer ");
			strSql.Append(" where FSId=@FSId");
			SqlParameter[] parameters = {
					new SqlParameter("@FSId", SqlDbType.Int,4)
};
			parameters[0].Value = FSId;

			Hch.iDisk.Model.FileServer model=new Hch.iDisk.Model.FileServer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FSId"].ToString()!="")
				{
					model.FSId=int.Parse(ds.Tables[0].Rows[0]["FSId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FSHost"]!=null)
				{
				model.FSHost=ds.Tables[0].Rows[0]["FSHost"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FSDirtory"]!=null)
				{
				model.FSDirtory=ds.Tables[0].Rows[0]["FSDirtory"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FSSize"].ToString()!="")
				{
					model.FSSize=long.Parse(ds.Tables[0].Rows[0]["FSSize"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FSValidSize"].ToString()!="")
				{
					model.FSValidSize=long.Parse(ds.Tables[0].Rows[0]["FSValidSize"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FSPass"]!=null)
				{
				model.FSPass=ds.Tables[0].Rows[0]["FSPass"].ToString();
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
			strSql.Append("select FSId,FSHost,FSDirtory,FSSize,FSValidSize,FSPass ");
			strSql.Append(" FROM FileServer ");
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
			strSql.Append(" FSId,FSHost,FSDirtory,FSSize,FSValidSize,FSPass ");
			strSql.Append(" FROM FileServer ");
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
			parameters[0].Value = "FileServer";
			parameters[1].Value = "FSId";
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

