namespace GameAssets
{
    using System;
    using System.Drawing;
    using System.Linq;

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
    public abstract class Obsticle : IDrawable
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public Bitmap ExploreImage { get; set; }//coild have image for Map if we make one, and we will make images for battle state of heroe/enemies too
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }
        public ObsticleType ObsticleType { get; protected set; }
        
    }
    
}
