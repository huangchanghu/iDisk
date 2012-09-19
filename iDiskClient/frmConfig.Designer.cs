namespace iDiskClient
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDefaultPath = new System.Windows.Forms.TextBox();
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.cbAutoLogin = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucFormBase1 = new iDiskClient.UC.ucFormBase();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(251, 238);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 36);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "默认下载路径：";
            // 
            // tbDefaultPath
            // 
            this.tbDefaultPath.Location = new System.Drawing.Point(15, 72);
            this.tbDefaultPath.Name = "tbDefaultPath";
            this.tbDefaultPath.Size = new System.Drawing.Size(304, 21);
            this.tbDefaultPath.TabIndex = 3;
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(251, 100);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(68, 23);
            this.btnSelectDir.TabIndex = 4;
            this.btnSelectDir.Text = "选择...";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // cbAutoLogin
            // 
            this.cbAutoLogin.AutoSize = true;
            this.cbAutoLogin.Location = new System.Drawing.Point(15, 142);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.cbAutoLogin.TabIndex = 5;
            this.cbAutoLogin.Text = "自动登录";
            this.cbAutoLogin.UseVisualStyleBackColor = true;
            this.cbAutoLogin.CheckedChanged += new System.EventHandler(this.cbAutoLogin_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "配置";
            // 
            // ucFormBase1
            // 
            this.ucFormBase1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucFormBase1.BackgroundImage")));
            this.ucFormBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFormBase1.Location = new System.Drawing.Point(0, 0);
            this.ucFormBase1.Name = "ucFormBase1";
            this.ucFormBase1.Size = new System.Drawing.Size(331, 286);
            this.ucFormBase1.TabIndex = 0;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 286);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAutoLogin);
            this.Controls.Add(this.btnSelectDir);
            this.Controls.Add(this.tbDefaultPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ucFormBase1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConfig";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC.ucFormBase ucFormBase1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDefaultPath;
        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.CheckBox cbAutoLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}