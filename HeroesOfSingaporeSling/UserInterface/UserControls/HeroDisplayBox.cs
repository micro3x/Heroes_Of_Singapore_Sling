using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameAssets;

namespace UserInterface.UserControls
{
    public partial class HeroDisplayBox : PictureBox
    {
        public HeroDisplayBox()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Transparent;
            base.ForeColor = Color.Transparent;
            base.BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(e);
            // Call methods of the System.Drawing.Graphics object.
            //e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle);
            e.Graphics.DrawImage(Image,ClientRectangle);
        } 

    }
}
