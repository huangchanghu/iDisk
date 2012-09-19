using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iDiskClient.UserServices;

namespace iDiskClient
{
    public partial class frmAdmin : Form
    {
        FileServices.User admin;
        ImageList largeImageList;
        ImageList smallImageList;
        FileServices.FileServiceClient fs = new FileServices.FileServiceClient();
        UserServiceClient us = new UserServiceClient();
        public frmAdmin(ImageList largeImageList, ImageList smallImageList, FileServices.User admin)
        {
            InitializeComponent();
            this.largeImageList = largeImageList;
            this.smallImageList = smallImageList;
            this.admin = admin;
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            lvFiles.LargeImageList = largeImageList;
            lvFiles.SmallImageList = smallImageList;
            cbListViewStyle.SelectedIndex = 0;
        }
       

        private void pbSearchUser_Click(object sender, EventArgs e)
        {
            SearchUser();
        }
        ///搜索用户
        private void SearchUser()
        {
            User[] users = us.QueryUsers(string.Format("ULoginName like '%{0}%'", tbUserSearch.Text.Trim()));
            dgvUuserInfo.Rows.Clear();
            foreach (var u in users)
            {
                dgvUuserInfo.Rows.Add(new string[] { u._uid.ToString(), u._uloginname, u._urealname, u._uemail, "删除" });
            }
        }

         private void tbUserSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchUser();
        }


        #region 搜索框默认文本设置
        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            (sender as TextBox).Focus();
            tbSearchFile.SelectAll();
        }

        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;
            if (tb.Text.Trim() == "")
            {
                switch (tb.Name)
                {
                    case "tbSearchFile":
                        SetText(tb, "输入文件关键字进行搜索");
                        break;
                    case "tbSearchFileByUser":
                        SetText(tb,"输入用户名进行文件搜索");
                        break;
                    case "tbUserSearch":
                        SetText(tb, "输入用户名进行搜索");
                        break;
                    default:
                        return;
                }
            }
        }
        private void SetText(TextBox textBox, string text)
        {
            textBox.Text = text;
        }

        #endregion

        
        #region 鼠标划过picturBox时产生动态效果
        int x, y;
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            x = pb.Location.X;
            y = pb.Location.Y;
            pb.Location = new Point(x + 3, y + 3);
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Location = new Point(x, y);
        }

        private void pbSearchFriend_Click(object sender, EventArgs e)
        {
           // new frmAdmin().Show();
        }

        #endregion 鼠标划过picturBox时产生动态效果

        private void pbSearchFile_Click(object sender, EventArgs e)
        {
            FileServices.File[] files = fs.QueryFilesAdmin(string.Format("FName like '%{0}%'",tbSearchFile.Text.Trim()), admin, 0);
            SetListViewItem(files);
            isUserFile = false;
        }

        private void SetListViewItem(FileServices.File[] files)
        {
            lvFiles.Items.Clear();
            foreach (var f in files)
            {
                string type = Utility.GetFileType(f._fname);
                if (!Utility.FileTypeExists(type, false))
                {
                    largeImageList.Images.Add(type, Utility.GetIcon(type, true));
                    smallImageList.Images.Add(type, Utility.GetIcon(type,false));
                }
                DateTime dt = (DateTime)f._fdate;
                string[] info = new string[] { f._fname, Utility.ConvertSize((long)f._fsize), dt.ToShortDateString() + " " + dt.ToLongTimeString(), Utility.IntToStr((int)f._fvisibility), f._fdesc};

                UC.ListViewItem item = new UC.ListViewItem(info,f._fname);
                item.Value = f;
                item.ImageKey = type;
                lvFiles.Items.Add(item);
            }
        }

        private void cbListViewStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbListViewStyle.Text)
            {
                case "列表":
                    //lvFiles.CheckBoxes = true;
                    lvFiles.View = View.List;
                    break;
                case "平铺":
                    //lvFiles.CheckBoxes = false;
                    lvFiles.View = View.Tile;
                    break;
                case "图标":
                   // lvFiles.CheckBoxes = false;
                    lvFiles.View = View.LargeIcon;
                    break;
                case "详细信息":
                   // lvFiles.CheckBoxes = true;
                    lvFiles.View = View.Details;
                    break;
                default:
                   // lvFiles.CheckBoxes = false;
                    lvFiles.View = View.LargeIcon;
                    break;
            }
        }

        private void tbSearchFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FileServices.File[] files = fs.QueryFilesAdmin(string.Format("FName like '%{0}%'", tbSearchFile.Text.Trim()), admin, 0);
                SetListViewItem(files);
                isUserFile = false;
            }
        }

        //浏览用户文件
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvUuserInfo.SelectedCells.Count < 1)
            {
                MessageBox.Show(this, "请先选中一个用户再操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataGridViewCell cell = dgvUuserInfo.SelectedCells[0];
            if (cell == null)
            {
                MessageBox.Show(this,"请先选中一个用户再操作！","错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataGridViewRow row = dgvUuserInfo.Rows[cell.RowIndex];
           // MessageBox.Show(row.Cells[0].ToString()); return;
            FileServices.File[] files = fs.QueryFilesAdmin(string.Format("FName like '%{0}%'", ""), admin,int.Parse(row.Cells[0].Value.ToString().Trim()));
            SetListViewItem(files);
            tcAdmin.SelectedTab = tpFile;
            isUserFile = true;
        }
        //删除用户
        private void dgvUuserInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 4)
                return;
             DataGridViewCell cell = dgvUuserInfo.SelectedCells[0];
            if (cell == null)
            {
                MessageBox.Show(this,"请先选中一个用户再操作！","错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataGridViewRow row = dgvUuserInfo.Rows[cell.RowIndex];
            if (MessageBox.Show(this, "确定要删除选中用户吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                if(us.DeleteUser(new User{ _uid=int.Parse(row.Cells[0].Value.ToString())}, new User{ _uid=admin._uid, _uloginname=admin._uloginname}))
                {
                    MessageBox.Show(this,"已成功删除用户:" + row.Cells[1].Value, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUuserInfo.Rows.Remove(row);
                }
                else
                    MessageBox.Show(this, "删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        //下载文件
        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            
            if(lvFiles.SelectedItems.Count < 1)
            {
                MessageBox.Show(this,"请选中文件后进行下载!", "下载", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FileServices.File file = (lvFiles.SelectedItems[0] as UC.ListViewItem).Value as FileServices.File;
            if (file == null) return;
            DownLaodFile(file,false);
        }
        //删除选中文件
        private void btnDelSelectedFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUuserInfo.SelectedCells.Count < 1)
                {
                    MessageBox.Show(this, "只能删除选中用户的文件！\r\n请先选中一个用户并浏览其文件，然后进行删除。", "删除", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DataGridViewCell cell = dgvUuserInfo.SelectedCells[0];
                DataGridViewRow row = dgvUuserInfo.Rows[cell.RowIndex];
                if (lvFiles.SelectedItems.Count < 1)
                {
                    MessageBox.Show(this, "请先选中一个文件！", "删除", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ListViewItem item = lvFiles.SelectedItems[0];
                FileServices.File file = (lvFiles.SelectedItems[0] as UC.ListViewItem).Value as FileServices.File;
                if (file == null) return;
                if (MessageBox.Show(this, string.Format("文件：{0}\r\n将被删除，是否确定删除？", file._fname),"删除文件", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (fs.DeleteFile(file, new FileServices.User { _uid = int.Parse(row.Cells[0].Value.ToString()), _uloginname = row.Cells[1].Value.ToString() }))
                {
                    MessageBox.Show(this, string.Format("文件:{0}\r\n已成功删除！",file._fname), "删除", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lvFiles.Items.Remove(item);
                }
                else
                    MessageBox.Show(this, "删除失败！", "删除", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "删除", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DownLaodFile(FileServices.File file, bool defaultPath)
        {
            string path = "";
            if (defaultPath)
            {
                path = Utility.GetDefaultPath() + "\\" + file._fname;
            }
            else
            {
                saveFileDialog1.FileName = file._fname;
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    path = saveFileDialog1.FileName;
            }
            if (path == "") return;
            try
            {
                TcpDownLoader dl = new TcpDownLoader(fs.GetDownLoadUrl(file, admin), "", path, admin, file);
                dl.DownLoadBegin += DownLoadBegin;
                dl.DownLoadFinished += DownLoadFinished;
                dl.DownLoading += DownLoading;
                dl.BeginDownLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DownLoadBegin(object sender, DownLoadEventArgs e)
        {

        }
        private void DownLoading(object sender, DownLoadEventArgs e)
        {

        }
        private void DownLoadFinished(object sender, DownLoadEventArgs e)
        {
            MessageBox.Show(string.Format("文件：{0}\r\n下载完成!",e.LocalFileName));
        }

        bool isUserFile = false;
        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count < 1)
            {
                btnDelSelectedFiles.Enabled = false;
                btnDownLoad.Enabled = false;
            }
            else
            {
                btnDownLoad.Enabled = true;
                if (isUserFile)
                    btnDelSelectedFiles.Enabled = true;
            }
        }

    }
}
