using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;
using GameAssets;

namespace UserInterface
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public Hero HeroId { get; set; }

        private void NewGame_Click(object sender, EventArgs e)
        {
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
            CharacterSelection heroSelection = new CharacterSelection();
            heroSelection.ShowDialog(this);

            if (this.HeroId != null)
            {
                Game initGame = Game.Instance;
                initGame.Map = map;
                initGame.PlayerHero = HeroId;
                initGame.CurrentTerrain = 5;

                MainScreen startMainScreen = new MainScreen();
                startMainScreen.Show();
                this.Close();
            }
        }

        private void LoadGame_Click(object sender, EventArgs e)
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
    }
}
