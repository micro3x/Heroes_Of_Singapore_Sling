using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using GameCommon;
using System.Collections.Generic;

namespace GameAssets
{
    [Serializable]
    public class Hero : Creature, IMoveble
    {
        #region Vars
        private int _experiance;
        private int _nextLevelAtExp;

        private int _lvl;
        private int _charPoints;

        private int _baseMaxMana;
        private int _currentMana;

        private int _strenght;
        private int _wisdom;
        private int _vitality;
        private int _agility;

        private HeroInventory inventory;

        private Dictionary<OnCharacterLocation, IWearable> wearingItems = new Dictionary<OnCharacterLocation, IWearable>();

        private List<HeroSpell> availableHeroSpells;


        public event EventHandler<MoveEventArgs> Move;

        protected virtual void OnMove(MoveEventArgs e)
        {
            EventHandler<MoveEventArgs> handler = Move;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<LevelUpEventArgs> LevelUp;

        protected virtual void OnLevevUp(LevelUpEventArgs e)
        {
            EventHandler<LevelUpEventArgs> handler = LevelUp;
            if (handler != null) handler(this, e);
        }

        #endregion

        #region Proparties
        public int GainedExperiance
        {
            get { return _experiance; }
            set
            {
                if (_experiance >= _nextLevelAtExp)
                {
                    NewLevel();
                }
                if (value < 0)
                {
                    _experiance = 0;
                }
                else
                {
                    _experiance = value;
                }
            }
        }

        public int NextLevelAt
        {
            get { return _nextLevelAtExp; }
            private set
            {
                if (_nextLevelAtExp >= value)
                {
                    throw new ArgumentOutOfRangeException("Next LevelUp must require more experiance then the current One");
                }
                _nextLevelAtExp = value;
            }
        }

        public int Level
        {
            get { return _lvl; }
        }

        public int CharPoints
        {
            get { return _charPoints; }
        }

        public int MaxMana
        {
            get
            {
                return _baseMaxMana + (Wisdom*5);
            }
        }

        public int CurrentMana
        {
            get { return _currentMana; }
            set
            {
                if (value > MaxMana)
                {
                    _currentMana = MaxMana;
                }
                else if(value < 0)
                {
                    _currentMana = 0;
                }
                else
                {
                    _currentMana = value;
                }
            }
        }

        public int Agility
        {
            get
            {
                int currentAgility = _agility;
                foreach (var item in WearingItems)
                {
                    currentAgility += item.Value.BonusToAgility;
                }
                return currentAgility;
            }
            set
            {
                if (value < 0)
                {
                    throw new CannotBeNegative("Vitality cannot be a negative value");
                }
                _agility = value;
            }
        }

        public int Vitality
        {
            get
            {
                int currentVitality  = _vitality;
                foreach (var item in WearingItems)
                {
                    currentVitality += item.Value.BonusToVitality;
                }
                return currentVitality;
            }
            set
            {
                if (value < 0)
                {
                    throw new CannotBeNegative("Vitality cannot be a negative value");
                }
                _vitality = value;
            }
        }

        public int Wisdom
        {
            get
            {
                int currentWisdom = _wisdom;
                foreach (var item in WearingItems)
                {
                    currentWisdom += item.Value.BonusToWisdom;
                }
                return currentWisdom;
                
            }
            set
            {
                if (value < 0)
                {
                    throw new CannotBeNegative("Wisdom cannot be a negative value");
                }
                _wisdom = value;
            }
        }

        public int Strenght
        {
            get
            {
                int currentStrenght = _strenght;
                foreach (var item in WearingItems)
                {
                    currentStrenght += item.Value.BonusToStrenght;
                }
                return currentStrenght;
            }
            set
            {
                if (value < 0)
                {
                    throw new CannotBeNegative("Strenght cannot be a negative value");
                }
                _strenght = value;
            }
        }

        public override int MaxHealt
        {
            get
            {
                return base.Healt + (Vitality*5);
            }
            protected set
            {
                base.Healt = value;
            }
        }

        public override int Defence
        {
            get
            {
                int currentDeffence = base.Defence;
                currentDeffence += Strenght*1;
                foreach (var Item in WearingItems)
                {
                    currentDeffence += Item.Value.BonusToDefence;
                }
                return currentDeffence;
            }
        }

        public override int Speed
        {
            get { return base.Speed + (Agility*1); }
        }

        public override int MinDamage
        {
            get
            {
                int currentDemage = base.MinDamage;
                currentDemage += Strenght*1;
                foreach (var Item in WearingItems)
                {
                    currentDemage += Item.Value.BonusToDamage;
                }
                return currentDemage;
            }
        }

        public override int MaxDamage
        {
            get
            {
                int currentDemage = base.MaxDamage;
                currentDemage += Strenght * 1;
                foreach (var Item in WearingItems)
                {
                    currentDemage += Item.Value.BonusToDamage;
                }
                return currentDemage;
            }
        }

        public HeroInventory Inventory
        {
            get { return inventory; }
        }

        public Dictionary<OnCharacterLocation, IWearable> WearingItems
        {
            get
            {
                return wearingItems;
            }
        }

        #endregion

        #region Constructors
        private Hero(string name, int maxHealt, int defence, int speed, int minDamage,
            int maxDamage, int strenght, int vitality, int wisdom, int agility,int maxMana)
            : base(name,maxHealt,defence,speed,minDamage,maxDamage)
        {
            NextLevelAt = 100;
            Strenght = strenght;
            Vitality = vitality;
            Wisdom = wisdom;
            Agility = agility;
            _baseMaxMana = maxMana;
            inventory = new HeroInventory();
        }

        public static Hero Paladin(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("You must provide a name for your Hero");
            Hero paladin = new Hero(name,100,25,2,5,15,5,5,1,2,10);
            paladin.ObsticleType = ObsticleType.Creature;
            paladin.PositionTop = 200;
            paladin.PositionLeft = 200;
            paladin.ExploreImage = new Bitmap(Environment.CurrentDirectory + "\\Images\\Hero\\paladinHero.png", true);
            paladin.Width = paladin.ExploreImage.Width;
            paladin.Height = paladin.ExploreImage.Height;
            paladin.Inventory.Take(WeaponArmor.GetRandomWeaponArmor(60, 43));

            return paladin;
        }

        public static Hero Agent(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("You must provide a name for your Hero");
            Hero paladin = new Hero(name, 80, 20, 5, 1, 5, 2, 2, 5, 3, 10);
            paladin.ObsticleType = ObsticleType.Creature;
            paladin.PositionTop = 200;
            paladin.PositionLeft = 200;
            paladin.ExploreImage = new Bitmap(Environment.CurrentDirectory + "\\Images\\Hero\\hero.png", true);
            paladin.Width = paladin.ExploreImage.Width;
            paladin.Height = paladin.ExploreImage.Height;
            return paladin;
        }

        public static Hero Archer(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("You must provide a name for your Hero");
            Hero archer = new Hero(name, 90, 30, 5, 3, 5, 4, 3, 6, 3, 10);
            archer.ObsticleType = ObsticleType.Creature;
            archer.PositionTop = 200;
            archer.PositionLeft = 200;
            archer.ExploreImage = new Bitmap(Environment.CurrentDirectory + "\\Images\\Hero\\archerHero.png", true);
            archer.Width = archer.ExploreImage.Width;
            archer.Height = archer.ExploreImage.Height;
            return archer;
        }

        public static Hero Mage(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("You must provide a name for your Hero");
            Hero mage = new Hero(name, 80, 35, 5, 4, 5, 3, 4, 7, 4, 10);
            mage.ObsticleType = ObsticleType.Creature;
            mage.PositionTop = 200;
            mage.PositionLeft = 200;
            mage.ExploreImage = new Bitmap(Environment.CurrentDirectory + "\\Images\\Hero\\mageHero.png", true);
            mage.Width = mage.ExploreImage.Width;
            mage.Height = mage.ExploreImage.Height;
            return mage;
        }
        #endregion

        #region Methods
        public void ChangePosition(int newPositionTop, int newPositionLeft)
        {
            OnMove(new MoveEventArgs(newPositionTop, newPositionLeft));
            PositionTop = newPositionTop;
            PositionLeft = newPositionLeft;
        }

        private void NewLevel()
        {
            NextLevelAt = _nextLevelAtExp * 2;
            _lvl += 1;
            _charPoints += 5;
            OnLevevUp(new LevelUpEventArgs(Level, NextLevelAt));
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public bool WearItem(Guid itemId)
        {
            var item = inventory.ContainingItems.First(x => x.Id == itemId) as IWearable;
            if (item != null)
            {
                if (WearingItems.ContainsKey(item.WearLocation))
                {
                    return false;
                }
                WearingItems.Add(item.WearLocation,item);
                inventory.RemoveFromInventory(itemId);
            }
            return false;
        }

        public bool UnWearItem(Guid itemID)
        {
            var keysWithMatchingValues = wearingItems.Where(p =>
            {
                var items = p.Value as Items;
                return items != null && items.Id == itemID;
            }).Select(p => p.Key);
            if (keysWithMatchingValues.Any())
            {
                wearingItems.Remove(keysWithMatchingValues.FirstOrDefault());
                return true;
            }
            return false;
        }

        #endregion
    }
}
