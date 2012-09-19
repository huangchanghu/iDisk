namespace iDiskClient
{
    partial class frmEditDirtory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditDirtory));
            this.ucFormBase1 = new iDiskClient.UC.ucFormBase();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDirName = new System.Windows.Forms.TextBox();
            this.tbParentDir = new System.Windows.Forms.TextBox();
            this.tbDirDesc = new System.Windows.Forms.TextBox();
            this.btnSummit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelectParDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucFormBase1
            // 
            this.ucFormBase1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucFormBase1.BackgroundImage")));
            this.ucFormBase1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFormBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFormBase1.Location = new System.Drawing.Point(0, 0);
            this.ucFormBase1.Name = "ucFormBase1";
            this.ucFormBase1.Size = new System.Drawing.Size(353, 302);
            this.ucFormBase1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(32, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "目录名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(32, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "上级目录：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(32, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "描述：";
            // 
            // tbDirName
            // 
            this.tbDirName.Location = new System.Drawing.Point(109, 54);
            this.tbDirName.Name = "tbDirName";
            this.tbDirName.Size = new System.Drawing.Size(179, 21);
            this.tbDirName.TabIndex = 2;
            // 
            // tbParentDir
            // 
            this.tbParentDir.Location = new System.Drawing.Point(109, 90);
            this.tbParentDir.Name = "tbParentDir";
            this.tbParentDir.ReadOnly = true;
            this.tbParentDir.Size = new System.Drawing.Size(179, 21);
            this.tbParentDir.TabIndex = 2;
            // 
            // tbDirDesc
            // 
            this.tbDirDesc.Location = new System.Drawing.Point(109, 128);
            this.tbDirDesc.Multiline = true;
            this.tbDirDesc.Name = "tbDirDesc";
            this.tbDirDesc.Size = new System.Drawing.Size(179, 98);
            this.tbDirDesc.TabIndex = 2;
            // 
            // btnSummit
            // 
            this.btnSummit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSummit.Location = new System.Drawing.Point(81, 247);
            this.btnSummit.Name = "btnSummit";
            this.btnSummit.Size = new System.Drawing.Size(78, 39);
            this.btnSummit.TabIndex = 3;
            this.btnSummit.Text = "确定";
            this.btnSummit.UseVisualStyleBackColor = true;
            this.btnSummit.Click += new System.EventHandler(this.btnSummit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(190, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 39);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelectParDir
            // 
            this.btnSelectParDir.Location = new System.Drawing.Point(295, 89);
            this.btnSelectParDir.Name = "btnSelectParDir";
            this.btnSelectParDir.Size = new System.Drawing.Size(46, 23);
            this.btnSelectParDir.TabIndex = 4;
            this.btnSelectParDir.Text = "选择";
            this.btnSelectParDir.UseVisualStyleBackColor = true;
            this.btnSelectParDir.Click += new System.EventHandler(this.btnSelectParDir_Click);
            // 
            // frmEditDirtory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 302);
            this.Controls.Add(this.btnSelectParDir);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSummit);
            this.Controls.Add(this.tbDirDesc);
            this.Controls.Add(this.tbParentDir);
            this.Controls.Add(this.tbDirName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucFormBase1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditDirtory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmEditDirtory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC.ucFormBase ucFormBase1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDirName;
        private System.Windows.Forms.TextBox tbParentDir;
        private System.Windows.Forms.TextBox tbDirDesc;
        private System.Windows.Forms.Button btnSummit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectParDir;
    }
}