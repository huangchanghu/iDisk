using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Dirtory
	/// </summary>
	public partial class Dirtory:IDirtory
	{
		public Dirtory()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DirId", "Dirtory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DirId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Dirtory");
			strSql.Append(" where DirId=@DirId");
			SqlParameter[] parameters = {
					new SqlParameter("@DirId", SqlDbType.Int,4)
};
			parameters[0].Value = DirId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hch.iDisk.Model.Dirtory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Dirtory(");
			strSql.Append("ParentDirId,UId,DirName,DirDesc)");
			strSql.Append(" values (");
			strSql.Append("@ParentDirId,@UId,@DirName,@DirDesc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentDirId", SqlDbType.Int,4),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@DirName", SqlDbType.VarChar,50),
					new SqlParameter("@DirDesc", SqlDbType.VarChar,100)};
			parameters[0].Value = model.ParentDirId;
			parameters[1].Value = model.UId;
			parameters[2].Value = model.DirName;
			parameters[3].Value = model.DirDesc;

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
		public bool Update(Hch.iDisk.Model.Dirtory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Dirtory set ");
			strSql.Append("ParentDirId=@ParentDirId,");
			strSql.Append("UId=@UId,");
			strSql.Append("DirName=@DirName,");
			strSql.Append("DirDesc=@DirDesc");
			strSql.Append(" where DirId=@DirId");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentDirId", SqlDbType.Int,4),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@DirName", SqlDbType.VarChar,50),
					new SqlParameter("@DirDesc", SqlDbType.VarChar,100),
					new SqlParameter("@DirId", SqlDbType.Int,4)};
			parameters[0].Value = model.ParentDirId;
			parameters[1].Value = model.UId;
			parameters[2].Value = model.DirName;
			parameters[3].Value = model.DirDesc;
			parameters[4].Value = model.DirId;

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
		public bool Delete(int DirId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Dirtory ");
			strSql.Append(" where DirId=@DirId");
			SqlParameter[] parameters = {
					new SqlParameter("@DirId", SqlDbType.Int,4)
};
			parameters[0].Value = DirId;

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
		public bool DeleteList(string DirIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Dirtory ");
			strSql.Append(" where DirId in ("+DirIdlist + ")  ");
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
		public Hch.iDisk.Model.Dirtory GetModel(int DirId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DirId,ParentDirId,UId,DirName,DirDesc from Dirtory ");
			strSql.Append(" where DirId=@DirId");
			SqlParameter[] parameters = {
					new SqlParameter("@DirId", SqlDbType.Int,4)
};
			parameters[0].Value = DirId;

			Hch.iDisk.Model.Dirtory model=new Hch.iDisk.Model.Dirtory();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DirId"].ToString()!="")
				{
					model.DirId=int.Parse(ds.Tables[0].Rows[0]["DirId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ParentDirId"].ToString()!="")
				{
					model.ParentDirId=int.Parse(ds.Tables[0].Rows[0]["ParentDirId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UId"].ToString()!="")
				{
					model.UId=int.Parse(ds.Tables[0].Rows[0]["UId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DirName"]!=null)
				{
				model.DirName=ds.Tables[0].Rows[0]["DirName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DirDesc"]!=null)
				{
				model.DirDesc=ds.Tables[0].Rows[0]["DirDesc"].ToString();
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
			strSql.Append("select DirId,ParentDirId,UId,DirName,DirDesc ");
			strSql.Append(" FROM Dirtory ");
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
			strSql.Append(" DirId,ParentDirId,UId,DirName,DirDesc ");
			strSql.Append(" FROM Dirtory ");
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
			parameters[0].Value = "Dirtory";
			parameters[1].Value = "DirId";
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

