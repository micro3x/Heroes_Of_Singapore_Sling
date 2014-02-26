using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        private Game playGame = Game.Instance;

        #region Vars
        private Terrain t;
        private Hero player;
        #endregion

        #region Constructors
        /// <summary>
        /// this is the default constructor called for the initial Screen
        /// </summary>
        public MainScreen()
        {
            
            t = playGame.Map[playGame.CurrentTerrain - 1];
            player = playGame.PlayerHero;
            InitializeComponent();            
            BackgroundImage = t.Background;
            BackgroundImageLayout = ImageLayout.Tile;
            AddObsticles(t.TerrainObsticles);
            menuStrip1.BringToFront();
            this.BackColor = Color.DarkGreen;
            // I created a Custom user control that I don't need but (see next comment)
            HeroDisplayBox heroDisplay = new HeroDisplayBox(
                player.ExploreImage,
                player.Width,
                player.Height,
                player.PositionTop,
                player.PositionLeft
                );
            // Like I said... this is temporary
            this.Controls.Add(heroDisplay);
            // here we attach to the event Move of our hero
            AttachEvents();
            this.Controls[this.Controls.Count - 1].BringToFront();
        }
        #endregion

        #region Methods
        /// <summary>
        /// This Method reads the list of obsticles from the terrain
        /// and creates a control for each list item.
        /// </summary>
        /// <param name="inputObsticles"></param>
        private void AddObsticles(List<Obsticle> inputObsticles)
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
                a.Image = inputObsticle.ExploreImage;
                // make it transperent
                a.BackColor = Color.Transparent;
                a.Name = "tree";
                a.ItemId = i;
                a.Tag = inputObsticle.ToString();
                // what happens when you click the obsticle
                a.MouseClick += AOnClick;
                // finally we put the object on the form
                this.Controls.Add(a);
            }
        }

        private void DetachEvents()
        {
            player.Move -= MoveHero;
            Battle.BattleStart -= this.BattleStartNew;
            Movement.ChangeTerrain -= ChangeScreen;
        }

        private void AttachEvents()
        {
            player.Move += MoveHero;
            Battle.BattleStart += this.BattleStartNew;
            Movement.ChangeTerrain += ChangeScreen;
        }


        #endregion

        #region Event Handelers
        /// <summary>
        /// This method is used to change the screen when you move out of the current one
        /// </summary>
        /// <param name="next">which screen we will display next</param>
        private void ChangeScreen(object sender, ChangeScreenEventArgs e)
        {
            if (InvokeRequired)
            {
                // if we are here this means only this thread can touch our form!
                // So we call the invoke method with the delegate Action and create 
                // an anonimous method to do the job.
                this.Invoke((Action)(() =>
                {
                    Movement.Stop();
                    // create the new screen
                    playGame.CurrentTerrain = e.NextScreen;
                    //t = playGame.Map[playGame.CurrentTerrain - 1];
                    //this.Refresh();
                    MainScreen nextScreenForm1 = new MainScreen();
                    DetachEvents();
                    // display the new screen
                    nextScreenForm1.Show();
                    this.Close();
                    // close the old screen
                }));
            }
            else
            {
                Movement.Stop();
                // create the new screen
                playGame.CurrentTerrain = e.NextScreen;
                //t = playGame.Map[playGame.CurrentTerrain - 1];
                //this.Refresh();
                MainScreen nextScreenForm1 = new MainScreen();
                DetachEvents();
                // display the new screen
                nextScreenForm1.Show();
                this.Close();
                // close the old screen
            }
        }

        void BattleStartNew(object sender, BattleEventArgs e)
        {
            MessageBox.Show("FIGHT!!");
        }

        /// <summary>
        /// Our hero Moved so we must show it on the Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MoveHero(object sender, MoveEventArgs e)
        {
            //player.recieveDamage(5);
            // First we find the DisplayBox
            MainScreen b = this;
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
            else
            {
                a.Top = e.posTop;
                a.Left = e.posLeft;
            }
            // we moved!
        }
        /// <summary>
        /// This happens when you click an objec
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void AOnClick(object sender, MouseEventArgs eventArgs)
        {
            if (eventArgs.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MessageBox.Show(sender.ToString());
            }
            else
            {
                // cast the sender to a control
                var controlClicked = (ObsticleDisplayBox) sender;
                // Here we determine what we clicked.
                // first from the "obsticleClicked" we take the ID of the object from the list
                // then we take the object from the list of obsticles in the terrain and
                // determine it's type :)

                var obsticleClicked = t.TerrainObsticles[controlClicked.ItemId];
                Point centerOfObsticle = new Point(obsticleClicked.PositionLeft + (obsticleClicked.Width / 2),
                    obsticleClicked.PositionTop + (obsticleClicked.Height / 2));
                switch (obsticleClicked.ObsticleType)
                {
                    case ObsticleType.Static:
                        Movement.MoveToPosition(player, centerOfObsticle.Y, centerOfObsticle.X, t.TerrainObsticles);
                        break;
                    case ObsticleType.Creature:
                        Movement.MoveToPosition(player, centerOfObsticle.Y, centerOfObsticle.X, t.TerrainObsticles);
                        // move to position & Fight
                        break;
                    case ObsticleType.Item:
                        Movement.MoveToPosition(player, centerOfObsticle.Y, centerOfObsticle.X, t.TerrainObsticles);
                        // move to position and Take
                        if (Movement.CanTake)
                        {
                            if (player.Inventory.Take(t.TerrainObsticles[controlClicked.ItemId] as Items))
                            {
                                t.TerrainObsticles.RemoveAt(controlClicked.ItemId);
                                this.Controls.Remove(sender as Control);
                                for (int i = Controls.Count - 1; i >= 0 ; i--)
                                {
                                    Type b = Controls[i].GetType();
                                    if (Controls[i].GetType() == typeof(ObsticleDisplayBox))
                                    {
                                        Type a = Controls[i].GetType();
                                        this.Controls.Remove(Controls[i] as ObsticleDisplayBox);
                                    }
                                }
                                AddObsticles(t.TerrainObsticles);
                                this.Refresh();
                            }
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Opens the inventory window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            Movement.Stop();
            //first we close all opened forms if any
            if (this.OwnedForms.Length > 0)
            {
                foreach (var ownedForm in OwnedForms)
                {
                    ownedForm.Close();
                }
            }
            // then we create the inventory form
            InventoryDisplay inv = new InventoryDisplay(player);
            this.AddOwnedForm(inv);
            // set the position on the screen depending on the MainScreen
            //inv.Location = new Point(MainScreen.ActiveForm.Location.X + 10, ActiveForm.Location.Y + 30);
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
            // Heeyyy... Movement Class... I want to move this hero on this terrain to those coordinates
            // And By the way do it step by step... you figure out how!
            Movement.Stop();
            Movement.MoveToPosition(player, e.Y, e.X, t.TerrainObsticles);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Savegame.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                DetachEvents();
                formatter.Serialize(stream, Game.Instance);
                stream.Close();
                AttachEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Savegame.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Game loading = Game.Instance;
                Game loaded = formatter.Deserialize(stream) as Game;
                stream.Close();
                loading.CurrentTerrain = loaded.CurrentTerrain;
                loading.Map = loaded.Map;
                loading.PlayerHero = loaded.PlayerHero;
                MainScreen startMainScreen = new MainScreen();
                startMainScreen.Show();
                DetachEvents();
                this.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Save Game not found!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movement.Stop();
            CharacterSelection heroSelection = new CharacterSelection();
            heroSelection.ShowDialog(this);
            if (heroSelection.DialogResult == DialogResult.OK)
            {
                DetachEvents();
                Terrain[] map = new Terrain[]
                {
                    new Terrain(1), 
                    new Terrain(2), 
                    new Terrain(3), 
                    new Terrain(4), 
                    new Terrain(5), 
                    new Terrain(6), 
                    new Terrain(7), 
                    new Terrain(8), 
                    new Terrain(9), 
                };
                Game initGame = Game.Instance;
                initGame.Map = map;
                initGame.CurrentTerrain = 5;
                MainScreen startMainScreen = new MainScreen();
                startMainScreen.Show();
                this.Close();
            }
        }
        #endregion

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
