using System;
using System.Linq;
using System.Text;
using GameAssets.Interfaces;

namespace GameAssets
{

    [Serializable]
    public abstract class Creature : Obsticle, IFightable
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

        protected Creature(string name, int maxHealt, int defence, int speed, int minDamage, int maxDamage , int attackRating, int attackSpeed)
        {
            Name = name;
            Healt = maxHealt;
            MaxHealt = maxHealt;
            Defence = defence;
            Speed = speed;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            _attackRating = attackRating;
            _attackSpeed = attackSpeed;

        }

        // promqna bez setter
        // v get trqbva da se izchislqva
        // virtualen zaradi geroq
        public virtual int DefenceRating
        {
            get
            {
                return this._defenceRating;
            }
            protected set { _defenceRating = value; }
        }

        // promqna bez setter
        // v get trqbva da se izchislqva
        // virtualen zaradi geroq
        public virtual int AttackRating
        {
            get
            {
                return this._attackRating;
            }
            protected set { _attackRating = value; }
        }
        // nikoi ne go instancira sledovatekno vinagi shte e 0
        public virtual int AttackSpeed
        {
            get
            {
                return this._attackSpeed;
            }
            protected set
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
                    // kude e moq exception class?
                    throw new HeroPropartieOutOfRange("MaxHealt must be greater then 1");
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
                    throw new HeroPropartieOutOfRange("Defence is a percent value and must be between 0 and 100");
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
                    throw new HeroPropartieOutOfRange("The value of speed cannot be a negative");
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
                    throw new HeroPropartieOutOfRange("Minimum damage cannot be negative");
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
                    throw new HeroPropartieOutOfRange("Minimum damage cannot be negative");
                }
                _maxDamage = value;
            }
        }

        public int MakeDamage()
        {
            return RandomGenerator.GetRandom(MinDamage, MaxDamage);
        }

    }
}
