namespace iDiskClient
{
    partial class frmEditFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditFile));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.tbDirtory = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.btnSummit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbbVisivility = new System.Windows.Forms.ComboBox();
            this.ucFormBase1 = new iDiskClient.UC.ucFormBase();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(36, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(36, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "文件大小：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(36, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "可见性：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(36, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "所在目录：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(36, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "描述：";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(119, 60);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(154, 21);
            this.tbFileName.TabIndex = 2;
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(119, 96);
            this.tbSize.Name = "tbSize";
            this.tbSize.ReadOnly = true;
            this.tbSize.Size = new System.Drawing.Size(154, 21);
            this.tbSize.TabIndex = 2;
            // 
            // tbDirtory
            // 
            this.tbDirtory.Location = new System.Drawing.Point(119, 173);
            this.tbDirtory.Name = "tbDirtory";
            this.tbDirtory.ReadOnly = true;
            this.tbDirtory.Size = new System.Drawing.Size(154, 21);
            this.tbDirtory.TabIndex = 2;
            this.tbDirtory.Enter += new System.EventHandler(this.tbDirtory_Enter);
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(119, 210);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(154, 75);
            this.tbDesc.TabIndex = 2;
            // 
            // btnSummit
            // 
            this.btnSummit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSummit.Location = new System.Drawing.Point(91, 291);
            this.btnSummit.Name = "btnSummit";
            this.btnSummit.Size = new System.Drawing.Size(80, 38);
            this.btnSummit.TabIndex = 3;
            this.btnSummit.Text = "确定";
            this.btnSummit.UseVisualStyleBackColor = true;
            this.btnSummit.Click += new System.EventHandler(this.btnSummit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 39);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbbVisivility
            // 
            this.cbbVisivility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVisivility.FormattingEnabled = true;
            this.cbbVisivility.Items.AddRange(new object[] {
            "私有",
            "好友可见",
            "公开"});
            this.cbbVisivility.Location = new System.Drawing.Point(119, 135);
            this.cbbVisivility.Name = "cbbVisivility";
            this.cbbVisivility.Size = new System.Drawing.Size(154, 20);
            this.cbbVisivility.TabIndex = 5;
            // 
            // ucFormBase1
            // 
            this.ucFormBase1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucFormBase1.BackgroundImage")));
            this.ucFormBase1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFormBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFormBase1.Location = new System.Drawing.Point(0, 0);
            this.ucFormBase1.Name = "ucFormBase1";
            this.ucFormBase1.Size = new System.Drawing.Size(348, 342);
            this.ucFormBase1.TabIndex = 0;
            this.ucFormBase1.Load += new System.EventHandler(this.ucFormBase1_Load);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(274, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "(点击选择)";
            // 
            // frmEditFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 342);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbbVisivility);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSummit);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbDirtory);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucFormBase1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文件编辑";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC.ucFormBase ucFormBase1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.TextBox tbDirtory;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Button btnSummit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbbVisivility;
        private System.Windows.Forms.Label label6;
    }
}