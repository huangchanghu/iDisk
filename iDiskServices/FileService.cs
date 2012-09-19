using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hch.iDisk.Services
{
    public class FileService:Hch.iDisk.Contracts.IFileService
    {
        public bool AddFile(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        {
            new Hch.iDisk.BLL.File().Add(file);
            return true;
        }

        public bool DeleteFile(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        {
            return new Hch.iDisk.BLL.File().Delete(file.FId, user.UId);
        }

        public bool UpdateFile(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        {
            return new Hch.iDisk.BLL.File().Update(file);
        }

        public bool CheckFileById(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        {
            //Hch.iDisk.BLL.File bl = new Hch.iDisk.BLL.File();
            //List<Hch.iDisk.Model.File> files = bl.GetModelList("DirId=" + file.DirId);
            //if (files.Where(e =>
            //    {
            //        if (e.FId == file.FId)
            //            return true;
            //        else
            //            return false;
            //    }).Count() > 0)
            //    return true;
            //else
            //    return false;
            BLL.FileList bll = new BLL.FileList();
            return bll.GetModelList("FileId='" + file.FId + "'").Count > 0;
        }

        public bool CheckFileByName(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        {
            Hch.iDisk.BLL.File bl = new Hch.iDisk.BLL.File();
            return bl.GetModelList("DirId=" + file.DirId + " and FName='" + file.FName + "'").Count > 0;
            
        }

        public string GetUpLoadUrl(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        {
            Hch.iDisk.BLL.FileServer fs = new Hch.iDisk.BLL.FileServer();
            List<Hch.iDisk.Model.FileServer> fss = fs.GetModelList("");
            //获取剩余空间最大的服务器
            var servers = fss.OrderBy(e => { return e.FSValidSize; });//按降序排序并取结果集的第一个
            Model.FileServer server = null;
            foreach (var s in servers)
            {
                if ((s.FSSize - s.FSValidSize) > file.FSize)
                {
                    server = s;
                    break;
                }
            }
            if (server == null)
                return "0";
            return server.FSHost + "/" + server.FSDirtory;
        }

        public string GetDownLoadUrl(Model.File file, Model.User user)
        {
            Model.FileList fs = new BLL.FileList().GetModelList("FileId='" + file.FId + "'").First();
            Model.FileServer server = new BLL.FileServer().GetModel(fs.ServerId);
            return server.FSHost + "/" + server.FSDirtory;
        }

        public List<Hch.iDisk.Model.File> QueryFiles(string where, Hch.iDisk.Model.User user)
        {
            Hch.iDisk.BLL.File bl = new BLL.File();
            return bl.GetModelList("FVisibility=2 and " + where);
        }
        public List<Hch.iDisk.Model.File> QueryFilesAdmin(string where, Hch.iDisk.Model.User admin, int userId)
        {
            string str = where;
            if (userId != 0)
                str += " and FUserId=" + userId;
            Hch.iDisk.BLL.File bl = new BLL.File();
            return bl.GetModelList(str);
        }
        public Hch.iDisk.Model.File GetFile(string Id, Hch.iDisk.Model.User user)
        {
            return new BLL.File().GetModel(Id, user.UId);
        }

        public bool CheckDirtory(Hch.iDisk.Model.Dirtory dirtory, Hch.iDisk.Model.User user)
        {
            return new BLL.Dirtory().GetModelList("ParentDirId=" + dirtory.ParentDirId + " and DirName='" + dirtory.DirName + "'").Count > 0 ? true : false;
        }

        public bool AddDirtory(Hch.iDisk.Model.Dirtory dir, Hch.iDisk.Model.User user)
        {
            return new BLL.Dirtory().Add(dir) > 0;
        }

        public bool DeleteDirtory(Hch.iDisk.Model.Dirtory dir, Hch.iDisk.Model.User user)
        {
            //删除目录下的所有文件
            BLL.File fbll = new BLL.File();
            List<Model.File> files = fbll.GetModelList("DirId=" + dir.DirId);
            StringBuilder list = new StringBuilder();
            bool mark = true;
            files.ForEach(e =>
                {
                    if (!fbll.Delete(e.FId, e.FUserId))
                        mark = false;
                });
            if (!mark) return false;
            //删除所有子目录
            BLL.Dirtory dbll = new BLL.Dirtory();
            List<Model.Dirtory> dlist = dbll.GetModelList("ParentDirId=" + dir.DirId);
            list.Clear();
            dlist.ForEach(d =>
                {
                    list.Append(d.DirId + ",");
                });
            if (list.Length > 0)
            {
                list.Remove(list.Length-1,1);
                if (!dbll.DeleteList(list.ToString()))
                    return false;
            }
            //删除目录
            return dbll.Delete(dir.DirId);
        }

        public bool UpdateDirtory(Hch.iDisk.Model.Dirtory dir, Hch.iDisk.Model.User user)
        {
            return new BLL.Dirtory().Update(dir);
        }

        public Hch.iDisk.Model.Dirtory GetDirtory(Hch.iDisk.Model.User user)
        {
            Model.Dirtory dir = new BLL.Dirtory().GetModelList("UId=" + user.UId + " and ParentDirId=0").First();
            if (dir == null) return null;
            BuildDirtory(dir);
            return dir;
        }
        #region 建用户目录
        private void BuildDirtory(Model.Dirtory dir)
        {
            BLL.Dirtory bll = new BLL.Dirtory();
            List<Model.Dirtory> udirs = bll.GetModelList("UId=" + dir.UId);//获取用户的所有目录
            List<Model.File> ufiles = new BLL.File().GetModelList("FUserId=" + dir.UId);//获取用户的所有文件
            BuilDir(dir, udirs);//建立目录的层次结构
            BuilFiles(dir, ufiles);//添加目录的文件
        }
        ///构造目录层次结构
        private void BuilDir(Model.Dirtory dir, List<Model.Dirtory> dirList)
        {
            dirList.ForEach(e =>
                {
                    if (e.ParentDirId == dir.DirId)
                    {
                        BuilDir(e, dirList);
                        dir.AddDirtory(e);
                    }
                });
        }
        /// <summary>
        /// 建立目录及基子目录的文件
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="fileList"></param>
        private void BuilFiles(Model.Dirtory dir, List<Model.File> fileList)
        {
            fileList.ForEach(f =>
               {
                   if (f.DirId == dir.DirId)
                   {
                       dir.AddFile(f);
                   }
               });
            dir.Dirtories.ForEach(d =>
                {
                    BuilFiles(d, fileList);
                });
        } 
        #endregion

    }
}
