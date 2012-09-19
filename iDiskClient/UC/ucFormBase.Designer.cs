namespace iDiskClient.UC
{
    partial class ucFormBase
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbY = new System.Windows.Forms.Label();
            this.lbX = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lbY);
            this.panel1.Controls.Add(this.lbX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 31);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(62, 4);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(0, 12);
            this.lbY.TabIndex = 1;
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(4, 4);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(0, 12);
            this.lbX.TabIndex = 0;
            // 
            // ucFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iDiskClient.Properties.Resources.背景_浅蓝;
            this.Controls.Add(this.panel1);
            this.Name = "ucFormBase";
            this.Size = new System.Drawing.Size(358, 464);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.Label lbX;
    }
}
