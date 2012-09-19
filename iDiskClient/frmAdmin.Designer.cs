namespace iDiskClient
{
    partial class frmAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpFile = new System.Windows.Forms.TabPage();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVisibility = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFileUp = new System.Windows.Forms.Panel();
            this.btnDelSelectedFiles = new System.Windows.Forms.Button();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.cbListViewStyle = new System.Windows.Forms.ComboBox();
            this.pbSearchFile = new System.Windows.Forms.PictureBox();
            this.tbSearchFile = new System.Windows.Forms.TextBox();
            this.tpUser = new System.Windows.Forms.TabPage();
            this.dgvUuserInfo = new System.Windows.Forms.DataGridView();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteUser = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pbSearchUser = new System.Windows.Forms.PictureBox();
            this.tbUserSearch = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tcAdmin.SuspendLayout();
            this.tpFile.SuspendLayout();
            this.pnlFileUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchFile)).BeginInit();
            this.tpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUuserInfo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchUser)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpFile);
            this.tcAdmin.Controls.Add(this.tpUser);
            this.tcAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAdmin.Location = new System.Drawing.Point(0, 0);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(986, 576);
            this.tcAdmin.TabIndex = 0;
            // 
            // tpFile
            // 
            this.tpFile.Controls.Add(this.lvFiles);
            this.tpFile.Controls.Add(this.pnlFileUp);
            this.tpFile.Location = new System.Drawing.Point(4, 21);
            this.tpFile.Name = "tpFile";
            this.tpFile.Padding = new System.Windows.Forms.Padding(3);
            this.tpFile.Size = new System.Drawing.Size(978, 551);
            this.tpFile.TabIndex = 0;
            this.tpFile.Text = "文件管理";
            this.tpFile.UseVisualStyleBackColor = true;
            // 
            // lvFiles
            // 
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chSize,
            this.chTime,
            this.chVisibility,
            this.chDesc});
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.Location = new System.Drawing.Point(3, 45);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(972, 503);
            this.lvFiles.TabIndex = 1;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "文件名称";
            this.chName.Width = 200;
            // 
            // chSize
            // 
            this.chSize.Text = "大小";
            this.chSize.Width = 120;
            // 
            // chTime
            // 
            this.chTime.Text = "修改时间";
            this.chTime.Width = 120;
            // 
            // chVisibility
            // 
            this.chVisibility.Text = "可见性";
            this.chVisibility.Width = 100;
            // 
            // chDesc
            // 
            this.chDesc.Text = "描述";
            this.chDesc.Width = 250;
            // 
            // pnlFileUp
            // 
            this.pnlFileUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFileUp.Controls.Add(this.btnDelSelectedFiles);
            this.pnlFileUp.Controls.Add(this.btnDownLoad);
            this.pnlFileUp.Controls.Add(this.cbListViewStyle);
            this.pnlFileUp.Controls.Add(this.pbSearchFile);
            this.pnlFileUp.Controls.Add(this.tbSearchFile);
            this.pnlFileUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFileUp.Location = new System.Drawing.Point(3, 3);
            this.pnlFileUp.Name = "pnlFileUp";
            this.pnlFileUp.Size = new System.Drawing.Size(972, 42);
            this.pnlFileUp.TabIndex = 0;
            // 
            // btnDelSelectedFiles
            // 
            this.btnDelSelectedFiles.Enabled = false;
            this.btnDelSelectedFiles.Location = new System.Drawing.Point(773, 5);
            this.btnDelSelectedFiles.Name = "btnDelSelectedFiles";
            this.btnDelSelectedFiles.Size = new System.Drawing.Size(89, 30);
            this.btnDelSelectedFiles.TabIndex = 5;
            this.btnDelSelectedFiles.Text = "删除选中文件";
            this.btnDelSelectedFiles.UseVisualStyleBackColor = true;
            this.btnDelSelectedFiles.Click += new System.EventHandler(this.btnDelSelectedFiles_Click);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Enabled = false;
            this.btnDownLoad.Location = new System.Drawing.Point(887, 5);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(79, 30);
            this.btnDownLoad.TabIndex = 4;
            this.btnDownLoad.Text = "下载文件";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // cbListViewStyle
            // 
            this.cbListViewStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListViewStyle.FormattingEnabled = true;
            this.cbListViewStyle.Items.AddRange(new object[] {
            "列表",
            "平铺",
            "图标",
            "详细信息"});
            this.cbListViewStyle.Location = new System.Drawing.Point(595, 10);
            this.cbListViewStyle.Name = "cbListViewStyle";
            this.cbListViewStyle.Size = new System.Drawing.Size(90, 20);
            this.cbListViewStyle.TabIndex = 3;
            this.cbListViewStyle.SelectedIndexChanged += new System.EventHandler(this.cbListViewStyle_SelectedIndexChanged);
            // 
            // pbSearchFile
            // 
            this.pbSearchFile.BackgroundImage = global::iDiskClient.Properties.Resources.search_32;
            this.pbSearchFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSearchFile.Location = new System.Drawing.Point(218, 5);
            this.pbSearchFile.Name = "pbSearchFile";
            this.pbSearchFile.Size = new System.Drawing.Size(32, 32);
            this.pbSearchFile.TabIndex = 1;
            this.pbSearchFile.TabStop = false;
            this.pbSearchFile.Click += new System.EventHandler(this.pbSearchFile_Click);
            this.pbSearchFile.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pbSearchFile.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            // 
            // tbSearchFile
            // 
            this.tbSearchFile.Location = new System.Drawing.Point(26, 10);
            this.tbSearchFile.Name = "tbSearchFile";
            this.tbSearchFile.Size = new System.Drawing.Size(180, 21);
            this.tbSearchFile.TabIndex = 0;
            this.tbSearchFile.Text = "输入文件关键字进行搜索";
            this.tbSearchFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchFile_KeyDown);
            this.tbSearchFile.MouseEnter += new System.EventHandler(this.TextBox_MouseEnter);
            this.tbSearchFile.MouseLeave += new System.EventHandler(this.TextBox_MouseLeave);
            // 
            // tpUser
            // 
            this.tpUser.Controls.Add(this.dgvUuserInfo);
            this.tpUser.Controls.Add(this.panel1);
            this.tpUser.Location = new System.Drawing.Point(4, 21);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(978, 551);
            this.tpUser.TabIndex = 1;
            this.tpUser.Text = "用户管理";
            this.tpUser.UseVisualStyleBackColor = true;
            // 
            // dgvUuserInfo
            // 
            this.dgvUuserInfo.AllowUserToAddRows = false;
            this.dgvUuserInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvUuserInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUuserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUuserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.LoginName,
            this.RealName,
            this.Email,
            this.DeleteUser});
            this.dgvUuserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUuserInfo.Location = new System.Drawing.Point(3, 46);
            this.dgvUuserInfo.MultiSelect = false;
            this.dgvUuserInfo.Name = "dgvUuserInfo";
            this.dgvUuserInfo.ReadOnly = true;
            this.dgvUuserInfo.RowHeadersVisible = false;
            this.dgvUuserInfo.RowTemplate.Height = 23;
            this.dgvUuserInfo.Size = new System.Drawing.Size(972, 502);
            this.dgvUuserInfo.TabIndex = 2;
            this.dgvUuserInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUuserInfo_CellMouseClick);
            // 
            // UserId
            // 
            this.UserId.HeaderText = "用户ID";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Width = 80;
            // 
            // LoginName
            // 
            this.LoginName.HeaderText = "登录名";
            this.LoginName.Name = "LoginName";
            this.LoginName.ReadOnly = true;
            this.LoginName.Width = 140;
            // 
            // RealName
            // 
            this.RealName.HeaderText = "真实名称";
            this.RealName.Name = "RealName";
            this.RealName.ReadOnly = true;
            this.RealName.Width = 128;
            // 
            // Email
            // 
            this.Email.HeaderText = "邮箱";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 205;
            // 
            // DeleteUser
            // 
            this.DeleteUser.HeaderText = "删除";
            this.DeleteUser.Name = "DeleteUser";
            this.DeleteUser.ReadOnly = true;
            this.DeleteUser.Width = 80;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pbSearchUser);
            this.panel1.Controls.Add(this.tbUserSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 43);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "浏览用户文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbSearchUser
            // 
            this.pbSearchUser.BackgroundImage = global::iDiskClient.Properties.Resources.search_32;
            this.pbSearchUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSearchUser.Location = new System.Drawing.Point(195, 4);
            this.pbSearchUser.Name = "pbSearchUser";
            this.pbSearchUser.Size = new System.Drawing.Size(32, 32);
            this.pbSearchUser.TabIndex = 1;
            this.pbSearchUser.TabStop = false;
            this.pbSearchUser.Click += new System.EventHandler(this.pbSearchUser_Click);
            this.pbSearchUser.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pbSearchUser.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            // 
            // tbUserSearch
            // 
            this.tbUserSearch.Location = new System.Drawing.Point(27, 10);
            this.tbUserSearch.Name = "tbUserSearch";
            this.tbUserSearch.Size = new System.Drawing.Size(161, 21);
            this.tbUserSearch.TabIndex = 0;
            this.tbUserSearch.Text = "输入用户登录名进行搜索";
            this.tbUserSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUserSearch_KeyDown);
            this.tbUserSearch.MouseEnter += new System.EventHandler(this.TextBox_MouseEnter);
            this.tbUserSearch.MouseLeave += new System.EventHandler(this.TextBox_MouseLeave);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 576);
            this.Controls.Add(this.tcAdmin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理员面板";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.tcAdmin.ResumeLayout(false);
            this.tpFile.ResumeLayout(false);
            this.pnlFileUp.ResumeLayout(false);
            this.pnlFileUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchFile)).EndInit();
            this.tpUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUuserInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAdmin;
        private System.Windows.Forms.TabPage tpFile;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.Panel pnlFileUp;
        private System.Windows.Forms.PictureBox pbSearchFile;
        private System.Windows.Forms.TextBox tbSearchFile;
        private System.Windows.Forms.TabPage tpUser;
        private System.Windows.Forms.DataGridView dgvUuserInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbSearchUser;
        private System.Windows.Forms.TextBox tbUserSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chVisibility;
        private System.Windows.Forms.ColumnHeader chDesc;
        private System.Windows.Forms.ComboBox cbListViewStyle;
        private System.Windows.Forms.Button btnDelSelectedFiles;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteUser;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}