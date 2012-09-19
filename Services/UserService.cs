using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hch.iDisk.Model;

namespace Services
{
    public class UserService : Hch.iDisk.Contracts.IUserService
    {
        public Hch.iDisk.Model.User Register(Hch.iDisk.Model.User user)
        {
            //Hch.iDisk.BLL.User bll = new Hch.iDisk.BLL.User();
            //bll.Add(user);
            //Hch.iDisk.Model.User u = bll.GetModelList(string.Format("ULiginName='{0}'", user.ULoginName)).First();
            ////为用户生成主目录
            //Hch.iDisk.Model.Dirtory dir = new Hch.iDisk.Model.Dirtory();
            //dir.DirName = "主目录";
            //dir.ParentDirId = 0;
            //dir.UId = u.UId;
            //dir.DirDesc = string.Format("用户\"{0}\"的主目录。用户ID：{1}", user.ULoginName, u.UId);
            //new Hch.iDisk.BLL.Dirtory().Add(dir);
            //return u;
            throw new NotImplementedException();
        }

        public User Login(Hch.iDisk.Model.User user)
        {
            //Hch.iDisk.BLL.User bl = new Hch.iDisk.BLL.User();
            //Hch.iDisk.Model.User u = bl.GetModel(user.UId);
            //return user.UPassWord.Equals(u.UPassWord);
            throw new NotImplementedException();
        }

        public bool UserExist(Hch.iDisk.Model.User user)
        {
            //Hch.iDisk.BLL.User bl = new Hch.iDisk.BLL.User();
            //return bl.GetModelList(string.Format("ULinginName='{0}'",user.ULoginName)).Count > 0;
            throw new NotImplementedException();
        }

        public bool DeleteUser(Hch.iDisk.Model.User user)
        {
            //return new Hch.iDisk.BLL.User().Delete(user.UId);
            throw new NotImplementedException();
        }

        public bool UpdateUser(Hch.iDisk.Model.User user)
        {
           // return new Hch.iDisk.BLL.User().Update(user);
            throw new NotImplementedException();
        }

        public List<Hch.iDisk.Model.User> QueryUsers(string strWhere)
        {
          //  return new Hch.iDisk.BLL.User().GetModelList(strWhere);
            throw new NotImplementedException();
        }

        public Hch.iDisk.Model.User QueryUserById(int id)
        {
            //return new Hch.iDisk.BLL.User().GetModel(id);
            throw new NotImplementedException();
        }

        public bool AddFrientTemp(Hch.iDisk.Model.User owner, Hch.iDisk.Model.FriendTemp friendTemp)
        {
           // new Hch.iDisk.BLL.FriendTemp().Add(friendTemp);
           // return true;
            throw new NotImplementedException();
        }

        public bool DeleteFriend(Hch.iDisk.Model.User owner, Hch.iDisk.Model.User friend)
        {
            //Hch.iDisk.BLL.Friend bl = new Hch.iDisk.BLL.Friend();
            //if (bl.Delete(owner.UId, friend.UId))
            //    return bl.Delete(friend.UId, owner.UId);
            //else
            //    return false;
            throw new NotImplementedException();
        }

        public List<Hch.iDisk.Model.FriendTempV> CheckFriends(Hch.iDisk.Model.User user)
        {
          // return new Hch.iDisk.BLL.FriendTempV().GetModelList(string.Format("Receiver={0}",user.UId));
            throw new NotImplementedException();
        }

        public List<Hch.iDisk.Model.FriendTempV> CheckFriendsRefused(Hch.iDisk.Model.User user)
        {
            //Hch.iDisk.BLL.FriendTempV bl = new Hch.iDisk.BLL.FriendTempV();
            //List<Hch.iDisk.Model.FriendTempV> fts = bl.GetModelList(string.Format("SenderId={0} and Confirmed=1", user.UId));
            //fts.ForEach(e =>
            //    {
            //        bl.Delete(e);
            //    });
            //return fts;
            throw new NotImplementedException();
        }

        public void HandleFrind(Hch.iDisk.Model.User user, Hch.iDisk.Model.FriendTempV friend)
        {
            //Hch.iDisk.BLL.FriendTempV bl = new Hch.iDisk.BLL.FriendTempV();
            //if (friend.Confirmed)
            //    bl.Update(friend);
            //else
            //{
            //    Hch.iDisk.Model.Friend fr = new Hch.iDisk.Model.Friend();
            //    fr.FrOwnerId = friend.Receiver;
            //    fr.FrFriendId = friend.SenderId;
            //    new Hch.iDisk.BLL.Friend().Add(fr);
            //    bl.Delete(friend);
            //}
            throw new NotImplementedException();
        }
    }
}
