using System;
using System.Linq;
using GameCommon;
using System.Collections.Generic;

namespace GameAssets
{
    
    public class Hero : Creature, IMoveble
    {
        public event EventHandler<MoveEventArgs> Move;

        protected virtual void OnMove(MoveEventArgs e)
        {
            EventHandler<MoveEventArgs> handler = Move;
            if (handler != null) handler(this, e);
        }
        public void ChangePosition(int newPositionTop, int newPositionLeft)
        {
            OnMove(new MoveEventArgs(newPositionTop, newPositionLeft));
            PositionTop = newPositionTop;
            PositionLeft = newPositionLeft;
        }

        //...........I`m not really sure about the code.......but must to try something.......

        private string name;
        private int experience;
        private int bonus;
        private int healt;
        private int speed;
        private int strengt;
        private static List<Item> item { get; set; }
        private static List<HeroType> heroType { get; set; }

        //Constructors
        #region
        public Hero()
        {

        }

        public Hero(string name, List<HeroType> heroType)
        {
            this.name = Name;
            List<HeroType> HeroType = new List<HeroType>();
        }

        public Hero(string name, int experience, int bonus, int healt, int speed, int strengt,
            List<Item> item, List<HeroType> heroType)
        {
            this.Name = name;
            this.Experiance = experience;
            this.Bonus = bonus;
            this.Healt = healt;
            this.Speed = speed;
            this.Strengt = strengt;
            List<Item> Item = new List<Item>();
            List<HeroType> HeroType = new List<HeroType>();
        }
        #endregion

        // Properties
        #region
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be nullable, whitespace or empty!");
                }
                this.name = value;
            }
        }

        public int Experiance
        {
            get { return this.experience; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Score can't be negative!");
                }
                this.experience = value;
            }
        }

        public int Bonus
        {
            get { return this.bonus; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Bonus can't be negative!");
                }
                this.bonus = value;
            }
        }

        public int Healt
        {
            get { return this.healt; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Healt can't be negative!");
                }
                this.healt = value;
            }
        }

        public int Speed
        {
            get { return this.speed; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Speed can't be negative!");
                }
                this.speed = value;
            }
        }

        public int Strengt
        {
            get { return this.strengt; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Strengt can't be negative!");
                }
                this.strengt = value;
            }
        }
        #endregion


        // Methods
        #region

        public void gainDamage(int healt)
        {
            // TODO:
        }

        public void gainExperience(int experiance)
        {
            // TODO:
        }

        public void getCurrentItem(List<Item> item)
        {
            // TODO:
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
