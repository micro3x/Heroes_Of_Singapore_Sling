using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets
{
    public enum ItemType { WeaponArmor, Magical, AmuletRing}
    [Serializable]
    public abstract class Items : Obsticle
    {
        private readonly string name;
        private readonly ItemType typeOfItem;
        private readonly Rectangle inventorySize;
        private readonly Bitmap inventoryImage;

        protected Items(string itemName, ItemType type, Bitmap inventoryBitmap)
        {
            name = itemName;
            typeOfItem = type;
            if (inventoryBitmap.Height % 30 != 0 || inventoryBitmap.Width % 30 != 0)
            {
                inventorySize = new Rectangle(0,0,(inventoryBitmap.Width/30)*30,(inventoryBitmap.Height/30)*30);
            }
            inventoryImage = inventoryBitmap.Clone(inventorySize,new PixelFormat());
        }

        public Bitmap InventoryImage
        {
            get { return inventoryImage; }
        }

        public ItemType TypeOfItem
        {
            get { return typeOfItem; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}
