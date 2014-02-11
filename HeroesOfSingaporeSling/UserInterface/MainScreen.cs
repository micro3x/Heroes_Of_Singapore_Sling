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
using GameCommon;

namespace UserInterface
{
    public partial class MainScreen : Form
    {

        #region Vars
        public Terrain t;
        private int nextScreen;
        #endregion

        #region Constructors
        /// <summary>
        /// this is the default constructor called for the initial Screen
        /// </summary>
        public MainScreen()
        {
            t = new Terrain();
            InitializeComponent();
            BackgroundImage = t.Background;
            BackgroundImageLayout = ImageLayout.Tile;
            AddObsticles(t.TerrainObsticles);
            menuStrip1.SetControlZIndex(1000);
            nextScreen = t.TerrainId;

        }
        /// <summary>
        /// By calling this constructor we can generate a specific terrain
        /// </summary>
        /// <param name="terrainID">the id of the terrain we want to display </param>
        public MainScreen(int terrainID)
        {
            t = new Terrain(terrainID);
            
            BackgroundImage = t.Background;
            BackgroundImageLayout = ImageLayout.Tile;
            InitializeComponent();
            AddObsticles(t.TerrainObsticles);
            nextScreen = t.TerrainId;
            menuStrip1.BringToFront();
        }
        #endregion

        #region Methods
        /// <summary>
        /// This Method reads the list of obsticles from the terrain
        /// and creates a control for each list item.
        /// </summary>
        /// <param name="inputObsticles"></param>
        private void AddObsticles(List<IObsticle> inputObsticles)
        {
            //t.TerrainObsticles.Sort(new DrawingSort());
            for (int i = 0; i < inputObsticles.Count; i++)
            {
                // here we take the obsticle
                var inputObsticle = inputObsticles[i];
                // now we create the Control and set the proparties
                ObsticleDisplayBox a = new ObsticleDisplayBox();
                // position
                a.Left = inputObsticle.positionLeft;
                a.Top = inputObsticle.positionTop;
                // dimentions
                a.Height = inputObsticle.Height;
                a.Width = inputObsticle.Width;
                // image
                a.Image = inputObsticle.ImageBitmap;
                // make it transperent
                a.BackColor = Color.Transparent;
                a.Name = "tree";
                a.ItemId = i;
                // what happens when you click the obsticle
                a.Click += AOnClick;
                // finally we put the object on the form
                this.Controls.Add(a);
            }
        }
        /// <summary>
        /// This method is used to change the screen when you move out of the current one
        /// </summary>
        /// <param name="next">which screen we will display next</param>
        private void ChangeScreen(int next)
        {
            // create the new screen
            MainScreen nextScreenForm1 = new MainScreen(next);
            // display the new screen
            nextScreenForm1.Show();
            // close the old screen
            this.Close();
        }
        #endregion

        #region Event Handelers
        /// <summary>
        /// This happens when you click an objec
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void AOnClick(object sender, EventArgs eventArgs)
        {
            // cast the sender to a control
            var obsticleClicked = (ObsticleDisplayBox)sender;
            // Here we determine what we clicked.
            // first from the "obsticleClicked" we take the ID of the object from the list
            // then we take the object from the list of obsticles in the terrain and
            // determine it's type :)
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

        /// <summary>
        /// Opens the inventory window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            //first we close all opened forms if any
            if (this.OwnedForms.Length > 0)
            {
                foreach (var ownedForm in OwnedForms)
                {
                    ownedForm.Close();
                }
            }
            // then we create the inventory form
            Inventory inv = new Inventory();
            this.AddOwnedForm(inv);
            // set the position on the screen depending on the MainScreen
            inv.Location = new Point(MainScreen.ActiveForm.Location.X + 10,ActiveForm.Location.Y + 30);
            // Display the inventory
            inv.ShowDialog();
        }

        /// <summary>
        /// Quit the Game :)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// If you click somewhere this happens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainScreen_MouseClick(object sender, MouseEventArgs e)
        {
            // where did we click
            bool changeScreen = false;
            int clickedLeft = e.X;
            int clickedTop = e.Y;
            // Show message with coordinates (to be removed
            MessageBox.Show(String.Format("You Clicked Coordinates {{{0}, {1}}}", clickedTop, clickedLeft));
            // if we clicked on the border
            // we prepare to change the screen
            if (clickedTop < 30)
            {
                // calculate the next screen
                nextScreen -= 3;
                // We will change the screen
                // because we clicked on a border
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
                // Calling the ChangeScreen if we clicked on a border
                ChangeScreen(nextScreen);
            }
        }
        #endregion
    }
}
