using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:ShareInfo
	/// </summary>
	public partial class ShareInfo:IShareInfo
	{
		public ShareInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SId", "ShareInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ShareInfo");
			strSql.Append(" where SId=@SId");
			SqlParameter[] parameters = {
					new SqlParameter("@SId", SqlDbType.Int,4)
};
			parameters[0].Value = SId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hch.iDisk.Model.ShareInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ShareInfo(");
			strSql.Append("SSender,SReceive,SDate,SFileId)");
			strSql.Append(" values (");
			strSql.Append("@SSender,@SReceive,@SDate,@SFileId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SSender", SqlDbType.Int,4),
					new SqlParameter("@SReceive", SqlDbType.Int,4),
					new SqlParameter("@SDate", SqlDbType.DateTime),
					new SqlParameter("@SFileId", SqlDbType.Int,4)};
			parameters[0].Value = model.SSender;
			parameters[1].Value = model.SReceive;
			parameters[2].Value = model.SDate;
			parameters[3].Value = model.SFileId;

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
		public bool Update(Hch.iDisk.Model.ShareInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ShareInfo set ");
			strSql.Append("SSender=@SSender,");
			strSql.Append("SReceive=@SReceive,");
			strSql.Append("SDate=@SDate,");
			strSql.Append("SFileId=@SFileId");
			strSql.Append(" where SId=@SId");
			SqlParameter[] parameters = {
					new SqlParameter("@SSender", SqlDbType.Int,4),
					new SqlParameter("@SReceive", SqlDbType.Int,4),
					new SqlParameter("@SDate", SqlDbType.DateTime),
					new SqlParameter("@SFileId", SqlDbType.Int,4),
					new SqlParameter("@SId", SqlDbType.Int,4)};
			parameters[0].Value = model.SSender;
			parameters[1].Value = model.SReceive;
			parameters[2].Value = model.SDate;
			parameters[3].Value = model.SFileId;
			parameters[4].Value = model.SId;

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
		public bool Delete(int SId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ShareInfo ");
			strSql.Append(" where SId=@SId");
			SqlParameter[] parameters = {
					new SqlParameter("@SId", SqlDbType.Int,4)
};
			parameters[0].Value = SId;

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
		public bool DeleteList(string SIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ShareInfo ");
			strSql.Append(" where SId in ("+SIdlist + ")  ");
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
		public Hch.iDisk.Model.ShareInfo GetModel(int SId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SId,SSender,SReceive,SDate,SFileId from ShareInfo ");
			strSql.Append(" where SId=@SId");
			SqlParameter[] parameters = {
					new SqlParameter("@SId", SqlDbType.Int,4)
};
			parameters[0].Value = SId;

			Hch.iDisk.Model.ShareInfo model=new Hch.iDisk.Model.ShareInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SId"].ToString()!="")
				{
					model.SId=int.Parse(ds.Tables[0].Rows[0]["SId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SSender"].ToString()!="")
				{
					model.SSender=int.Parse(ds.Tables[0].Rows[0]["SSender"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SReceive"].ToString()!="")
				{
					model.SReceive=int.Parse(ds.Tables[0].Rows[0]["SReceive"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SDate"].ToString()!="")
				{
					model.SDate=DateTime.Parse(ds.Tables[0].Rows[0]["SDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SFileId"].ToString()!="")
				{
					model.SFileId=int.Parse(ds.Tables[0].Rows[0]["SFileId"].ToString());
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
			strSql.Append("select SId,SSender,SReceive,SDate,SFileId ");
			strSql.Append(" FROM ShareInfo ");
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
			strSql.Append(" SId,SSender,SReceive,SDate,SFileId ");
			strSql.Append(" FROM ShareInfo ");
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
			parameters[0].Value = "ShareInfo";
			parameters[1].Value = "SId";
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

