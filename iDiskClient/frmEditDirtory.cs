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
    public partial class frmEditDirtory : Form
    {
        FileServices.Dirtory parentDir;
        FileServices.Dirtory newDir;
        FileServices.Dirtory homeDir;
        frmSelectDirtory selectDirForm;
        public frmEditDirtory(FileServices.Dirtory parentDir, FileServices.Dirtory newDir, FileServices.Dirtory homeDir)
        {
            InitializeComponent();
            this.parentDir = parentDir;
            this.newDir = newDir;
            this.homeDir = homeDir;
            selectDirForm = new frmSelectDirtory(homeDir);
            tbDirName.Text = newDir._dirname;
            tbParentDir.Text = parentDir._dirname;
            tbDirDesc.Text = newDir._dirdesc;
        }

        //确定按钮
        private void btnSummit_Click(object sender, EventArgs e)
        {
            if (tbDirName.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入目录名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (parentDir == null || parentDir._dirid <= 0)
            {
                MessageBox.Show(this, "请选择上级目录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            newDir._dirname = tbDirName.Text.Trim();
            newDir._dirdesc = tbDirDesc.Text.Trim();
            newDir._parentdirid = parentDir._dirid;
            newDir._uid = parentDir._uid;
            this.Hide();
        }
        //取消按钮
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //选择上级目录
        private void btnSelectParDir_Click(object sender, EventArgs e)
        {
            if(selectDirForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    parentDir = selectDirForm.SelectedDirtory;
            tbParentDir.Text = parentDir._dirname;
        }
    }
}
