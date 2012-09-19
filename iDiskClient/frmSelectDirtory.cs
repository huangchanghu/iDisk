using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iDiskClient
{
    public partial class frmSelectDirtory : Form
    {
        FileServices.Dirtory homeDir;//用户主目录,用于建目录树
       // FileServices.Dirtory parentDir;
        public frmSelectDirtory(FileServices.Dirtory homeDir)
        {
            InitializeComponent();
            this.homeDir = homeDir;
          //  this.parentDir = parentDir;
            BuildTree(tvDirtory, homeDir);
            tvDirtory.ExpandAll();
        }

        private void frmSelectDirtory_Load(object sender, EventArgs e)
        {
          
        }

        public FileServices.Dirtory SelectedDirtory { get; set; }

        #region 建树视图
        /// <summary>
        /// 为目录建立树视图
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="dir"></param>
        public void BuildTree(TreeView treeView, FileServices.Dirtory dir)
        {
            UC.TreeNode parent = new UC.TreeNode(dir._dirname, dir);
            AddChildren(parent, dir);
            treeView.Nodes.Add(parent);
            treeView.SelectedNode = parent;
          
        }
        ///为节点添加子节点
        void AddChildren(UC.TreeNode treeNode, FileServices.Dirtory dir)
        {
            foreach (var d in dir._dirotories)
            {
                UC.TreeNode node = new UC.TreeNode(d._dirname, d);
                AddChildren(node, d);
                treeNode.Nodes.Add(node);
            }
        }
        #endregion

        //确定按钮
        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedDirtory = (tvDirtory.SelectedNode as UC.TreeNode).Value as FileServices.Dirtory;
            
            this.Hide();
        }
        //取消按钮
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide() ;
        }

        #region 窗体移动

        int x,
            y;
        bool canMove = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons != MouseButtons.Left) return;
            x = e.X;
            y = e.Y;
            canMove = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            canMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!canMove) return;
            this.Top += e.Y - y;
            this.Left += e.X - x;
           // MessageBox.Show(string.Format("ox:{0},oy:{1}\r\nx:{2},y:{3}\r\ntop:{4},left:{5}",x,y,Cursor.Position.X, Cursor.Position.Y,Top,Left));
        } 
        #endregion

        
    }
}
