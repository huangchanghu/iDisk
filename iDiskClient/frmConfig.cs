using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace iDiskClient
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            cbAutoLogin.Checked = Utility.GetAutoLogin();
            string path = Utility.GetDefaultPath().Trim();
            if (path == "")
            {
                path = Application.StartupPath + "\\DownLoad";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            tbDefaultPath.Text = path;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string path = tbDefaultPath.Text.Trim();
            if (path != "")
                Utility.SetDefaultPath(path);
            this.Close();
        }

        private void cbAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            Utility.SetAutoLogin(cbAutoLogin.Checked);
        }

        private void btnSelectDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbDefaultPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        
    }
}
