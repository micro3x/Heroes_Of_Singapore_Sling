using System;
using System.Drawing;
using System.Linq;

namespace GameAssets
{
    public enum ItemType { WeaponArmor, Magical, AmuletRing}
    [Serializable]
    public abstract class Items : Obsticle, IPickable
    {
        private readonly string name;
        private readonly ItemType typeOfItem;
        private readonly Rectangle inventorySize;
        private Bitmap inventoryImage;
        private readonly Guid id ;

        protected Items(string itemName, ItemType type, Bitmap inventoryBitmap)
        {
            name = itemName;
            typeOfItem = type;
            if (inventoryBitmap.Height % 20 != 0 || inventoryBitmap.Width % 20 != 0)
            {
                inventorySize = new Rectangle(0,0,(inventoryBitmap.Width/20)*20,(inventoryBitmap.Height/20)*20);
            }
            if (inventorySize.Size != new Size(0, 0))
            {
                inventoryImage = new Bitmap(inventoryBitmap, inventorySize.Size);
                    //  inventoryBitmap.Clone(inventorySize,new PixelFormat());
            }
            id = Guid.NewGuid();
        }


        public Guid Id
        {
            get { return id; }
        }

        public Bitmap InventoryImage
        {
            get { return inventoryImage; }
            protected set { inventoryImage = value; }
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
