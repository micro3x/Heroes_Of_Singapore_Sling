namespace GameAssets
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum ObsticleType
    {
        Static,
        Creature,
        Item
    }
    /// <summary>
    /// This is the abstract class that all types of obsticles will inherit.
    /// </summary>
    [Serializable]
    public abstract class Obsticle //: IObsticle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Bitmap ExploreImage { get; set; }//coild have image for Map if we make one, and we will make images for battle state of heroe/enemies too
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }
        public ObsticleType ObsticleType { get; set; }
        
    }
    
}
