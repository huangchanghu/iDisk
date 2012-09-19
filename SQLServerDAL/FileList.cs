using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:FileList
	/// </summary>
	public partial class FileList:IFileList
	{
		public FileList()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ServerId", "FileList"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FileId,int ServerId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FileList");
			strSql.Append(" where FileId=@FileId and ServerId=@ServerId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileId", SqlDbType.VarChar,130),
					new SqlParameter("@ServerId", SqlDbType.Int,4)};
			parameters[0].Value = FileId;
			parameters[1].Value = ServerId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.FileList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FileList(");
			strSql.Append("FileId,ServerId)");
			strSql.Append(" values (");
			strSql.Append("@FileId,@ServerId)");
			SqlParameter[] parameters = {
					new SqlParameter("@FileId", SqlDbType.VarChar,130),
					new SqlParameter("@ServerId", SqlDbType.Int,4)};
			parameters[0].Value = model.FileId;
			parameters[1].Value = model.ServerId;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.FileList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FileList set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("FileId=@FileId,");
			strSql.Append("ServerId=@ServerId");
			strSql.Append(" where FileId=@FileId and ServerId=@ServerId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileId", SqlDbType.VarChar,130),
					new SqlParameter("@ServerId", SqlDbType.Int,4)};
			parameters[0].Value = model.FileId;
			parameters[1].Value = model.ServerId;

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
		public bool Delete(string FileId,int ServerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FileList ");
			strSql.Append(" where FileId=@FileId and ServerId=@ServerId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileId", SqlDbType.VarChar,130),
					new SqlParameter("@ServerId", SqlDbType.Int,4)};
			parameters[0].Value = FileId;
			parameters[1].Value = ServerId;

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
		public Hch.iDisk.Model.FileList GetModel(string FileId,int ServerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FileId,ServerId from FileList ");
			strSql.Append(" where FileId=@FileId and ServerId=@ServerId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileId", SqlDbType.VarChar,130),
					new SqlParameter("@ServerId", SqlDbType.Int,4)};
			parameters[0].Value = FileId;
			parameters[1].Value = ServerId;

			Hch.iDisk.Model.FileList model=new Hch.iDisk.Model.FileList();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FileId"]!=null)
				{
				model.FileId=ds.Tables[0].Rows[0]["FileId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ServerId"].ToString()!="")
				{
					model.ServerId=int.Parse(ds.Tables[0].Rows[0]["ServerId"].ToString());
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
			strSql.Append("select FileId,ServerId ");
			strSql.Append(" FROM FileList ");
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
			strSql.Append(" FileId,ServerId ");
			strSql.Append(" FROM FileList ");
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
			parameters[0].Value = "FileList";
			parameters[1].Value = "ServerId";
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

