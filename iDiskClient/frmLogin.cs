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
    public partial class frmLogin : Form
    {
        User user;
        fmMain fmmain;
        public frmLogin(fmMain m)
        {
            InitializeComponent();
            fmmain = m;
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //设置初始值
            string name = Utility.GetUserName();
            string pass = Utility.GetPass();
            if (Utility.GetUserName() != "")
            {
                cbbLoginName.Text = name;
                tbPassWord.Text = pass;
                cbSavePass.Checked = Utility.GetKeepPass();
                cbAutoLogin.Checked = Utility.GetAutoLogin();
                if (cbAutoLogin.Checked)
                    Login();
            }
        }

        private void pbLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void llbGetBackPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void llbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmRegister().Show();
        }

        //登录
        private void Login()
        {
            if (!CheckForm()) return;//验证
            User u = new UserServiceClient().Login(new User { _uloginname = cbbLoginName.Text.Trim(), _upassword = tbPassWord.Text.Trim() });
            if (u == null)
            {
                MessageBox.Show(this,"用户名或密码错误！","登录", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             user = u;
            fmmain.User = user;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (cbSavePass.Checked)
            {
                Utility.SetUserName(cbbLoginName.Text.Trim());
                Utility.SetPass(tbPassWord.Text.Trim());
            }
            this.Close();
        }

        /// 检查用户输入信息是否正确
        private bool CheckForm()
        {
            bool mark = true;
            if (cbbLoginName.Text.Trim() == "")
            {
                MessageBox.Show("请输入登录名！");
                mark = false;
                return mark ;
            }
            if (tbPassWord.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码！");
                mark = false;
                return mark;
            }
            return mark;
        }

        private void tbPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }

        //保存密码
        private void cbSavePass_CheckedChanged(object sender, EventArgs e)
        {
            Utility.SetKeepPass(cbSavePass.Checked);
            if (!cbSavePass.Checked)
            {
                Utility.SetUserName("");
                Utility.SetPass("");
            }
        }
        //自动登录
        private void cbAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            Utility.SetAutoLogin(cbAutoLogin.Checked);
        }

        private void cbbLoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            tbPassWord.Focus();
        }
        

    }
}
