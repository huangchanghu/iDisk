using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hch.iDisk;

namespace Hch.iDisk.Services
{
    public class FSService:Hch.iDisk.Contracts.IFSService
    {
        public bool CheckedUser(string name, string pass)
        {
            try
            {
                return new BLL.User().GetModelList(string.Format("ULoginName='{0}' and UPassWord='{1}'", name, pass)).Count > 0;
            }
            catch 
            {
                return false;
            }
        }

        public int Register(Model.FileServer fileServer)
        {
            //try
            //{
                BLL.FileServer fs = new BLL.FileServer();
                fs.Add(fileServer);
                Model.FileServer model = fs.GetModelList("FSHost='" + fileServer.FSHost + "'").First();
                if (model == null)
                    return 0;
                else
                    return model.FSId;
            //}
            //catch
            //{
            //    return 0;
            //}
        }

        public bool UpdateFileServer(Model.FileServer fileServer)
        {
            try
            {
                return new BLL.FileServer().Update(fileServer);
            }
            catch 
            {
                return false;
            }
        }

        public Model.FileServer Login(int id, string pass)
        {
            try
            {
                return new BLL.FileServer().GetModelList("FSId=" + id + " and FSPass='" + pass + "'").First();
            }
            catch 
            {
                return null;
            }
        }

        public bool AddFileList(Model.FileList fileList)
        {
            try
            {
                new BLL.FileList().Add(fileList);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteFile(string fileId, string userName)
        {
            try
            {
                BLL.File bll = new BLL.File();
                Model.User user = new BLL.User().GetModelList("ULoginName='" + userName + "'").First(); ;
                return bll.Delete(fileId, user.UId);
            }
            catch
            {
                return false;
            }
        }
    }
}
