using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// ���ݷ�����:Friend
	/// </summary>
	public partial class Friend:IFriend
	{
		public Friend()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FrOwnerId", "Friend"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
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
		/// ����һ������
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
		/// ����һ������
		/// </summary>
		public bool Update(Hch.iDisk.Model.Friend model)
		{
//            StringBuilder strSql=new StringBuilder();
//            strSql.Append("update Friend set ");
//#warning ϵͳ����ȱ�ٸ��µ��ֶΣ����ֹ�ȷ����˸����Ƿ���ȷ�� 
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
		/// ɾ��һ������
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
		/// �õ�һ������ʵ��
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
		/// ��������б�
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

