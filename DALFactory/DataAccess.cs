using System;
using System.Reflection;
using System.Configuration;
using Hch.iDisk.IDAL;
namespace Hch.iDisk.DALFactory
{
	/// <summary>
	/// ���󹤳�ģʽ����DAL��
	/// web.config ��Ҫ�������ã�(���ù���ģʽ+�������+�������,ʵ�ֶ�̬������ͬ�����ݲ����ӿ�)  
	/// DataCache���ڵ���������ļ�����
	/// <appSettings>  
	/// <add key="DAL" value="Hch.iDisk.SQLServerDAL" /> (����������ռ����ʵ���������Ϊ�Լ���Ŀ�������ռ�)
	/// </appSettings> 
	/// </summary>
	public sealed class DataAccess
	{
		private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
		/// <summary>
		/// ���������ӻ����ȡ
		/// </summary>
		public static object CreateObject(string AssemblyPath,string ClassNamespace)
		{
			return 	Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//���䴴��
		}

		#region CreateSysManage
        public static Hch.iDisk.IDAL.ISysManage CreateSysManage()
        {
            //��ʽ1			
            //return (Hch.iDisk.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

            //��ʽ2 			
            string classNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (Hch.iDisk.IDAL.ISysManage)objType;
        }
		#endregion

		/// <summary>
		/// ����Admin���ݲ�ӿڡ�
		/// </summary>
		public static Hch.iDisk.IDAL.IAdmin CreateAdmin()
		{

			string ClassNamespace = AssemblyPath +".Admin";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IAdmin)objType;
		}
		/// <summary>
		/// ����Dirtory���ݲ�ӿڡ�Ŀ¼(ÿ���û�ӵ��һ����Ŀ¼
		/// </summary>
		public static Hch.iDisk.IDAL.IDirtory CreateDirtory()
		{

			string ClassNamespace = AssemblyPath +".Dirtory";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IDirtory)objType;
		}

		/// <summary>
		/// ����File���ݲ�ӿڡ��ϴ����ļ���Ϣ
		/// </summary>
		public static Hch.iDisk.IDAL.IFile CreateFile()
		{

			string ClassNamespace = AssemblyPath +".File";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFile)objType;
		}

        /// <summary>
        /// ����FileList���ݲ�ӿڡ��ϴ����ļ���Ϣ
        /// </summary>
        public static Hch.iDisk.IDAL.IFileList CreateFileList()
        {

            string ClassNamespace = AssemblyPath + ".FileList";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Hch.iDisk.IDAL.IFileList)objType;
        }


		/// <summary>
		/// ����FileServer���ݲ�ӿڡ��ļ���������Ϣ
		/// </summary>
		public static Hch.iDisk.IDAL.IFileServer CreateFileServer()
		{

			string ClassNamespace = AssemblyPath +".FileServer";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFileServer)objType;
		}


		/// <summary>
		/// ����Friend���ݲ�ӿڡ����Ѽ�¼
		/// </summary>
		public static Hch.iDisk.IDAL.IFriend CreateFriend()
		{

			string ClassNamespace = AssemblyPath +".Friend";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFriend)objType;
		}


		/// <summary>
		/// ����FriendTemp���ݲ�ӿڡ����������¼
		/// </summary>
		public static Hch.iDisk.IDAL.IFriendTemp CreateFriendTemp()
		{

			string ClassNamespace = AssemblyPath +".FriendTemp";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFriendTemp)objType;
		}


		/// <summary>
		/// ����ShareInfo���ݲ�ӿڡ��ļ�������Ϣ
		/// </summary>
		public static Hch.iDisk.IDAL.IShareInfo CreateShareInfo()
		{

			string ClassNamespace = AssemblyPath +".ShareInfo";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IShareInfo)objType;
		}


		/// <summary>
		/// ����Tag���ݲ�ӿڡ��ļ���ǩ
		/// </summary>
		public static Hch.iDisk.IDAL.ITag CreateTag()
		{

			string ClassNamespace = AssemblyPath +".Tag";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.ITag)objType;
		}


		/// <summary>
		/// ����User���ݲ�ӿڡ��û���Ϣ
		/// </summary>
		public static Hch.iDisk.IDAL.IUser CreateUser()
		{

			string ClassNamespace = AssemblyPath +".User";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IUser)objType;
		}


		/// <summary>
		/// ����FriendTempV���ݲ�ӿڡ��û���Ϣ
		/// </summary>
		public static Hch.iDisk.IDAL.IFriendTempV CreateFriendTempV()
		{

			string ClassNamespace = AssemblyPath +".FriendTempV";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFriendTempV)objType;
		}


		/// <summary>
		/// ����FriendV���ݲ�ӿڡ��û���Ϣ
		/// </summary>
		public static Hch.iDisk.IDAL.IFriendV CreateFriendV()
		{

			string ClassNamespace = AssemblyPath +".FriendV";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Hch.iDisk.IDAL.IFriendV)objType;
		}

}
}