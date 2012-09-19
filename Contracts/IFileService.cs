using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hch.iDisk.Model;
using System.ServiceModel;

namespace Hch.iDisk.Contracts
{
     [ServiceContract(Name = "FileService", Namespace = "Hch.iDisk.WCF.Contracts")]
    /// <summary>
    /// 文件和目录服务契约，提供文件和目录的相关操作
    /// </summary>
    public interface IFileService
    {
        #region 文件操作
         [OperationContract]
        ///添加文件
        bool AddFile(File file, User user);
         [OperationContract]
        ///删除文件
        bool DeleteFile(File file, User user);
         [OperationContract]
        ///更新文件
        bool UpdateFile(File file, User user);
         [OperationContract]
        ///检查文件在服务器上是否已存在
        bool CheckFileById(File file, User user);
         [OperationContract]
        ///检查文件是否重名
        bool CheckFileByName(File file, User user);
         [OperationContract]
        ///获取文件的上载路径
        string GetUpLoadUrl(File file, User user);
         [OperationContract]
         ///获取文件的下载路径
         string GetDownLoadUrl(Model.File file, Model.User user);
         [OperationContract]
        ///查询文件
        List<File> QueryFiles(string where, User user);
         [OperationContract]
         ///查询文件(管理员),若userId=0则查所有用户的文件
         List<File> QueryFilesAdmin(string where, User user, int userId);
         [OperationContract]
        ///获取指定id的文件
        File GetFile(string Id, User user);
        #endregion
        
        #region 目录操作
        ///检查目录是否重名
        bool CheckDirtory(Dirtory dirtory, User user);
         [OperationContract]
        ///添加一个目录
        bool AddDirtory(Dirtory dir, User user);
         [OperationContract]
        ///删除一个目录
        bool DeleteDirtory(Dirtory dir, User user);
         [OperationContract]
        ///更新目录
        bool UpdateDirtory(Dirtory dir, User user);
         [OperationContract]
        ///获取用户主目录
        Dirtory GetDirtory(User user);
        #endregion
    }
}
