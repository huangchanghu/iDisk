using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Hch.iDisk.Model;

namespace Hch.iDisk.Contracts
{
    [ServiceContract(Name = "UserService", Namespace = "Hch.iDisk.WCF.Contracts")]
    /// <summary>
    /// 用户服务契约，提供与用户相关的操作
    /// </summary>
    public interface IUserService
    {
       [OperationContract]
        /// 用户注册
        User Register(User user);
        [OperationContract]
        /// 用户登录
        User Login(User user);
        [OperationContract]
        /// 检查用户是否存在
        bool UserExist(User user);
        [OperationContract]
        ///删除用户，管理员才拥有此权限
        bool DeleteUser(User user, User admin);
        [OperationContract]
        ///更新用户信息
        bool UpdateUser(User user);
        [OperationContract]
        ///查询用户，返回符合条件的所有用户
        List<User> QueryUsers(string strWhere);
        [OperationContract]
        ///按id查询用户
        User QueryUserById(int id);
        [OperationContract]
        ///添加用户
        bool AddFrientTemp(User owner, FriendTemp friendTemp);
        [OperationContract]
        ///删除用户
        bool DeleteFriend(User owner, User friend);
        [OperationContract]
        ///检查是否有好友请求
        List<Hch.iDisk.Model.FriendTempV> CheckFriends(User user);
        [OperationContract]
        ///检查是否有好友拒绝信息
        List<Hch.iDisk.Model.FriendTempV> CheckFriendsRefused(User user);
        [OperationContract]
        ///处理好友请求
        void HandleFrind(User user, FriendTempV friend);
        [OperationContract]
        ///判断用户是否管理员
        bool IsAdmin(User user);
    }
}
