using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.UserControls
{
    public partial class ObsticleDisplayBox : PictureBox
    {
        private int itemID;

        public int ItemId
        {
            get { return itemID; }
            set { itemID = value; }
        }
    }
}
