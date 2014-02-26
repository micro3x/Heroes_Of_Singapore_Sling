using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using GameAssets;
using GameLogic;

namespace UserInterface
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public Hero HeroId { get; set; }

        private void NewGame_Click(object sender, EventArgs e)
        {
            Game initGame = Game.Instance;
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

            if (initGame.PlayerHero != null)
            {
                initGame.Map = map;
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
