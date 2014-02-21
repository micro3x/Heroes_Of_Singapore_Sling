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
using GameLogic;

namespace UserInterface
{
    public partial class CharacterSelection : Form
    {
        private List<Hero> heroes = new List<Hero>();

        public CharacterSelection()
        {
            InitializeComponent();
            StartGame.DialogResult = DialogResult.OK;
            heroes.Add(Hero.Agent("nonameAgent"));
            heroes.Add(Hero.Paladin("nonamePaladin"));
            HeroesSource.DataSource = heroes;
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            //(this.Owner as StartMenu).HeroId = HeroesSource.Current as Hero;
            Game.Instance.PlayerHero = HeroesSource.Current as Hero;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
