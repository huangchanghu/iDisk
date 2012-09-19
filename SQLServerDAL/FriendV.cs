using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// ���ݷ�����:FriendV
	/// </summary>
	public partial class FriendV:IFriendV
	{
		public FriendV()
		{}
		#region  Method



		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Hch.iDisk.Model.FriendV model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FriendV(");
			strSql.Append("FrOwnerId,FrFriendId,ULoginName)");
			strSql.Append(" values (");
			strSql.Append("@FrOwnerId,@FrFriendId,@ULoginName)");
			SqlParameter[] parameters = {
					new SqlParameter("@FrOwnerId", SqlDbType.Int,4),
					new SqlParameter("@FrFriendId", SqlDbType.Int,4),
					new SqlParameter("@ULoginName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.FrOwnerId;
			parameters[1].Value = model.FrFriendId;
			parameters[2].Value = model.ULoginName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.FriendV model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FriendV set ");
			strSql.Append("FrOwnerId=@FrOwnerId,");
			strSql.Append("FrFriendId=@FrFriendId,");
			strSql.Append("ULoginName=@ULoginName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@FrOwnerId", SqlDbType.Int,4),
					new SqlParameter("@FrFriendId", SqlDbType.Int,4),
					new SqlParameter("@ULoginName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.FrOwnerId;
			parameters[1].Value = model.FrFriendId;
			parameters[2].Value = model.ULoginName;

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
		public bool Delete()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FriendV ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

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
		public Hch.iDisk.Model.FriendV GetModel()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FrOwnerId,FrFriendId,ULoginName from FriendV ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			Hch.iDisk.Model.FriendV model=new Hch.iDisk.Model.FriendV();
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
				if(ds.Tables[0].Rows[0]["ULoginName"]!=null)
				{
				model.ULoginName=ds.Tables[0].Rows[0]["ULoginName"].ToString();
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
			strSql.Append("select FrOwnerId,FrFriendId,ULoginName ");
			strSql.Append(" FROM FriendV ");
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
			strSql.Append(" FrOwnerId,FrFriendId,ULoginName ");
			strSql.Append(" FROM FriendV ");
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
			parameters[0].Value = "FriendV";
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

