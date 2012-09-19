using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class FileService//:Hch.iDisk.Contracts.IFileService
    {
        //public bool AddFile(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        //{
        //    new Hch.iDisk.BLL.File().Add(file);
        //    return true;
        //}

        //public bool DeleteFile(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        //{
        //    return new Hch.iDisk.BLL.File().Delete(file.FId);
        //}

        //public bool UpdateFile(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        //{
        //    return new Hch.iDisk.BLL.File().Update(file);
        //}

        //public bool CheckFileById(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        //{
        //    Hch.iDisk.BLL.File bl = new Hch.iDisk.BLL.File();
        //    List<Hch.iDisk.Model.File> files = bl.GetModelList("DirId=" + file.DirId);
        //    if (files.Where(e =>
        //        {
        //            if (e.FId == file.FId)
        //                return true;
        //            else
        //                return false;
        //        }).Count() > 0)
        //        return true;
        //    else
        //        return false;
        //}

        //public bool CheckFileByName(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        //{
        //    Hch.iDisk.BLL.File bl = new Hch.iDisk.BLL.File();
        //    List<Hch.iDisk.Model.File> files = bl.GetModelList("DirId=" + file.DirId);
        //    if (files.Where(e =>
        //    {
        //        if (e.FName == file.FName)
        //            return true;
        //        else
        //            return false;
        //    }).Count() > 0)
        //        return true;
        //    else
        //        return false;
        //}

        //public string GetUpLoadUrl(Hch.iDisk.Model.File file, Hch.iDisk.Model.User user)
        //{
        //    Hch.iDisk.BLL.FileServer fs = new Hch.iDisk.BLL.FileServer();
        //    List<Hch.iDisk.Model.FileServer> fss = fs.GetModelList("");
        //    //获取剩余空间最大的服务器
        //    var server = fss.OrderByDescending(e => { return e.FSSize; }).First();//按降序排序并取结果集的第一个
        //    return server.FSHost + "/" + server.FSDirtory;
        //}
        
        //public Hch.iDisk.Model.File[] QueryFiles(string where, Hch.iDisk.Model.User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public Hch.iDisk.Model.File GetFile(string Id, Hch.iDisk.Model.User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool CheckDirtory(Hch.iDisk.Model.Dirtory dirtory, Hch.iDisk.Model.User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool AddDirtory(Hch.iDisk.Model.Dirtory dir, Hch.iDisk.Model.User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool DeleteDirtory(Hch.iDisk.Model.Dirtory dir, Hch.iDisk.Model.User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool UpdateDirtory(Hch.iDisk.Model.Dirtory dir, Hch.iDisk.Model.User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public Hch.iDisk.Model.Dirtory GetDirtory(Hch.iDisk.Model.User user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
