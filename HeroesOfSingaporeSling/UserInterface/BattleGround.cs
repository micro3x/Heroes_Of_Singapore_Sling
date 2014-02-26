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
using GameLogic;

namespace UserInterface
{ 
    // Пускам я така за момента.......
    public partial class BattleGround : Form
    {
        // Proparties:
        //private Game playGame = Game.Instance;
        //private Hero player;
        //private Enemy player;
 
        //just for test
        Graphics Visual;
        //int x = 15;
        //int y = 350;
        //just for test the form
        
        // Constructor
        public BattleGround()
        {
            BackgroundMusic.PlayThree();
            BackgroundMusic.PlayTwo();
            BackgroundMusic.PlayOne();
            BackgroundMusic.PlayGo();
            InitializeComponent();
            //
            Visual = CreateGraphics();
            //just test
        }


        // Methods
        private void BattleGround_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Left)// move left
            {
                BackgroundMusic.PlaySteps();
                // This code is only to test the movement
                //
                //Visual.FillRectangle(Brushes.Red, new Rectangle(x, y, 15, 15));
                //x -= 20;
                //Visual.FillRectangle(Brushes.Blue, new Rectangle(x, y, 15, 15));
            }

            if (e.KeyCode == Keys.Right)// move right
            {
                BackgroundMusic.PlaySteps();
                // This code is only to test the movement
                //
                //Visual.FillRectangle(Brushes.Red, new Rectangle(x, y, 15, 15));
                //x += 20;
                //Visual.FillRectangle(Brushes.Blue, new Rectangle(x, y, 15, 15));
            }

            if (e.KeyCode == Keys.B) // Bock - hero use his shield
            {
                BackgroundMusic.PlayPain();
                //TODO:
            }

            if (e.KeyCode == Keys.J) // Jump 
            {

                //TODO:
            }

            if (e.KeyCode == Keys.M) // Trow magic 
            {
                BackgroundMusic.PlayMagic_throw();
                BackgroundMusic.PlayMagic();
                //TODO:
            }

            if (e.KeyCode == Keys.Tab) // Hit 
            {
                BackgroundMusic.PlaySword();
                //TODO:
            }

            if (e.KeyCode == Keys.K) // Kik 
            {
                BackgroundMusic.PlayKik();
                //TODO:
            }
        }

        //private bool IsAlive()
        //{
              //
              //TODO: if some of the fighters loosed, return to main game
        //}
    }
}
