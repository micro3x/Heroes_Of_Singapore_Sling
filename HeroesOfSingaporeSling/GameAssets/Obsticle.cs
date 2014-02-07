using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets
{
    public interface IObsticle
    {
        int Width { get; set; }
        int Height { get; set; }
        Bitmap ImageBitmap { get; set; }
        int positionTop { get; set; }
        int positionLeft { get; set; }

        ObsticleType ObsticleType { get; set; }
    }
    public abstract class Obsticle : IObsticle
    {
        private int height;
        private int width;
        private Bitmap imageBitmap;

        public int Width { get; set; }
        public int Height { get; set; }
        public Bitmap ImageBitmap { get; set; }
        public int positionTop { get; set; }
        public int positionLeft { get; set; }
        public ObsticleType ObsticleType { get; set; }

    }

    public enum ObsticleType
    {
        Static, Createre, Item
    }

    public class DrawingSort : Comparer<IObsticle>
    {
        public override int Compare(IObsticle x, IObsticle y)
        {
            return x.positionTop.CompareTo(y.positionTop) * -1;
        }
    }
}
