using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iDiskClient;
using System.Diagnostics;

namespace iDiskClient
{
    public partial class fmMain : Form
    {
        UserServices.User user = new UserServices.User();//用户服务中的用户
        FileServices.User fUser = new FileServices.User();//文件服务中的用户
        FileServices.Dirtory currentDir;//目录树中当前选中的目录
        UC.TreeNode curNode;//当前选中的树节点
        int lastDirId = -1;//用于重新加载目录时还原选中的树节点
        FileServices.FileServiceClient fileservice = new FileServices.FileServiceClient();
        FileServices.Dirtory homeDirtory;//用户主目录
        bool isSearchPublicFile = false;//标志当前文件视图中是否一正显示搜索公共文件的结果
        public UserServices.User User
        {
            get { return user; }
            set 
            {
                user = value;
                fUser._uid = user._uid;
                fUser._uemail = user._uemail;
                fUser._uloginname = user._uloginname;
                fUser._urealname = user._urealname;
                fUser._upassword = user._upassword;
            }
        }
        public fmMain()
        {
            InitializeComponent();
            new frmLogin(this).ShowDialog();
            lbWelcomeUser.Text = "欢迎，" + user._uloginname;
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            if (user._uid <= 0)
                Close();
            LoadDirtory();
            pnlFileInfo.Visible = false;
            cbListViewStyle.SelectedIndex = 0;
            if (!new UserServices.UserServiceClient().IsAdmin(user))
                管理员面板ToolStripMenuItem.Visible = false;
        }
        /// <summary>
        /// 加载用户目录
        /// </summary>
        private void LoadDirtory()
        {
            //保存之前选中的目录
            UC.TreeNode nodetem = curNode as UC.TreeNode;
            if (nodetem != null)
                lastDirId = (nodetem.Value as FileServices.Dirtory)._dirid;
            else
                lastDirId = -1;
            homeDirtory = fileservice.GetDirtory(fUser);//获取用户目录
            BuildTree(tvDirtory, homeDirtory);//建立目录树
            //还原先前选中的树节点
            TreeNode node = SearchTree(tvDirtory.Nodes[0],lastDirId);
            if (node != null)
            {
               // tvDirtory.ExpandAll();
                tvDirtory.SelectedNode = node;
            }
        }

        //取得指定ID的目录
        private FileServices.Dirtory GetDirtoryById(FileServices.Dirtory root,int dirId)
        {
            FileServices.Dirtory dir = null;
            if (root._dirid == dirId)
            {
               return root;
            }
            foreach (var d in root._dirotories)
            {
                if (d._dirid == dirId)
                {
                    return d;
                }
                dir = GetDirtoryById(d, dirId);
                if (dir != null)
                    break;
            }
            return dir;
        }
        
        //向ListView加载当前选定目录的内容
        private void LoadFiles()
        {
            lvFilesView.Items.Clear();
            FileServices.Dirtory dir = curNode.Value as FileServices.Dirtory;
            if (dir == null) return;
            foreach (var d in dir._dirotories)
            {
               // MessageBox.Show(Application.StartupPath + "\\folder.ico");
                //添加图标
                //string fileType = "folder";
                //if (!Utility.FileTypeExists(fileType, false))
                //{
                //    imageListLargeIcon.Images.Add(fileType, Utility.GetIcon(Application.StartupPath + "\\folder.ico", true));
                //    imageListSmallIcon.Images.Add(fileType, Utility.GetIcon(Application.StartupPath + "\\folder.ico", false));
                //}

                string[] info = new string[5] { d._dirname, "", "", "", d._dirdesc };
                UC.ListViewItem item = new UC.ListViewItem(info,d._dirname);
                item.Value = d;
                item.ImageKey = "folder";
                lvFilesView.Items.Add(item);
            }
            foreach (var f in dir._files)
            {
                //设置文件图标
                string fileType = Utility.GetFileType(f._fname);
                if (!Utility.FileTypeExists(fileType, false))
                {
                    imageListLargeIcon.Images.Add(fileType, Utility.GetIcon(fileType, true));
                    imageListSmallIcon.Images.Add(fileType, Utility.GetIcon(fileType, false));
                }

                DateTime dt = (DateTime)f._fdate;
                UC.ListViewItem lvi = new UC.ListViewItem(new string[] { f._fname, Utility.ConvertSize((long)f._fsize), dt.ToShortDateString() + " " + dt.ToLongTimeString(), Utility.IntToStr((int)f._fvisibility), f._fdesc }, f._fname);
                lvi.Value = f;
                lvi.ImageKey = fileType;
                lvFilesView.Items.Add(lvi);
            }
        }

        #region 与目录树相关的操作

        #region 建立目录树
        /// <summary>
        /// 为目录建立树视图
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="dir"></param>
        public void BuildTree(TreeView treeView, FileServices.Dirtory dir)
        {
            UC.TreeNode parent = new UC.TreeNode(dir._dirname, dir);
            parent.ImageIndex = 0;
            parent.SelectedImageIndex = 1;
            AddChildren(parent, dir);
            treeView.Nodes.Clear();
            treeView.Nodes.Add(parent);
            treeView.SelectedNode = parent;
            ToolStripMenuItem smi = new ToolStripMenuItem("新建子目录");
            smi.Click += tmiNewDirtory_Click;
            cmsHomeDirRight.Items.Clear();
            cmsHomeDirRight.Items.Add(smi);
            parent.ContextMenuStrip = cmsHomeDirRight;
        }
        ///为节点添加子节点
        void AddChildren(UC.TreeNode treeNode, FileServices.Dirtory dir)
        {
            foreach (var d in dir._dirotories)
            {
                UC.TreeNode node = new UC.TreeNode(d._dirname, d);
                node.ImageIndex = 0;
                node.SelectedImageIndex = 1;
                AddChildren(node, d);
                node.ContextMenuStrip = cmsDirtoryRightMenu;
                treeNode.Nodes.Add(node);
            }
        }
        #endregion  建立目录树
        //获取具有指定目录ID的树节点
        private TreeNode SearchTree(TreeNode root, int dirId)
        {
            if (root == null) return null;
            UC.TreeNode u = root as UC.TreeNode;
            if (u != null && (u.Value as FileServices.Dirtory)._dirid == dirId)
                return u;
            TreeNode rect = null;
            foreach (TreeNode node in root.Nodes)
            {
                //MessageBox.Show(((node as UC.TreeNode).Value as FileServices.Dirtory)._dirid.ToString() + " " + dirId);
                rect = SearchTree(node, dirId);
                if (rect != null)
                {
                    break;
                }
            }
            return rect;
        }

        #region TreeView事件
        private void tvDirtory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            isSearchPublicFile = false;//搜索公共文件标杆设为假
            lbSearchCount.Text = "";//将搜索结果数标签隐藏
            UC.TreeNode node = tvDirtory.SelectedNode as UC.TreeNode;
            if (node != null)
            {
                label1.Text = ((FileServices.Dirtory)node.Value)._dirname;
                currentDir = node.Value as FileServices.Dirtory;
                curNode = node;//当前选中节点
                LoadFiles();
            }
        }
        //单击树节点时发生
        private void tvDirtory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvDirtory.SelectedNode = e.Node;
        }
        #endregion  TreeView事件

        #endregion 与目录树相关的操作

        #region 目录右键菜单操作
        //移动目录
        private void tmiMoveDirtory_Click(object sender, EventArgs e)
        {
            FileServices.Dirtory dir = curNode.Value as FileServices.Dirtory;
            if(dir == null) return;
            frmSelectDirtory frm = new frmSelectDirtory(homeDirtory);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (dir._parentdirid != frm.SelectedDirtory._dirid)
                {
                    dir._parentdirid = frm.SelectedDirtory._dirid;
                    if(fileservice.UpdateDirtory(dir, fUser))
                        LoadDirtory();
                    else
                        MessageBox.Show(this, "操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        //删除目录
        private void tmiDeleteDirtory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "注意，删除目录时，其所有子目录和文件将被同时删除！\r\n是否确认删除？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                return;
            if(fileservice.DeleteDirtory(curNode.Value as FileServices.Dirtory, fUser))
                LoadDirtory();
            else
                MessageBox.Show(this, "删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //新建目录
        private void tmiNewDirtory_Click(object sender, EventArgs e)
        {
            FileServices.Dirtory parent = curNode.Value as FileServices.Dirtory;
            FileServices.Dirtory newDir = new FileServices.Dirtory{ _parentdirid=parent._dirid, _uid=parent._uid};
            if (new frmEditDirtory(parent, newDir, homeDirtory).ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            fileservice.AddDirtory(newDir,fUser);
            LoadDirtory();
            tvDirtory.SelectedNode = curNode;
            
        }
        //编辑目录
        private void tmiEditDirtory_Click(object sender, EventArgs e)
        {
            FileServices.Dirtory dir = curNode.Value as FileServices.Dirtory;
            if (dir == null) return;
            FileServices.Dirtory parentDir = GetDirtoryById(homeDirtory, (int)dir._parentdirid);
            new frmEditDirtory(parentDir, dir, homeDirtory).ShowDialog();
            if (!fileservice.UpdateDirtory(dir, fUser))
            {
                MessageBox.Show(this, "目录修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            LoadDirtory();
        }

        #endregion 目录右键菜单操作

        #region 文件视图相关操作、右键菜单、事件
        //ListView中选择项改变时
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count < 1)
            {
                pnlFileInfo.Visible = false;
                return;
            }
            SetStatus((lv.SelectedItems[0] as UC.ListViewItem).Value);
        }
        //按下回车键，返回上层目录
        private void lvFilesView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                tvDirtory.Focus();
                SendKeys.Send("BS");
            }
        }

        //显示选择中目录或文件信息
        private void SetStatus(object value)
        {
            pnlFileInfo.Visible = true;
            if (value is FileServices.Dirtory)
            {
                FileServices.Dirtory dir = value as FileServices.Dirtory;
                lbName.Text = dir._dirname;
                lbDesc.Text = dir._dirdesc;
                lbDate.Text = "";
                lbSize.Text = "";
            }
            if (value is FileServices.File)
            {
                FileServices.File file = value as FileServices.File;
                lbName.Text = file._fname;
                lbDesc.Text = file._fdesc;
                DateTime dt = (DateTime)file._fdate;
                lbDate.Text = dt.ToShortDateString() + " " + dt.ToLongTimeString();
                lbSize.Text = Utility.ConvertSize((long)file._fsize);
            }
        }
        ///双击文件或目录
        private void lvFilesView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv == null) return;
            ListViewItem item = lv.GetItemAt(e.X, e.Y);
            if (item == null) return;
            UC.ListViewItem ucitem = item as UC.ListViewItem;
            if (ucitem == null) return;
            FileServices.Dirtory dir = ucitem.Value as FileServices.Dirtory;
            if (dir != null)
            {
                OpenDirtory(dir._dirid);
                return;
            }
            FileServices.File file = ucitem.Value as FileServices.File;
            if (file != null)
            {
                OpenFile(file);
                return;
            }
        }
        #region ListView右键菜单相关操作

        //文件右键菜单弹出前触发
        private void cmsFileRightMenu_Opening(object sender, CancelEventArgs e)
        {
            if (lvFilesView.SelectedIndices.Count < 1)
                SetFileRightMenuType("blank");
            else if ((lvFilesView.SelectedItems[0] as UC.ListViewItem).Value is FileServices.Dirtory)
                SetFileRightMenuType("dirtory");
            else
                SetFileRightMenuType("file");
        }

        //设置ListView中右键菜单中的可用项
        private void SetFileRightMenuType(string type)
        {
            tmiDeleteFile.Enabled = false;
            tmiDownLoad.Enabled = false;
            tmiEditFile.Enabled = false;
            tmiMoveFile.Enabled = false;
            tmiOpenFile.Enabled = false;
            tmiSaveAs.Enabled = false;
            tmiUpLoadFile.Enabled = false;
            tmiAddToMyDir.Enabled = false;
            switch (type)
            {
                case "blank":
                    tmiUpLoadFile.Enabled = true;
                    break;
                case "file":

                    if (!isSearchPublicFile)
                    {
                        tmiDeleteFile.Enabled = true;
                        tmiDownLoad.Enabled = true;
                        tmiEditFile.Enabled = true;
                        tmiMoveFile.Enabled = true;
                        tmiOpenFile.Enabled = true;
                        tmiSaveAs.Enabled = true;
                        tmiUpLoadFile.Enabled = true;
                    }
                    else
                    {
                        tmiDownLoad.Enabled = true;
                        tmiOpenFile.Enabled = true;
                        tmiSaveAs.Enabled = true;
                        tmiUpLoadFile.Enabled = true;
                        tmiAddToMyDir.Enabled = true;
                    }
                    break;
                case "dirtory":
                    tmiUpLoadFile.Enabled = true;
                    tmiOpenFile.Enabled = true;
                    break;
            }
        }

        ///打开文件或目录
        private void tmiOpenFile_Click(object sender, EventArgs e)
        {
            UC.ListViewItem item = lvFilesView.SelectedItems[0] as UC.ListViewItem;
            if (item == null) return;
            FileServices.Dirtory dir = item.Value as FileServices.Dirtory;
            if (dir != null)
            {
                OpenDirtory(dir._dirid);
                return;
            }
            FileServices.File file = item.Value as FileServices.File;
            if (file != null)
            {
                OpenFile(file);
            }
        }
        //打开目录
        private void OpenDirtory(int dirId)
        {
            TreeNode node = SearchTree(tvDirtory.Nodes[0], dirId);
            if (node != null)
                tvDirtory.SelectedNode = node;
        }
        //打开文件
        private void OpenFile(FileServices.File file)
        {
            //下载并打开文件
        }
        //下载文件
        private void tmiDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                FileServices.File file = (lvFilesView.SelectedItems[0] as UC.ListViewItem).Value as FileServices.File;
                if (file == null)
                {
                    MessageBox.Show(this, "请选中一个文件进行下载！", "下载", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DownLaodFile(file, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "下载异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //文件另存为
        private void tmiSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                FileServices.File file = (lvFilesView.SelectedItems[0] as UC.ListViewItem).Value as FileServices.File;
                if (file == null)
                {
                    MessageBox.Show(this, "请选中一个文件进行下载！", "下载", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DownLaodFile(file, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "下载异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //移动文件
        private void tmiMoveFile_Click(object sender, EventArgs e)
        {
            FileServices.File file = (lvFilesView.SelectedItems[0] as UC.ListViewItem).Value as FileServices.File;
            if (file == null) return;
            frmSelectDirtory frm = new frmSelectDirtory(homeDirtory);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file._dirid = frm.SelectedDirtory._dirid;
                if (fileservice.UpdateFile(file, fUser))
                    LoadDirtory();
                else
                    MessageBox.Show(this, "更新失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //删除文件
        private void tmiDeleteFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "删除选中文件?", "确认信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;
            FileServices.File file = (lvFilesView.SelectedItems[0] as UC.ListViewItem).Value as FileServices.File;
            if (file == null) return;
            if (!fileservice.DeleteFile(file, fUser))
            {
                MessageBox.Show(this, "删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            LoadDirtory();
        }
        //编辑文件
        private void tmiEditFile_Click(object sender, EventArgs e)
        {

            UC.ListViewItem item = lvFilesView.SelectedItems[0] as UC.ListViewItem;
            if (!(item.Value is FileServices.File)) return;
            FileServices.File file = item.Value as FileServices.File;
            FileServices.Dirtory parentDir = GetDirtoryById(homeDirtory, (int)file._dirid);
            if (parentDir == null) return;//获取目录失败
            new frmEditFile(file, parentDir, homeDirtory).ShowDialog();
            //  item.Text = file._fname;
            SetStatus(file);
            if (!fileservice.UpdateFile(file, fUser))
            {
                MessageBox.Show(this, "更新失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            LoadDirtory();//刷新目录树
        }
        //保存到我的目录
        private void tmiAddToMyDir_Click(object sender, EventArgs e)
        {
            UC.ListViewItem item = lvFilesView.SelectedItems[0] as UC.ListViewItem;
            if (!(item.Value is FileServices.File)) return;
            FileServices.File sfile = item.Value as FileServices.File;
            FileServices.Dirtory parent = curNode.Value as FileServices.Dirtory;
            FileServices.File file = new FileServices.File { _dirid = parent._dirid, _fdate = DateTime.Now, _fdesc = sfile._fdesc, _fid = sfile._fid, _fname = sfile._fname, _fsize = sfile._fsize, _furl = sfile._furl, _fuserid = user._uid, _fvisibility = sfile._fvisibility };
            new frmEditFile(file, parent, homeDirtory).ShowDialog();
            if (!fileservice.AddFile(file, fUser))
            {
                MessageBox.Show(this, "保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            lastDirId = parent._dirid;
            SetStatus(file);
            LoadDirtory();//刷新目录树
        }
        //上传文件
        private void tmiUpLoadFile_Click(object sender, EventArgs e)
        {
            UpLoadFile();
        }
        //上传文件
        private void UpLoadFile()
        {
            string filePath = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                FileServices.Dirtory parentDir = curNode.Value as FileServices.Dirtory;
                FileServices.File newFile = new FileServices.File { _fid=Utility.GetFileId(filePath), _fname=Utility.GetFileName(filePath), _dirid = parentDir._dirid, _fuserid = parentDir._uid, _fdate= DateTime.Now, _fsize=Utility.GetFileSize(filePath) };
                bool cancel = true;//是否取消编辑
                while (new frmEditFile(newFile, parentDir, homeDirtory).ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    cancel = false;
                    bool mark = false;
                    foreach (var f in parentDir._files)
                    {
                        if (f._fname == newFile._fname)
                        {
                            MessageBox.Show(this, "已存在相同名称的文件，请更改文件名称！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            mark = true;
                            break;
                        }
                    }
                    if (!mark)
                        break;
                    cancel = true;
                }
                if (cancel) return;//已取消编辑
                if (!fileservice.AddFile(newFile, fUser))
                {
                    MessageBox.Show(this, "添加文件失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (fileservice.CheckFileById(newFile, fUser))
                {
                    MessageBox.Show(this,"上传完成！");
                    LoadDirtory();
                    return;
                }
                string url = fileservice.GetUpLoadUrl(newFile, fUser);
                TcpUpLoader up = new TcpUpLoader(fileservice.GetUpLoadUrl(newFile, fUser), filePath, newFile, fUser, null);
                up.UpLoadBegin += UpLoadBegin;
                up.UpLoadFinished += UpLoadFinished;
                up.UpLoading += UpLoading;
                up.BeginUpLoad();
                LoadDirtory();
            }
        }
        private void UpLoadBegin(object sender, UpLoadEventArgs args)
        {
           // MessageBox.Show("begin...");
        }
        private void UpLoading(object sender, UpLoadEventArgs args)
        {
           // MessageBox.Show("UpLoading...");
        }
        private void UpLoadFinished(object sender, UpLoadEventArgs args)
        {
            MessageBox.Show("上传完成！");
           // backgroundWorker1.RunWorkerAsync();
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
                TcpDownLoader dl = new TcpDownLoader(fileservice.GetDownLoadUrl(file, fUser), "", path, fUser, file);
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
            MessageBox.Show(string.Format("文件：{0}\r\n下载完成!", e.LocalFileName));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadDirtory();
            MessageBox.Show("load finished.");
        }
        #endregion ListView右键菜单相关操作

        #endregion  文件视图相关操作、右键菜单、事件

        #region PictureBox事件

        //上一步，将上次被选中的目录再次设为中
        private void pbBack_Click(object sender, EventArgs e)
        {
            //tvDirtory.SelectedNode = historyNode[historyIndex - 1];
            tvDirtory.Focus();
            SendKeys.Send("{BS}");
        }
        //点击上传文件图标
        private void pbUpLoad_Click(object sender, EventArgs e)
        {
            UpLoadFile();
        }
        //点击下载文件图标
        private void pbDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvFilesView.SelectedItems.Count < 1)
                {
                    MessageBox.Show(this, "请选中一个文件进行下载！", "下载", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                FileServices.File file = (lvFilesView.SelectedItems[0] as UC.ListViewItem).Value as FileServices.File;
                if (file == null)
                {
                    MessageBox.Show(this, "请选中一个文件进行下载！", "下载", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DownLaodFile(file, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "下载异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region 鼠标划过picturBox时产生动态效果
        int x, y;
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            x = pb.Location.X;
            y = pb.Location.Y;
            pb.Location = new Point(x + 3, y + 3);
        }

        #region 搜索文件
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Location = new Point(x, y);
        }
        ///搜索用户文件
        private void pbSearchFriend_Click(object sender, EventArgs e)
        {
            SearchFile(true);
        }
        private void tbSearchUserFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchFile(true);
        }
        private void pbSearchNetFile_Click(object sender, EventArgs e)
        {
            SearchFile(false);
        }

        private void tbSearchNetFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchFile(false);
        }
        private void SearchFile(bool searchUserFile)
        {
            FileServices.File[] files = null;
            if (searchUserFile)
            {
                isSearchPublicFile = false;
                SearchUserFile();
            }
            else
            {
                isSearchPublicFile = true;
                files = fileservice.QueryFiles(string.Format("FName like '%{0}%'", tbSearchNetFile.Text.Trim()), fUser);
            }
            if (files != null)
                ShowSearchFile(files);
        }
        //从用户目录中搜索文件
        private void SearchUserFile()
        {
            
            List<FileServices.File> files = new List<FileServices.File>();
            SearchFromDir(homeDirtory, files, tbSearchUserFile.Text.Trim().ToLower());
            ShowSearchFile(files.ToArray());
        }
        private void SearchFromDir(FileServices.Dirtory dir, List<FileServices.File> files,string where)
        {
            foreach (var f in dir._files)
            {
                if(f._fname.Contains(where))
                    files.Add(f);
            }
            foreach (var d in dir._dirotories)
            {
                SearchFromDir(d,files,where);
            }
        }
        #endregion  搜索文件

        private void ShowSearchFile(FileServices.File[] files)
        {
            try
            {
                lbSearchCount.Text = "搜索结果数：" + files.Length;
                lvFilesView.Items.Clear();
                foreach (var f in files)
                {
                    string fileType = Utility.GetFileType(f._fname);
                    if (!Utility.FileTypeExists(fileType, false))
                    {
                        imageListLargeIcon.Images.Add(fileType, Utility.GetIcon(fileType, true));
                        imageListSmallIcon.Images.Add(fileType, Utility.GetIcon(fileType, false));
                    }
                    DateTime dt = (DateTime)f._fdate;
                    string[] info = new string[5];
                    info[0] = f._fname;
                    info[1] = Utility.ConvertSize((long)f._fsize);
                    info[2] = dt.ToShortDateString() + " " + dt.ToLongTimeString();
                    info[3] = Utility.IntToStr((int)f._fvisibility);
                    info[4] = f._fdesc;
                    UC.ListViewItem item = new UC.ListViewItem(info, f._fname);
                    item.Value = f;
                    item.ImageKey = fileType;
                    lvFilesView.Items.Add(item);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("显示搜索结果过程中出错：\r\n" + ex.Message);
            }
        }

        #endregion 鼠标划过picturBox时产生动态效果



        #endregion  PictureBox事件

        #region 搜索框默认文本设置-TextBox
        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            (sender as TextBox).Focus();
            tbSearchNetFile.SelectAll();
        }

        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;
            if (tb.Text.Trim() == "")
            {
                switch (tb.Name)
                {
                    case "tbSearchUserFile":
                        SetText(tb, "搜索我的文件...");
                        break;
                    case "tbSearchNetFile":
                        SetText(tb, "从网络中搜索...");
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

        ///改变文件的显示方式
        private void cbListViewStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbListViewStyle.Text)
            {
                case "列表":
                    lvFilesView.View = View.List;
                    break;
                case "平铺":
                    lvFilesView.View = View.Tile;
                    break;
                case "图标":
                    lvFilesView.View = View.LargeIcon;
                    break;
                case "详细信息":
                    lvFilesView.View = View.Details;
                    break;
                default:
                    lvFilesView.View = View.LargeIcon;
                    break;
            }
        }

        private void 管理员面板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAdmin(this.imageListLargeIcon, this.imageListSmallIcon, fUser).Show();
        }

        private void 配置CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConfig().ShowDialog();
        }

        private void llbLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Application.StartupPath + "\\iDiskClient.exe");
            Application.Exit();
        }

        private void btnNativeFile_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe");
        }

        private void lvFilesView_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.Data.GetData("text").ToString());
        }

    }
}
