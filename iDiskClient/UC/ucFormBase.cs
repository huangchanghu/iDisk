using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iDiskClient.UC
{
    public partial class ucFormBase : UserControl
    {
        public ucFormBase()
        {
            InitializeComponent();
        }


        #region 窗体移动

        int x,
            y;
        bool canMove = false;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons != MouseButtons.Left) return;
            x = e.X;
            y = e.Y;
            canMove = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!canMove) return;
            this.Parent.Top = Cursor.Position.Y - y;
            this.Parent.Left = Cursor.Position.X - x;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            canMove = false;
        } 
        #endregion
    }
}
