using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameAssets;
using UserInterface.UserControls;
using GameCommon;
using GameLogic;


namespace UserInterface
{
    public partial class MainScreen : Form
    {

        #region Vars
        public Terrain t;
        private int nextScreen;

        // the hero class is not ready so I just create one temp!!!
        // Daniel I know this is ugly... 
        Hero currentHero = new Hero()
        {
            ImageBitmap = new Bitmap(Environment.CurrentDirectory + "\\Images\\Hero\\hero.png", true),
            Height = 50,
            Width = 45,
            PositionTop = 200,
            PositionLeft = 200,
            ObsticleType = ObsticleType.Createre
        };
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


            // I created a Custom user control that I don't need but (see next comment)
            HeroDisplayBox heroDisplay = new HeroDisplayBox();
            // Like I said... this is temporary
            heroDisplay.Name = "hero";
            heroDisplay.Image = currentHero.ImageBitmap;
            heroDisplay.Width = currentHero.Width;
            heroDisplay.Height = currentHero.Height;
            heroDisplay.Top = currentHero.PositionTop;
            heroDisplay.Left = currentHero.PositionLeft;
            heroDisplay.BackColor = Color.Transparent;
            this.Controls.Add(heroDisplay);
            // here we attach to the event Move of our hero
            currentHero.Move += MoveHero;
            this.Controls[this.Controls.Count -1].BringToFront();

        }
        /// <summary>
        /// By calling this constructor we can generate a specific terrain
        /// </summary>
        /// <param name="terrainID">the id of the terrain we want to display </param>
        public MainScreen(int terrainID)
        {
            Terrain t = new Terrain(terrainID);
            
            BackgroundImage = t.Background;
            BackgroundImageLayout = ImageLayout.Tile;
            InitializeComponent();
            AddObsticles(t.TerrainObsticles);
            nextScreen = t.TerrainId;
            menuStrip1.BringToFront();

            // I created a Custom user control that I don't need but (see next comment)
            HeroDisplayBox heroDisplay = new HeroDisplayBox();
            // Like I said... this is temporary
            heroDisplay.Name = "hero";
            heroDisplay.Image = currentHero.ImageBitmap;
            heroDisplay.Width = currentHero.Width;
            heroDisplay.Height = currentHero.Height;
            heroDisplay.Top = currentHero.PositionTop;
            heroDisplay.Left = currentHero.PositionLeft;
            heroDisplay.BackColor = Color.Transparent;
            this.Controls.Add(heroDisplay);
            // here we attach to the event Move of our hero
            currentHero.Move += MoveHero;
            this.Controls[this.Controls.Count - 1].BringToFront();
        }
        #endregion

        #region Methods
        /// <summary>
        /// This Method reads the list of obsticles from the terrain
        /// and creates a control for each list item.
        /// </summary>
        /// <param name="inputObsticles"></param>
        private void AddObsticles(List<ImageProperties> inputObsticles)
        {
            //t.TerrainObsticles.Sort(new DrawingSort());
            for (int i = 0; i < inputObsticles.Count; i++)
            {
                // here we take the obsticle
                var inputObsticle = inputObsticles[i];
                // now we create the Control and set the proparties
                ObsticleDisplayBox a = new ObsticleDisplayBox();
                // position
                a.Left = inputObsticle.PositionLeft;
                a.Top = inputObsticle.PositionTop;
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
            Movement.Stop();
            // display the new screen
            nextScreenForm1.Show();
            // close the old screen
            this.Close();
        }
        #endregion

        #region Event Handelers
        /// <summary>
        /// Our hero Moved so we must show it on the Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MoveHero(object sender, MoveEventArgs e)
        {
            // First we find the DisplayBox
            HeroDisplayBox a = (HeroDisplayBox)this.Controls.Find("hero", true)[0];
            // Since this event is happening in some other Thread (the timer thread)
            // we check if some other thread can do something on our Form
            if (InvokeRequired)
            {
                // if we are here this means only this thread can touch our form!
                // So we call the invoke method with the delegate Action and create 
                // an anonimous method to do the job.
                this.Invoke((Action)(() =>
                {
                    a.Top = e.posTop;
                    a.Left = e.posLeft;
                }));
            }
            // we moved!
        }
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
            // if we clicked on the border
            // we prepare to change the screen

            // Heeyyy... Movement Class... I want to move this hero on this terrain to those coordinates
            // And By the way do it step by step... you figure out how!
            Movement.MoveToPosition(currentHero , e.Y, e.X, t.TerrainObsticles);

            // this will probably go away! 
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
