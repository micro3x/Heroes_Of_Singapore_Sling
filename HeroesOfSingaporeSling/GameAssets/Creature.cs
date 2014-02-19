using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Security.Permissions;
using GameCommon;

namespace GameAssets
{
    [Serializable]
    public abstract class Creature : Obsticle
    {
        private string _name;
        private int _healt;
        private int _maxHealt;

        private int _defence;
        private int _speed;

        private int _minDamage;
        private int _maxDamage;



        protected Creature(string name, int maxHealt, int defence, int speed, int minDamage, int maxDamage)
        {
            Name = name;
            Healt = maxHealt;
            MaxHealt = maxHealt;
            Defence = defence;
            Speed = speed;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public virtual int Healt
        {
            get { return _healt; }
            protected set
            {
                _healt = value;
            }
        }

        public virtual int MaxHealt
        {
            get { return _maxHealt; }
            protected set
            {
                if (value < 1)
                {
                    throw new CannotBeNegative("MaxHealt must be greater then 1");
                }
                _maxHealt = value;
            }
        }

        public virtual int Defence
        {
            get { return _defence; }
            protected set
            {
                if (value >= 0 && value <= 100)
                {
                    _defence = value;    
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Defence is a percent value and must be between 0 and 100");
                }
            }
        }

        public virtual int Speed
        {
            get { return _speed; }
            protected set
            {
                if (value < 0)
                {
                    throw new CannotBeNegative("The value of speed cannot be a negative");
                }
                _speed = value;
            }
        }

        public virtual int MinDamage
        {
            get { return _minDamage; }
            protected set
            {
                if (value < 0)
                {
                    throw new CannotBeNegative("Minimum damage cannot be negative");
                }
                _minDamage = value;
            }
        }

        public virtual int MaxDamage
        {
            get { return _maxDamage; }
            protected set
            {
                if (value < 0)
                {
                    throw new CannotBeNegative("Minimum damage cannot be negative");    
                }
                _maxDamage = value;
            }
        }

        public int GetHitDamage()
        {
            return RandomGenerator.GetRandom(MinDamage, MaxDamage);
        }


    }
}
