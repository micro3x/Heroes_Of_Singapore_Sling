using System;
using System.Drawing;
using GameCommon;

namespace GameAssets
{
    /// <summary>
    /// This is the abstract class that all types of obsticles will inherit.
    /// </summary>
    public abstract class ImageProperties //: IObsticle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Bitmap ImageBitmap { get; set; }
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }
        public ObsticleType ObsticleType { get; set; }
        
    }
    
}
