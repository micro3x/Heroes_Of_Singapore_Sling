using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameAssets;
using UserInterface.UserControls;

namespace UserInterface
{
    public partial class InventoryDisplay : Form
    {
        private bool draging = false;
        private Hero myHero;
        public InventoryDisplay(Hero currentHero)
        {
            
            InitializeComponent();
            myHero = currentHero;
            foreach (Items i in currentHero.Inventory.ContainingItems)
            {
                ObsticleDisplayBox itemDisplay = new ObsticleDisplayBox();
                itemDisplay.Image = i.InventoryImage;
                itemDisplay.Top = i.PositionTop;
                itemDisplay.Left = i.PositionLeft;
                itemDisplay.Height = i.InventoryImage.Height;
                itemDisplay.Width = i.InventoryImage.Width;
                itemDisplay.AllowDrop = true;
                
                itemDisplay.Name = i.Id.ToString();
                itemDisplay.Tag = i.ToString();

                itemDisplay.MouseDown += Item_MouseDown;

                BackPack.Controls.Add(itemDisplay);
                BackPack.AllowDrop = true;
                BackPack.DragEnter += BackPack_DragEnter;
                BackPack.DragDrop += BackPack_DragDrop;

            }
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(sender.ToString());
            }
            else
            {
                if (sender != null)
                {
                    var pictureBox = sender as PictureBox;
                    if (pictureBox != null)
                    {
                        Guid a = Guid.Parse(pictureBox.Name);
                        DoDragDrop(a, DragDropEffects.Move);
                    }
                }
            }
        }

        void BackPack_DragEnter(object sender, DragEventArgs e)
        {
            var a = e.Data.GetData(typeof(Guid));
                e.Effect = DragDropEffects.Move;
        }

        void BackPack_DragDrop(object sender, DragEventArgs e)
        {
            var movingItemId = e.Data.GetData(typeof(Guid));
            Items movingItem = myHero.Inventory.ContainingItems.Find(x => x.Id == (Guid)movingItemId);

            if (myHero.Inventory.DropToInventory(movingItem, e.Y - (Location.Y + BackPack.Top + 30), e.X - (this.Location.X + BackPack.Left + 5), true))
            {
                var pictureBox  = this.Controls.Find(movingItemId.ToString(), true).First() as PictureBox;
                if (pictureBox != null)
                    pictureBox.Location =
                        new Point(movingItem.PositionLeft, movingItem.PositionTop);
            }
        }

        private void InventoryDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control is PictureBox)
                {
                    Controls.Remove(control as PictureBox);
                }
            }
        }

    }
}
