using System;
using System.Reflection;
using System.Configuration;
using Hch.iDisk.IDAL;
namespace Hch.iDisk.DALFactory
{
	/// <summary>
	/// 抽象工厂模式创建DAL。
	/// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口)  
	/// DataCache类在导出代码的文件夹里
	/// <appSettings>  
	/// <add key="DAL" value="Hch.iDisk.SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
	/// </appSettings> 
	/// </summary>
	public sealed class DataAccess
	{
		private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
		/// <summary>
		/// 创建对象或从缓存获取
		/// </summary>
		public static object CreateObject(string AssemblyPath,string ClassNamespace)
		{
			return 	Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
		}

		#region CreateSysManage
        public static Hch.iDisk.IDAL.ISysManage CreateSysManage()
        {
            //方式1			
            //return (Hch.iDisk.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

            //方式2 			
            string classNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (Hch.iDisk.IDAL.ISysManage)objType;
        }
		#endregion

		/// <summary>
		/// 创建Admin数据层接口。
		/// </summary>
		public static Hch.iDisk.IDAL.IAdmin CreateAdmin()
		{

			string ClassNamespace = AssemblyPath +".Admin";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IAdmin)objType;
		}
		/// <summary>
		/// 创建Dirtory数据层接口。目录(每个用户拥有一个主目录
		/// </summary>
		public static Hch.iDisk.IDAL.IDirtory CreateDirtory()
		{

			string ClassNamespace = AssemblyPath +".Dirtory";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IDirtory)objType;
		}

		/// <summary>
		/// 创建File数据层接口。上传的文件信息
		/// </summary>
		public static Hch.iDisk.IDAL.IFile CreateFile()
		{

			string ClassNamespace = AssemblyPath +".File";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFile)objType;
		}

        /// <summary>
        /// 创建FileList数据层接口。上传的文件信息
        /// </summary>
        public static Hch.iDisk.IDAL.IFileList CreateFileList()
        {

            string ClassNamespace = AssemblyPath + ".FileList";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Hch.iDisk.IDAL.IFileList)objType;
        }


		/// <summary>
		/// 创建FileServer数据层接口。文件服务器信息
		/// </summary>
		public static Hch.iDisk.IDAL.IFileServer CreateFileServer()
		{

			string ClassNamespace = AssemblyPath +".FileServer";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFileServer)objType;
		}


		/// <summary>
		/// 创建Friend数据层接口。好友记录
		/// </summary>
		public static Hch.iDisk.IDAL.IFriend CreateFriend()
		{

			string ClassNamespace = AssemblyPath +".Friend";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFriend)objType;
		}


		/// <summary>
		/// 创建FriendTemp数据层接口。好友申请记录
		/// </summary>
		public static Hch.iDisk.IDAL.IFriendTemp CreateFriendTemp()
		{

			string ClassNamespace = AssemblyPath +".FriendTemp";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFriendTemp)objType;
		}


		/// <summary>
		/// 创建ShareInfo数据层接口。文件分享信息
		/// </summary>
		public static Hch.iDisk.IDAL.IShareInfo CreateShareInfo()
		{

			string ClassNamespace = AssemblyPath +".ShareInfo";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IShareInfo)objType;
		}


		/// <summary>
		/// 创建Tag数据层接口。文件标签
		/// </summary>
		public static Hch.iDisk.IDAL.ITag CreateTag()
		{

			string ClassNamespace = AssemblyPath +".Tag";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.ITag)objType;
		}


		/// <summary>
		/// 创建User数据层接口。用户信息
		/// </summary>
		public static Hch.iDisk.IDAL.IUser CreateUser()
		{

			string ClassNamespace = AssemblyPath +".User";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IUser)objType;
		}


		/// <summary>
		/// 创建FriendTempV数据层接口。用户信息
		/// </summary>
		public static Hch.iDisk.IDAL.IFriendTempV CreateFriendTempV()
		{

			string ClassNamespace = AssemblyPath +".FriendTempV";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFriendTempV)objType;
		}


		/// <summary>
		/// 创建FriendV数据层接口。用户信息
		/// </summary>
		public static Hch.iDisk.IDAL.IFriendV CreateFriendV()
		{

			string ClassNamespace = AssemblyPath +".FriendV";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFriendV)objType;
		}

}
}