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

        private static List<Item> item { get; set; }

        //Constructors
        #region
        public Hero()
        {

        }



        /*public Hero(string name, int experience, int bonus, int healt, int speed, int strengt,
            List<Item> item, List<HeroType> heroType)
        {
            this.Name = name;
            this.Experiance = experience;
            this.Bonus = bonus;
            //this.Healt = healt;
            this.Speed = speed;
            this.Strengt = strengt;
            List<Item> Item = new List<Item>();
            List<HeroType> HeroType = new List<HeroType>();
        }*/
        #endregion

        // Properties
        #region
        private string expiriance;
        private string level;

        public string Experiance
        {
            get { return expiriance; }
            set
            {
                expiriance = value;
            }
        }

        public string Level
        {
            get { return level; }
            set
            {
                level = value;
            }
        }

        #endregion

        // Methods
        #region



        public void GainExperiance(int gainedExperiance)
        {
            Experiance = Experiance + gainedExperiance;//TODO check if gained lvl - if(Gainedlvl) {Level increase}
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
