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
    public partial class frmEditFile : Form
    {
        FileServices.File newFile;
        FileServices.Dirtory parentDir;
        FileServices.Dirtory homeDir;
       
        public frmEditFile(FileServices.File newFile, FileServices.Dirtory parentDir, FileServices.Dirtory homeDir)
        {
            InitializeComponent();
            this.newFile = newFile;
            this.parentDir = parentDir;
            this.homeDir = homeDir;
           
        }

        private void ucFormBase1_Load(object sender, EventArgs e)
        {
            if (newFile == null || parentDir == null) return;
            tbDesc.Text = newFile._fdesc;
            tbDirtory.Text = parentDir._dirname;
            tbFileName.Text = newFile._fname;
            tbSize.Text = Utility.ConvertSize((long)newFile._fsize);
            cbbVisivility.Text = Utility.IntToStr(newFile._fvisibility==null?0:(int)newFile._fvisibility);
        }

        //选择目录
        private void tbDirtory_Enter(object sender, EventArgs e)
        {
            frmSelectDirtory frm = new frmSelectDirtory(homeDir);
            if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 parentDir = frm.SelectedDirtory;
            tbDirtory.Text = parentDir._dirname;
        }

        private void btnSummit_Click(object sender, EventArgs e)
        {
            if (tbFileName.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入文件名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            newFile._fname = tbFileName.Text.Trim();
            newFile._fdesc = tbDesc.Text.Trim();
            newFile._fvisibility = Utility.StrToInt(cbbVisivility.Text);
            newFile._dirid = parentDir._dirid;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
