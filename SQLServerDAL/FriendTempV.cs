using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Hch.iDisk.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace Hch.iDisk.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:FriendTempV
	/// </summary>
	public partial class FriendTempV:IFriendTempV
	{
		public FriendTempV()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.FriendTempV model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FriendTempV(");
			strSql.Append("SenderId,Receiver,Confirmed,Message,ReceiverName,SenderName)");
			strSql.Append(" values (");
			strSql.Append("@SenderId,@Receiver,@Confirmed,@Message,@ReceiverName,@SenderName)");
			SqlParameter[] parameters = {
					new SqlParameter("@SenderId", SqlDbType.Int,4),
					new SqlParameter("@Receiver", SqlDbType.Int,4),
					new SqlParameter("@Confirmed", SqlDbType.Bit,1),
					new SqlParameter("@Message", SqlDbType.VarChar,50),
					new SqlParameter("@ReceiverName", SqlDbType.VarChar,20),
					new SqlParameter("@SenderName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.SenderId;
			parameters[1].Value = model.Receiver;
			parameters[2].Value = model.Confirmed;
			parameters[3].Value = model.Message;
			parameters[4].Value = model.ReceiverName;
			parameters[5].Value = model.SenderName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.FriendTempV model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FriendTempV set ");
			strSql.Append("SenderId=@SenderId,");
			strSql.Append("Receiver=@Receiver,");
			strSql.Append("Confirmed=@Confirmed,");
			strSql.Append("Message=@Message,");
			strSql.Append("ReceiverName=@ReceiverName,");
			strSql.Append("SenderName=@SenderName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@SenderId", SqlDbType.Int,4),
					new SqlParameter("@Receiver", SqlDbType.Int,4),
					new SqlParameter("@Confirmed", SqlDbType.Bit,1),
					new SqlParameter("@Message", SqlDbType.VarChar,50),
					new SqlParameter("@ReceiverName", SqlDbType.VarChar,20),
					new SqlParameter("@SenderName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.SenderId;
			parameters[1].Value = model.Receiver;
			parameters[2].Value = model.Confirmed;
			parameters[3].Value = model.Message;
			parameters[4].Value = model.ReceiverName;
			parameters[5].Value = model.SenderName;

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
		public bool Delete(Hch.iDisk.Model.FriendTempV model)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FriendTempV ");
			strSql.Append(" where SenderId=@SenderId and Receiver=@Receiver");
			SqlParameter[] parameters = {
											 new SqlParameter("@SenderId", SqlDbType.Int, 4),
											new SqlParameter("@Receiver", SqlDbType.Int, 4)};
			parameters[0].Value = model.SenderId;
			parameters[1].Value = model.Receiver;
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
		public Hch.iDisk.Model.FriendTempV GetModel(int senderId, int receiverId)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SenderId,Receiver,Confirmed,Message,ReceiverName,SenderName from FriendTempV ");
            strSql.Append(" where SenderId=@SenderId and Receiver=@Receiver");
            SqlParameter[] parameters = {new SqlParameter("@SenderId", SqlDbType.Int, 4),
											new SqlParameter("@Receiver", SqlDbType.Int, 4)};
            parameters[0].Value = senderId;
            parameters[1].Value = receiverId;
			Hch.iDisk.Model.FriendTempV model=new Hch.iDisk.Model.FriendTempV();
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
				if(ds.Tables[0].Rows[0]["ReceiverName"]!=null)
				{
				model.ReceiverName=ds.Tables[0].Rows[0]["ReceiverName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SenderName"]!=null)
				{
				model.SenderName=ds.Tables[0].Rows[0]["SenderName"].ToString();
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
			strSql.Append("select SenderId,Receiver,Confirmed,Message,ReceiverName,SenderName ");
			strSql.Append(" FROM FriendTempV ");
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
			strSql.Append(" SenderId,Receiver,Confirmed,Message,ReceiverName,SenderName ");
			strSql.Append(" FROM FriendTempV ");
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
			parameters[0].Value = "FriendTempV";
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

