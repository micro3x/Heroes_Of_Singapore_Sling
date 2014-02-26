﻿using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GameAssets
{
    [Serializable]
    public class Enemy : Creature
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
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("Name: {0}", Name));
            sb.AppendLine();
            sb.AppendLine("Type: Hostile");
            sb.AppendLine();
            sb.AppendLine(String.Format("Health Points: {0}", MaxHealt));
            sb.AppendLine(String.Format("Damage: {0}-{1}", MinDamage, MaxDamage));
            sb.AppendLine(String.Format("Deffence: {0}%", Defence));
            sb.AppendLine(String.Format("Speed: {0}", Speed));
            return sb.ToString();
        }
    }
}
