namespace iDiskClient
{
    partial class frmRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSumit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbRealName = new System.Windows.Forms.TextBox();
            this.tbLoginName = new System.Windows.Forms.TextBox();
            this.tbPassWord1 = new System.Windows.Forms.TextBox();
            this.tbPassWord2 = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.formBase1 = new iDiskClient.UC.ucFormBase();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(28, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "登录名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(28, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "真实姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(30, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(28, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "确认密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(30, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "邮箱：";
            // 
            // btnSumit
            // 
            this.btnSumit.Location = new System.Drawing.Point(82, 260);
            this.btnSumit.Name = "btnSumit";
            this.btnSumit.Size = new System.Drawing.Size(75, 38);
            this.btnSumit.TabIndex = 5;
            this.btnSumit.Text = "提交";
            this.btnSumit.UseVisualStyleBackColor = true;
            this.btnSumit.Click += new System.EventHandler(this.btnSumit_Click);
            this.btnSumit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(185, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button_KeyDown);
            // 
            // tbRealName
            // 
            this.tbRealName.Location = new System.Drawing.Point(109, 90);
            this.tbRealName.Name = "tbRealName";
            this.tbRealName.Size = new System.Drawing.Size(151, 21);
            this.tbRealName.TabIndex = 1;
            this.tbRealName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // tbLoginName
            // 
            this.tbLoginName.Location = new System.Drawing.Point(109, 49);
            this.tbLoginName.Name = "tbLoginName";
            this.tbLoginName.Size = new System.Drawing.Size(151, 21);
            this.tbLoginName.TabIndex = 0;
            this.tbLoginName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // tbPassWord1
            // 
            this.tbPassWord1.Location = new System.Drawing.Point(109, 129);
            this.tbPassWord1.Name = "tbPassWord1";
            this.tbPassWord1.Size = new System.Drawing.Size(151, 21);
            this.tbPassWord1.TabIndex = 2;
            this.tbPassWord1.UseSystemPasswordChar = true;
            this.tbPassWord1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // tbPassWord2
            // 
            this.tbPassWord2.Location = new System.Drawing.Point(109, 163);
            this.tbPassWord2.Name = "tbPassWord2";
            this.tbPassWord2.Size = new System.Drawing.Size(151, 21);
            this.tbPassWord2.TabIndex = 3;
            this.tbPassWord2.UseSystemPasswordChar = true;
            this.tbPassWord2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(109, 199);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(151, 21);
            this.tbMail.TabIndex = 4;
            this.tbMail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(266, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(266, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(266, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(266, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "*";
            // 
            // formBase1
            // 
            this.formBase1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("formBase1.BackgroundImage")));
            this.formBase1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formBase1.Location = new System.Drawing.Point(0, 0);
            this.formBase1.Name = "formBase1";
            this.formBase1.Size = new System.Drawing.Size(353, 321);
            this.formBase1.TabIndex = 0;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 321);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbLoginName);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.tbPassWord2);
            this.Controls.Add(this.tbPassWord1);
            this.Controls.Add(this.tbRealName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSumit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.formBase1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegister";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC.ucFormBase formBase1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSumit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbRealName;
        private System.Windows.Forms.TextBox tbLoginName;
        private System.Windows.Forms.TextBox tbPassWord1;
        private System.Windows.Forms.TextBox tbPassWord2;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

    }
}