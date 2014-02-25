using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets
{
    [Serializable]
    class Enemy : Creature
    {
        private Enemy(string name, int maxHealt, int defence, int speed, int minDamage, int maxDamage) 
            : base(name, maxHealt, defence, speed, minDamage, maxDamage)
        {
        }

        public static Enemy Zombie(int top, int left)
        {
            return new Enemy("Zombie",80,5,1,3,6)
            {
                ExploreImage = new Bitmap(Environment.CurrentDirectory + "\\Images\\Enemies\\zombie.png"),
                Width = 50, Height = 97,PositionTop = top,PositionLeft = left,ObsticleType = ObsticleType.Creature
            };
        }

        public static Enemy Monster(int top, int left)
        {
            return new Enemy("newMon11", 100, 4, 2, 4, 7)
            {
                ExploreImage = new Bitmap(Environment.CurrentDirectory + "\\Images\\Enemies\\newMon3.png"),
                Width = 79,
                Height = 79,
                PositionTop = top,
                PositionLeft = left,
                ObsticleType = ObsticleType.Creature
            };
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
