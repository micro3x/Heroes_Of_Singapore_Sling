using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GameAssets
{
    public enum PotionType { Heal, RestoreMana }

    [Serializable]
    public class MagicItem : Items
    {
        private delegate void ActionWhenUsed(params Creature[] actionParameters);

        private readonly ActionWhenUsed use;

        private readonly Bitmap itemBitmap;

        private readonly string description;

        public MagicItem(string magicName, Bitmap inventoryBitmap, string spellToPerform)
            : base(magicName, ItemType.Magical, inventoryBitmap)
        {
            Used = false;

            switch (spellToPerform)
            {
                    // Todo:
                default:
                    break;
            }
            InventoryImage = itemBitmap;
            ExploreImage = new Bitmap(itemBitmap);
            Width = itemBitmap.Width;
            Height = itemBitmap.Height;
            ObsticleType = ObsticleType.Item;
        }

        public MagicItem(string magicName, PotionType potionType, int restoreValue)
            : base(magicName, ItemType.Magical,new Bitmap(1,1))
        {
            Used = false;
            switch (potionType)
            {
                case PotionType.Heal:
                    use = parameters => {
                                            foreach (Creature actionParameter in parameters)
                                            {
                                                actionParameter.Healt += restoreValue;
                                            }
                    };
                    itemBitmap = new Bitmap(Environment.CurrentDirectory + "\\Images\\Items\\Potions\\HP_Potion.png");
                    description = String.Format("Restores {0} health points.",restoreValue);
                    break;
                case PotionType.RestoreMana:
                    use = parameters => {
                                            foreach (Creature actionParameter in parameters)
                                            {
                                                var hero = actionParameter as Hero;
                                                if (hero != null)
                                                    hero.CurrentMana += restoreValue;
                                            }
                    };
                    itemBitmap = new Bitmap(Environment.CurrentDirectory + "\\Images\\Items\\Potions\\ManaPotion.png");
                    description = String.Format("Restores {0} mana points.", restoreValue);
                    break;
            }
            InventoryImage = itemBitmap;
            ExploreImage = new Bitmap(itemBitmap);
            Width = itemBitmap.Width;
            Height = itemBitmap.Height;
            ObsticleType = ObsticleType.Item;
        }
        public bool Used { get; private set; }

        public void UseItem(Creature useOnCreature)
        {
            use(useOnCreature);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("Name : {0}", Name));
            sb.AppendLine("Desctription:");
            sb.AppendLine(description);
            return sb.ToString();
        }
    }
}
