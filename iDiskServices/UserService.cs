using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hch.iDisk.Services
{
    public class UserService : Hch.iDisk.Contracts.IUserService
    {
        public Hch.iDisk.Model.User Register(Hch.iDisk.Model.User user)
        {
            Hch.iDisk.BLL.User bll = new Hch.iDisk.BLL.User();
            bll.Add(user);
            Hch.iDisk.Model.User u = bll.GetModelList(string.Format("ULoginName='{0}'", user.ULoginName)).First();
            //为用户生成主目录
            Hch.iDisk.Model.Dirtory dir = new Hch.iDisk.Model.Dirtory();
            dir.DirName = "主目录";
            dir.ParentDirId = 0;
            dir.UId = u.UId ;
            dir.DirDesc = string.Format("用户\"{0}\"的主目录。用户ID：{1}", user.ULoginName,u.UId);
            new Hch.iDisk.BLL.Dirtory().Add(dir);
            return u;
        }

        public Hch.iDisk.Model.User Login(Hch.iDisk.Model.User user)
        {
            Hch.iDisk.BLL.User bl = new Hch.iDisk.BLL.User();
            Hch.iDisk.Model.User u = bl.GetModelList(string.Format("ULoginName='{0}'",user.ULoginName)).First();
            return (u != null && user.UPassWord.Equals(u.UPassWord))?u:null;
        }

        public bool UserExist(Hch.iDisk.Model.User user)
        {
            Hch.iDisk.BLL.User bl = new Hch.iDisk.BLL.User();
            return bl.GetModelList(string.Format("ULoginName='{0}'",user.ULoginName)).Count > 0;
        }

        public bool DeleteUser(Hch.iDisk.Model.User user, Hch.iDisk.Model.User admin)
        {
            Model.Dirtory dir = new BLL.Dirtory().GetModelList(string.Format("UId={0} and ParentDirId=0", user.UId)).First();
            if (new FileService().DeleteDirtory(dir, user))
                return new Hch.iDisk.BLL.User().Delete(user.UId);
            else
                return false;
        }

        public bool UpdateUser(Hch.iDisk.Model.User user)
        {
            return new Hch.iDisk.BLL.User().Update(user);
        }

        public List<Hch.iDisk.Model.User> QueryUsers(string strWhere)
        {
            return new Hch.iDisk.BLL.User().GetModelList(strWhere);
        }

        public Hch.iDisk.Model.User QueryUserById(int id)
        {
            return new Hch.iDisk.BLL.User().GetModel(id);
        }

        public bool AddFrientTemp(Hch.iDisk.Model.User owner, Hch.iDisk.Model.FriendTemp friendTemp)
        {
            new Hch.iDisk.BLL.FriendTemp().Add(friendTemp);
            return true;
        }

        public bool DeleteFriend(Hch.iDisk.Model.User owner, Hch.iDisk.Model.User friend)
        {
            Hch.iDisk.BLL.Friend bl = new Hch.iDisk.BLL.Friend();
            if (bl.Delete(owner.UId, friend.UId))
                return bl.Delete(friend.UId, owner.UId);
            else
                return false;
        }

        public List<Hch.iDisk.Model.FriendTempV> CheckFriends(Hch.iDisk.Model.User user)
        {
            return new Hch.iDisk.BLL.FriendTempV().GetModelList(string.Format("Receiver={0}",user.UId));
        }

        public List<Hch.iDisk.Model.FriendTempV> CheckFriendsRefused(Hch.iDisk.Model.User user)
        {
            Hch.iDisk.BLL.FriendTempV bl = new Hch.iDisk.BLL.FriendTempV();
            List<Hch.iDisk.Model.FriendTempV> fts = bl.GetModelList(string.Format("SenderId={0} and Confirmed=1", user.UId));
            fts.ForEach(e =>
                {
                    bl.Delete(e);
                });
            return fts;
        }

        public void HandleFrind(Hch.iDisk.Model.User user, Hch.iDisk.Model.FriendTempV friend)
        {
            Hch.iDisk.BLL.FriendTempV bl = new Hch.iDisk.BLL.FriendTempV();
            if (friend.Confirmed)
                bl.Update(friend);
            else
            {
                Hch.iDisk.Model.Friend fr = new Hch.iDisk.Model.Friend();
                fr.FrOwnerId = friend.Receiver;
                fr.FrFriendId = friend.SenderId;
                new Hch.iDisk.BLL.Friend().Add(fr);
                bl.Delete(friend);
            }
        }

        public bool IsAdmin(Model.User user)
        {
            return new BLL.Admin().GetModel(user.UId) != null;
        }
    }
}
