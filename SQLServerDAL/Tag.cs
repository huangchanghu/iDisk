using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// ���ݷ�����:Tag
	/// </summary>
	public partial class Tag:ITag
	{
		public Tag()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TUserId", "Tag"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string TName,int TUserId,int TFileId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tag");
			strSql.Append(" where TName=@TName and TUserId=@TUserId and TFileId=@TFileId ");
			SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.VarChar,20),
					new SqlParameter("@TUserId", SqlDbType.Int,4),
					new SqlParameter("@TFileId", SqlDbType.Int,4)};
			parameters[0].Value = TName;
			parameters[1].Value = TUserId;
			parameters[2].Value = TFileId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Hch.iDisk.Model.Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tag(");
			strSql.Append("TName,TUserId,TFileId)");
			strSql.Append(" values (");
			strSql.Append("@TName,@TUserId,@TFileId)");
			SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.VarChar,20),
					new SqlParameter("@TUserId", SqlDbType.Int,4),
					new SqlParameter("@TFileId", SqlDbType.Int,4)};
			parameters[0].Value = model.TName;
			parameters[1].Value = model.TUserId;
			parameters[2].Value = model.TFileId;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tag set ");
#warning ϵͳ����ȱ�ٸ��µ��ֶΣ����ֹ�ȷ����˸����Ƿ���ȷ�� 
			strSql.Append("TName=@TName,");
			strSql.Append("TUserId=@TUserId,");
			strSql.Append("TFileId=@TFileId");
			strSql.Append(" where TName=@TName and TUserId=@TUserId and TFileId=@TFileId ");
			SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.VarChar,20),
					new SqlParameter("@TUserId", SqlDbType.Int,4),
					new SqlParameter("@TFileId", SqlDbType.Int,4)};
			parameters[0].Value = model.TName;
			parameters[1].Value = model.TUserId;
			parameters[2].Value = model.TFileId;

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
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string TName,int TUserId,int TFileId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tag ");
			strSql.Append(" where TName=@TName and TUserId=@TUserId and TFileId=@TFileId ");
			SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.VarChar,20),
					new SqlParameter("@TUserId", SqlDbType.Int,4),
					new SqlParameter("@TFileId", SqlDbType.Int,4)};
			parameters[0].Value = TName;
			parameters[1].Value = TUserId;
			parameters[2].Value = TFileId;

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
		/// �õ�һ������ʵ��
		/// </summary>
		public Hch.iDisk.Model.Tag GetModel(string TName,int TUserId,int TFileId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TName,TUserId,TFileId from Tag ");
			strSql.Append(" where TName=@TName and TUserId=@TUserId and TFileId=@TFileId ");
			SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.VarChar,20),
					new SqlParameter("@TUserId", SqlDbType.Int,4),
					new SqlParameter("@TFileId", SqlDbType.Int,4)};
			parameters[0].Value = TName;
			parameters[1].Value = TUserId;
			parameters[2].Value = TFileId;

			Hch.iDisk.Model.Tag model=new Hch.iDisk.Model.Tag();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TName"]!=null)
				{
				model.TName=ds.Tables[0].Rows[0]["TName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TUserId"].ToString()!="")
				{
					model.TUserId=int.Parse(ds.Tables[0].Rows[0]["TUserId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TFileId"].ToString()!="")
				{
					model.TFileId=int.Parse(ds.Tables[0].Rows[0]["TFileId"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TName,TUserId,TFileId ");
			strSql.Append(" FROM Tag ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" TName,TUserId,TFileId ");
			strSql.Append(" FROM Tag ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "Tag";
			parameters[1].Value = "TFileId";
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

