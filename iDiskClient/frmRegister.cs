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
    public partial class frmRegister : Form
    {
        User user = new User();
        public frmRegister()
        {
            InitializeComponent();
        }

        

        //提交按钮
        private void btnSumit_Click(object sender, EventArgs e)
        {
            if (!CheckForm()) return;

            user._uloginname = tbLoginName.Text.Trim();
            user._urealname = tbRealName.Text.Trim();
            user._upassword = tbPassWord1.Text.Trim();
            user._uemail = tbMail.Text.Trim();
            User u = new UserServiceClient().Register(user);
            if (u == null)
                MessageBox.Show(this, "注册失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            user = u;
            MessageBox.Show(this,"注册成功！","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        bool CheckForm()
        {
            bool mark = true;
            if (tbLoginName.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入登录名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mark = false;
                return mark;
            }
            if(tbPassWord1.Text.Trim() == "" && tbPassWord2.Text.Trim() == "")
            {
                MessageBox.Show(this,"请输入密码！","提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mark = false;
                return mark;
            }
            else if(tbPassWord1.Text.Trim() != tbPassWord2.Text.Trim())
            {
                MessageBox.Show(this,"两次输入密码不一致！","提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mark = false;
                return mark;
            }

            return mark;
        }

        //取消按钮
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //按下Enter键跳到下一个控键
        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(sender as Control,true,true,true,true);
            }
        }

        private void button_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            (sender as Button).PerformClick();
        }
    }
}
