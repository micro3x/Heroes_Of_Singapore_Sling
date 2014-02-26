using System;
using System.Drawing;
using System.Linq;

namespace GameAssets
{
    public enum MagicType { Fireball, Iceball}

    [Serializable]
    abstract class Magic : Obsticle, IPickable
    {
        private readonly string name;
        private readonly MagicType typeOfMagic;
        private readonly Rectangle inventorySize;
        private readonly Bitmap inventoryImage;
        private readonly Guid id ;

        protected Magic()
        {
 
        }
        protected Magic(string magicName, MagicType type, Bitmap inventoryBitmap)
        {
            name = magicName;
            typeOfMagic = type;
            if (inventoryBitmap.Height % 20 != 0 || inventoryBitmap.Width % 20 != 0)
            {
                inventorySize = new Rectangle(0,0,(inventoryBitmap.Width/20)*20,(inventoryBitmap.Height/20)*20);
            }
            inventoryImage = new Bitmap(inventoryBitmap,inventorySize.Size);//  inventoryBitmap.Clone(inventorySize,new PixelFormat());
            id = Guid.NewGuid();
        }

        public Guid Id
        {
            get { return id; }
        }

        public Bitmap InventoryImage
        {
            get { return inventoryImage; }
        }

        public MagicType TypeOfMagic
        {
            get { return typeOfMagic; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}
