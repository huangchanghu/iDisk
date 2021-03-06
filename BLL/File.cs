using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hch.iDisk.Model;
using Hch.iDisk.DALFactory;
using Hch.iDisk.IDAL;
namespace Hch.iDisk.BLL
{
	/// <summary>
	/// 上传的文件信息
	/// </summary>
	public partial class File
	{
		private readonly IFile dal=DataAccess.CreateFile();
		public File()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FId,int FUserId)
		{
			return dal.Exists(FId,FUserId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Hch.iDisk.Model.File model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hch.iDisk.Model.File model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string FId,int FUserId)
		{
			
			return dal.Delete(FId,FUserId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hch.iDisk.Model.File GetModel(string FId,int FUserId)
		{
			
			return dal.GetModel(FId,FUserId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hch.iDisk.Model.File GetModelByCache(string FId,int FUserId)
		{
			
			string CacheKey = "FileModel-" + FId+FUserId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FId,FUserId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hch.iDisk.Model.File)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hch.iDisk.Model.File> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hch.iDisk.Model.File> DataTableToList(DataTable dt)
		{
			List<Hch.iDisk.Model.File> modelList = new List<Hch.iDisk.Model.File>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hch.iDisk.Model.File model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hch.iDisk.Model.File();
					model.FId=dt.Rows[n]["FId"].ToString();
					if(dt.Rows[n]["DirId"].ToString()!="")
					{
						model.DirId=int.Parse(dt.Rows[n]["DirId"].ToString());
					}
					model.FName=dt.Rows[n]["FName"].ToString();
					if(dt.Rows[n]["FDate"].ToString()!="")
					{
						model.FDate=DateTime.Parse(dt.Rows[n]["FDate"].ToString());
					}
					if(dt.Rows[n]["FSize"].ToString()!="")
					{
						model.FSize=long.Parse(dt.Rows[n]["FSize"].ToString());
					}
					if(dt.Rows[n]["FVisibility"].ToString()!="")
					{
						model.FVisibility=int.Parse(dt.Rows[n]["FVisibility"].ToString());
					}
					if(dt.Rows[n]["FUrl"].ToString()!="")
					{
						model.FUrl=dt.Rows[n]["FUrl"].ToString();
					}
					model.FDesc=dt.Rows[n]["FDesc"].ToString();
					if(dt.Rows[n]["FUserId"].ToString()!="")
					{
						model.FUserId=int.Parse(dt.Rows[n]["FUserId"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

