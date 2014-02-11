using System;
using System.Collections.Generic;
using System.Linq;

namespace GameAssets
{
    /// <summary>
    /// This is a Comparer that compares two IObsticle type objects
    /// depending on their top position.
    /// 
    /// (This comparer is not currently used but may come in handy 
    /// if we will sort the list of object on the terrain)
    /// </summary>
    public class SortByTopPosition : Comparer<ImageProperties>
    {
        public override int Compare(ImageProperties x, ImageProperties y)
        {
            if (y != null) if (x != null) return x.PositionTop.CompareTo(y.PositionTop) * -1;
            throw new ArgumentNullException("elements to compare cannot be null");
        }
    }
}
