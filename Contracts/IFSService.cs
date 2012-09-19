using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hch.iDisk.Model;
using System.ServiceModel;

namespace Hch.iDisk.Contracts
{
    [ServiceContract(Name = "UserService", Namespace = "Hch.iDisk.WCF.Contracts")]
    public interface IFSService
    {
         [OperationContract]
        ///检测用户是否有效
        bool CheckedUser(string name, string pass);
         [OperationContract]
        ///注册新服务器
        int Register(FileServer fileServer);
         [OperationContract]
        ///更新文件服务器
         bool UpdateFileServer(FileServer fileServer);
         [OperationContract]
        ///服务登录
         FileServer Login(int id, string pass);
        [OperationContract]
        ///添加一条记录到文件列表
         bool AddFileList(FileList fileList);
        [OperationContract]
        ///删除一个用户文件
        bool DeleteFile(string fileId, string userName);
    }
}
