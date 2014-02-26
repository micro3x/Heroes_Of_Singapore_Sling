﻿using System;
using System.Linq;
using System.Text;

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

        private int _attackSpeed;
        private int _attackRating;
        private int _defenceRating;

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

        public int DefenceRating
        {
            get
            {
                return this._defenceRating;
            }
            set
            {
                this._defenceRating = value;
            }
        }

        public int AttackRating
        {
            get
            {
                return this._attackRating;
            }
            set
            {
                this._attackRating = value;
            }
        }

        public int AttackSpeed
        {
            get
            {
                return this._attackSpeed;
            }
            set
            {
                this._attackSpeed = value;
            }
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
            set
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
                    throw new ArgumentOutOfRangeException("MaxHealt must be greater then 1");
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
                    throw new ArgumentOutOfRangeException("The value of speed cannot be a negative");
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
                    throw new ArgumentOutOfRangeException("Minimum damage cannot be negative");
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
                    throw new ArgumentOutOfRangeException("Minimum damage cannot be negative");    
                }
                _maxDamage = value;
            }
        }

        public int MakeDamage()
        {
            return RandomGenerator.GetRandom(MinDamage, MaxDamage);
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