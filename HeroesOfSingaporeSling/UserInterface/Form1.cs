using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameAssets;
using UserInterface.UserControls;

namespace UserInterface
{
    public partial class Form1 : Form
    {
        public Terrain t;
        private int nextScreen;
        public Form1()
        {
            t = new Terrain();
            InitializeComponent();
            BackgroundImage = t.Background;
            BackgroundImageLayout = ImageLayout.Tile;
            AddObsticles(t.TerrainObsticles);
            menuStrip1.SetControlZIndex(1000);
            nextScreen = t.TerrainId;
        }

        public Form1(int terrainID)
        {
            t = new Terrain(terrainID);
            
            BackgroundImage = t.Background;
            BackgroundImageLayout = ImageLayout.Tile;
            InitializeComponent();
            AddObsticles(t.TerrainObsticles);
            menuStrip1.SetControlZIndex(1000);
            nextScreen = t.TerrainId;
        }



        public void AddObsticles(List<IObsticle> inputObsticles)
        {
            //t.TerrainObsticles.Sort(new DrawingSort());
            for (int i = 0; i < inputObsticles.Count; i++)
            {
                var inputObsticle = inputObsticles[i];
                ObsticleDisplayBox a = new ObsticleDisplayBox();
                a.Left = inputObsticle.positionLeft;
                a.Top = inputObsticle.positionTop;
                a.Height = inputObsticle.Height;
                a.Width = inputObsticle.Width;
                a.Image = inputObsticle.ImageBitmap;
                a.BackColor = Color.Transparent;
                a.Name = "tree";
                a.ItemId = i;
                a.Click += AOnClick;
                this.Controls.Add(a);
            }
        }

        private void AOnClick(object sender, EventArgs eventArgs)
        {
            var obsticleClicked = (ObsticleDisplayBox)sender;
            
            switch (t.TerrainObsticles[obsticleClicked.ItemId].ObsticleType)
            {
                case ObsticleType.Static:
                    // move to position & Stop
                    MessageBox.Show(String.Format("You Clicked Object ID={0}",obsticleClicked.ItemId));
                    break;
                case ObsticleType.Createre:
                    // move to position & Fight
                    MessageBox.Show(String.Format("You Clicked Object ID={0}", obsticleClicked.ItemId));
                    break;
                case ObsticleType.Item:
                    // move to position and Take
                    MessageBox.Show(String.Format("You Clicked Object ID={0}", obsticleClicked.ItemId));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            if (this.OwnedForms.Length > 0)
            {
                foreach (var ownedForm in OwnedForms)
                {
                    ownedForm.Close();
                }
            }
            Inventory inv = new Inventory();
            this.AddOwnedForm(inv);
            inv.Location = new Point(Form1.ActiveForm.Location.X + 10,ActiveForm.Location.Y + 30);
            inv.ShowDialog();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            

        }

        private void ChangeScreen(int next)
        {
            Form1 nextScreenForm1 = new Form1(next);
            nextScreenForm1.Show();
            this.Close();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            bool changeScreen = false;
            int clickedLeft = e.X;
            int clickedTop = e.Y;
            MessageBox.Show(String.Format("You Clicked Coordinates {{{0}, {1}}}", clickedTop, clickedLeft));

            if (clickedTop < 30)
            {
                nextScreen -= 3;
                changeScreen = true;
            }
            if (clickedTop > 738)
            {
                nextScreen += 3;
                changeScreen = true;
            }
            if (clickedLeft < 30)
            {
                nextScreen -= 1;
                changeScreen = true;
            }
            if (clickedLeft > 994)
            {
                nextScreen += 1;
                changeScreen = true;
            }
            if (changeScreen)
            {
                ChangeScreen(nextScreen);
            }
        }
    }

    public static class ControlExtension
    {
        public static void SetControlZIndex(this Control ctrl, int z)
        {
            ctrl.Parent.Controls.SetChildIndex(ctrl, z);
        }
    }
}
