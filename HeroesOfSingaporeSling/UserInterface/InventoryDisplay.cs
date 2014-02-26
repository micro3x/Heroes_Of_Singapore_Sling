using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameAssets;
using UserInterface.UserControls;

namespace UserInterface
{
    public partial class InventoryDisplay : Form
    {
        //private bool draging = false;
        private Hero myHero;
        public InventoryDisplay(Hero currentHero)
        {
            InitializeComponent();
            myHero = currentHero;
            RefreshInventoryDisplay();

            BackPack.AllowDrop = true;
            BackPack.DragEnter += BackPack_DragEnter;
            BackPack.DragDrop += BackPack_DragDrop;

            WeaponHolder.AllowDrop = true;
            WeaponHolder.DragEnter += WeaponHolder_DragEnter;
            WeaponHolder.DragDrop += WeaponHolder_DragDrop;

            ShieldHolder.AllowDrop = true;
            ShieldHolder.DragEnter += ShieldHolder_DragEnter;
            ShieldHolder.DragDrop += ShieldHolder_DragDrop;
        }



        private void WeaponHolder_DragEnter(object sender, DragEventArgs e)
        {
            var a = (Guid)e.Data.GetData(typeof(Guid));
            var weapon = myHero.Inventory.ContainingItems.FirstOrDefault(w => w.Id == a) as IWearable;
            if (weapon != null)
            {
                if (weapon.WearLocation == OnCharacterLocation.Weapon)
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }
        private void WeaponHolder_DragDrop(object sender, DragEventArgs e)
        {
            var a = (Guid)e.Data.GetData(typeof(Guid));
            var weapon = myHero.Inventory.ContainingItems.FirstOrDefault(w => w.Id == a);
            var www = weapon as IWearable;
            if (www != null)
            {
                if (www.CanWear(myHero))
                {
                    if (www.WearLocation == OnCharacterLocation.Weapon)
                    {
                        myHero.WearItem(a);
                        RefreshInventoryDisplay();
                    }
                }
            }
        }

        private void ShieldHolder_DragEnter(object sender, DragEventArgs e)
        {
            var a = (Guid)e.Data.GetData(typeof(Guid));
            var weapon = myHero.Inventory.ContainingItems.FirstOrDefault(w => w.Id == a) as IWearable;
            if (weapon != null)
            {
                if (weapon.WearLocation == OnCharacterLocation.Shield)
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }
        private void ShieldHolder_DragDrop(object sender, DragEventArgs e)
        {
            var a = (Guid)e.Data.GetData(typeof(Guid));
            var weapon = myHero.Inventory.ContainingItems.FirstOrDefault(w => w.Id == a);
            var www = weapon as IWearable;
            if (www != null)
            {
                if (www.CanWear(myHero))
                {
                    if (www.WearLocation == OnCharacterLocation.Shield)
                    {
                        myHero.WearItem(a);
                        RefreshInventoryDisplay();
                    }
                }
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
            //var a = e.Data.GetData(typeof(Guid));
            e.Effect = DragDropEffects.Move;
        }

        void BackPack_DragDrop(object sender, DragEventArgs e)
        {
            var movingItemId = (Guid)e.Data.GetData(typeof(Guid));
            Items movingItem = myHero.Inventory.ContainingItems.Find(x => x.Id == movingItemId);
            if (movingItem == null)
            {
                movingItem = myHero.WearingItems.Values.FirstOrDefault(x =>
                {
                    var items = x as Items;
                    return items != null && items.Id == movingItemId;
                }) as Items;
                if (myHero.Inventory.DropToInventory(movingItem, e.Y - (Location.Y + BackPack.Top + 30),
                    e.X - (this.Location.X + BackPack.Left + 5)))
                {
                    myHero.UnWearItem(movingItemId);
                    RefreshInventoryDisplay();
                }

            }
            else
            {
                if (myHero.Inventory.DropToInventory(movingItem, e.Y - (Location.Y + BackPack.Top + 30),
                    e.X - (this.Location.X + BackPack.Left + 5), true))
                {
                    var pictureBox = this.Controls.Find(movingItemId.ToString(), true).First() as PictureBox;
                    if (pictureBox != null)
                        pictureBox.Location =
                            new Point(movingItem.PositionLeft, movingItem.PositionTop);
                }
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

        private void RefreshInventoryDisplay()
        {
            foreach (var panel in this.Controls.OfType<Panel>())
            {
                while (panel.Controls.OfType<ObsticleDisplayBox>().Any())
                {
                    foreach (var pb in panel.Controls.OfType<ObsticleDisplayBox>())
                    {
                        panel.Controls.Remove(pb);
                    }
                }
            }

            foreach (var wearingItem in myHero.WearingItems)
            {
                var cL = wearingItem.Key;
                var items = wearingItem.Value as Items;
                var display = new ObsticleDisplayBox()
                {
                    Image = wearingItem.Value.WearImage,
                    Top = 0,
                    Left = 0,
                    Height = wearingItem.Value.WearImage.Height,
                    Width = wearingItem.Value.WearImage.Width,
                    AllowDrop = true,
                    Name = items.Id.ToString(),
                    Tag = wearingItem.Value.ToString(),
                };
                switch (cL)
                {
                    case OnCharacterLocation.Weapon:

                        if (items != null)
                        {
                            display.MouseDown += Item_MouseDown;
                            var panel = Controls.Find("WeaponHolder", true)[0] as Panel;
                            if (panel != null)
                                panel.Controls.Add(display);
                        }
                        break;
                    case OnCharacterLocation.Shield:
                        if (items != null)
                        {
                            display.MouseDown += Item_MouseDown;
                            var panel = Controls.Find("ShieldHolder", true)[0] as Panel;
                            if (panel != null)
                                panel.Controls.Add(display);
                        }
                        break;

                }
            }
            foreach (Items i in myHero.Inventory.ContainingItems)
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

            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    cp.ExStyle |= 0x02000000;
                }
                return cp;
            }
        }
    }
}
