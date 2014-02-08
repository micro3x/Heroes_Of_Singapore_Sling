using System;
using System.Collections.Generic;
using System.Drawing;
using GameCommon;

namespace GameAssets
{
    /// <summary>
    /// This is the abstract class that all types of obsticles will inherit.
    /// </summary>
    public abstract class Obsticle : IObsticle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Bitmap ImageBitmap { get; set; }
        public int positionTop { get; set; }
        public int positionLeft { get; set; }
        public ObsticleType ObsticleType { get; set; }

    }
    /// <summary>
    /// This is a Comparer that compares two IObsticle type objects
    /// depending on their top position.
    /// 
    /// (This comparer is not currently used but may come in handy 
    /// if we will sort the list of object on the terrain)
    /// </summary>
    public class SortByTopPosition : Comparer<IObsticle>
    {
        public override int Compare(IObsticle x, IObsticle y)
        {
            if (y != null) if (x != null) return x.positionTop.CompareTo(y.positionTop) * -1;
            throw new ArgumentNullException("elements to compare cannot be null");
        }
    }
}
