using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:FriendTemp
	/// </summary>
	public partial class FriendTemp:IFriendTemp
	{
		public FriendTemp()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SenderId", "FriendTemp"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SenderId,int Receiver)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FriendTemp");
			strSql.Append(" where SenderId=@SenderId and Receiver=@Receiver ");
			SqlParameter[] parameters = {
					new SqlParameter("@SenderId", SqlDbType.Int,4),
					new SqlParameter("@Receiver", SqlDbType.Int,4)};
			parameters[0].Value = SenderId;
			parameters[1].Value = Receiver;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.FriendTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FriendTemp(");
			strSql.Append("SenderId,Receiver,Confirmed,Message)");
			strSql.Append(" values (");
			strSql.Append("@SenderId,@Receiver,@Confirmed,@Message)");
			SqlParameter[] parameters = {
					new SqlParameter("@SenderId", SqlDbType.Int,4),
					new SqlParameter("@Receiver", SqlDbType.Int,4),
					new SqlParameter("@Confirmed", SqlDbType.Bit,1),
					new SqlParameter("@Message", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SenderId;
			parameters[1].Value = model.Receiver;
			parameters[2].Value = model.Confirmed;
			parameters[3].Value = model.Message;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.FriendTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FriendTemp set ");
			strSql.Append("Confirmed=@Confirmed,");
			strSql.Append("Message=@Message");
			strSql.Append(" where SenderId=@SenderId and Receiver=@Receiver ");
			SqlParameter[] parameters = {
					new SqlParameter("@Confirmed", SqlDbType.Bit,1),
					new SqlParameter("@Message", SqlDbType.VarChar,50),
					new SqlParameter("@SenderId", SqlDbType.Int,4),
					new SqlParameter("@Receiver", SqlDbType.Int,4)};
			parameters[0].Value = model.Confirmed;
			parameters[1].Value = model.Message;
			parameters[2].Value = model.SenderId;
			parameters[3].Value = model.Receiver;

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
		public bool Delete(int SenderId,int Receiver)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FriendTemp ");
			strSql.Append(" where SenderId=@SenderId and Receiver=@Receiver ");
			SqlParameter[] parameters = {
					new SqlParameter("@SenderId", SqlDbType.Int,4),
					new SqlParameter("@Receiver", SqlDbType.Int,4)};
			parameters[0].Value = SenderId;
			parameters[1].Value = Receiver;

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
		public Hch.iDisk.Model.FriendTemp GetModel(int SenderId,int Receiver)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SenderId,Receiver,Confirmed,Message from FriendTemp ");
			strSql.Append(" where SenderId=@SenderId and Receiver=@Receiver ");
			SqlParameter[] parameters = {
					new SqlParameter("@SenderId", SqlDbType.Int,4),
					new SqlParameter("@Receiver", SqlDbType.Int,4)};
			parameters[0].Value = SenderId;
			parameters[1].Value = Receiver;

			Hch.iDisk.Model.FriendTemp model=new Hch.iDisk.Model.FriendTemp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SenderId"].ToString()!="")
				{
					model.SenderId=int.Parse(ds.Tables[0].Rows[0]["SenderId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Receiver"].ToString()!="")
				{
					model.Receiver=int.Parse(ds.Tables[0].Rows[0]["Receiver"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Confirmed"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Confirmed"].ToString()=="1")||(ds.Tables[0].Rows[0]["Confirmed"].ToString().ToLower()=="true"))
					{
						model.Confirmed=true;
					}
					else
					{
						model.Confirmed=false;
					}
				}
				if(ds.Tables[0].Rows[0]["Message"]!=null)
				{
				model.Message=ds.Tables[0].Rows[0]["Message"].ToString();
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
			strSql.Append("select SenderId,Receiver,Confirmed,Message ");
			strSql.Append(" FROM FriendTemp ");
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
			strSql.Append(" SenderId,Receiver,Confirmed,Message ");
			strSql.Append(" FROM FriendTemp ");
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
			parameters[0].Value = "FriendTemp";
			parameters[1].Value = "Receiver";
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

