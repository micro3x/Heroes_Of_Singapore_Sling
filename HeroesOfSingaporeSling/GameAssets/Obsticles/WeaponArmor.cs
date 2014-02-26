using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets
{
    public enum OnCharacterLocation{ Head, Kneese, Tourso, Legs, Hands, Weapon, Shield }
    public enum BonusType { Demage, Defence, Strenght, Agility, Vitality, Wisdom }

    [Serializable]
    public class WeaponArmor : Items, IWearable
    {
        private readonly OnCharacterLocation wearLocation;
        private readonly List<Tuple<BonusType, int>> bonuses = new List<Tuple<BonusType, int>>();
        private readonly Dictionary<string,int> requires = new Dictionary<string, int>(4)
        {
            {"Strenght",0},
            {"Agility",0},
            {"Vitality",0},
            {"Wisdom",0}
        };

        public WeaponArmor(string name, Bitmap invImage, OnCharacterLocation wearCharacterLocation, params Tuple<string,int>[] reqNameAndValue) 
            : base(name, ItemType.WeaponArmor, invImage)
        {
            wearLocation = wearCharacterLocation;
            foreach (var requirement in reqNameAndValue)
            {
                try
                {
                    requires[requirement.Item1] += requirement.Item2;
                }
                catch (KeyNotFoundException)
                {
                    // log event
                    continue;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            base.ExploreImage = new Bitmap(InventoryImage, new Size(50, 50));
            base.Width = 50;
            base.Height = 50;
            base.ObsticleType = ObsticleType.Item;
        }

        public static WeaponArmor GetRandomWeaponArmor(int top,int left)
        {
            string name = "";
            string imageFile = "";
            OnCharacterLocation wearCharacterLocation;
            var reqTuples = new List<Tuple<string, int>>();
            string bonuses = string.Empty;

            int itemsCount = new DirectoryInfo(Environment.CurrentDirectory + "\\WeaponArmor").EnumerateFiles().Count();
            int randomItemID = RandomGenerator.GetRandom(1, itemsCount + 1);
            var sw = new StreamReader(Environment.CurrentDirectory + "\\WeaponArmor\\" + randomItemID + ".item");
            using (sw)
            {
                try
                {
                    name = sw.ReadLine();
                    imageFile = Environment.CurrentDirectory + sw.ReadLine();
                    wearCharacterLocation = (OnCharacterLocation)int.Parse(sw.ReadLine());
                    string[] req = sw.ReadLine().Split(',');
                    foreach (string s in req)
                    {
                        string[] values = s.Split(' ');
                        reqTuples.Add(new Tuple<string, int>(values[0], int.Parse(values[1])));
                    }
                    bonuses = sw.ReadLine();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
            var output = new WeaponArmor(name, new Bitmap(imageFile), wearCharacterLocation, reqTuples.ToArray());
            if (!string.IsNullOrEmpty(bonuses))
            {
                string[] bonusToImport = bonuses.Split(',');
                foreach (string s in bonusToImport)
                {
                    int[] values = s.Split(' ').Select(int.Parse).ToArray();
                    output.Bonuses.Add(new Tuple<BonusType, int>((BonusType)values[0],values[1]));
                }
            }
            output.PositionTop = top;
            output.PositionLeft = left;
            return output;
        }

        public OnCharacterLocation WearLocation { get { return wearLocation; } }

        public int RequireStrenght { get { return requires["Strenght"]; } }
        public int RequireAgility { get { return requires["Agility"]; } }
        public int RequireVitality { get { return requires["Vitality"]; } }
        public int RequireWisdom { get { return requires["Wisdom"]; } }

        public Bitmap WearImage { get { return new Bitmap(InventoryImage, new Size(50, 50)); } }

        public List<Tuple<BonusType, int>> Bonuses
        {
            get { return bonuses; }
        }

        public int BonusToDamage
        {
            get
            {
                return bonuses.FindAll(x => x.Item1 == BonusType.Demage).Sum(x => x.Item2);
            }
        }

        public int BonusToDefence
        {
            get
            {
                return bonuses.FindAll(x => x.Item1 == BonusType.Defence).Sum(x => x.Item2);
            }
        }

        public int BonusToStrenght
        {
            get
            {
                return bonuses.FindAll(x => x.Item1 == BonusType.Strenght).Sum(x => x.Item2);
            }
        }

        public int BonusToAgility
        {
            get
            {
                return bonuses.FindAll(x => x.Item1 == BonusType.Agility).Sum(x => x.Item2);
            }
        }

        public int BonusToVitality
        {
            get 
            {
                return bonuses.FindAll(x => x.Item1 == BonusType.Vitality).Sum(x => x.Item2);
            }
        }

        public int BonusToWisdom
        {
            get
            {
                return bonuses.FindAll(x => x.Item1 == BonusType.Wisdom).Sum(x => x.Item2);
            }
        }

        public bool CanWear(Hero hero)
        {
            if (hero.Strenght >= requires["Strenght"] && hero.Agility >= requires["Agility"] &&
                hero.Vitality >= requires["Vitality"] && hero.Wisdom >= requires["Wisdom"])
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Name".PadRight(10) + Name));
            sb.AppendLine();
            sb.AppendLine("Gives:");
            if (BonusToDamage != 0) sb.AppendLine(string.Format("{0,-10}{1}","Damage",BonusToDamage != 0 ? String.Format("+{0}",BonusToDamage):BonusToDamage.ToString()));
            if (BonusToDefence != 0) sb.AppendLine(string.Format("{0,-10}{1}", "Defence", BonusToDefence != 0 ? String.Format("+{0}", BonusToDefence) : BonusToDefence.ToString()));
            if (BonusToStrenght != 0) sb.AppendLine(string.Format("{0,-10}{1}", "Strenght", BonusToStrenght != 0 ? String.Format("+{0}", BonusToStrenght) : BonusToStrenght.ToString()));
            if (BonusToAgility != 0) sb.AppendLine(string.Format("{0,-10}{1}", "Agility", BonusToAgility != 0 ? String.Format("+{0}", BonusToAgility) : BonusToAgility.ToString()));
            if (BonusToVitality != 0) sb.AppendLine(string.Format("{0,-10}{1}", "Vitality", BonusToVitality != 0 ? String.Format("+{0}", BonusToVitality) : BonusToVitality.ToString()));
            if (BonusToWisdom != 0) sb.AppendLine(string.Format("{0,-10}{1}", "Wisdom", BonusToWisdom != 0 ? String.Format("+{0}", BonusToWisdom) : BonusToWisdom.ToString()));
            sb.AppendLine();
            sb.AppendLine("Reqiures:");
            if (requires["Strenght"] != 0) sb.AppendLine(string.Format("{0,-10}{1}", "Strenght", requires["Strenght"]));
            if (requires["Agility"] != 0) sb.AppendLine(string.Format("{0,-10}{1}", "Agility", requires["Agility"]));
            if (requires["Vitality"] != 0) sb.AppendLine(string.Format("{0,-10}{1}", "Vitality", requires["Vitality"]));
            if (requires["Wisdom"] != 0) sb.AppendLine(string.Format("{0,-10}{1}", "Wisdom", requires["Wisdom"]));
            return sb.ToString();
        }
    }
}
