using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCommon;


// Here we will put all interfaces :)
namespace GameAssets
{
    /// <summary>
    /// All clases that inherit this interface can be drawn on the terrain 
    /// </summary>
    public interface IObsticle
    {
        int Width { get; set; }
        int Height { get; set; }
        Bitmap ImageBitmap { get; set; }
        int positionTop { get; set; }
        int positionLeft { get; set; }

        ObsticleType ObsticleType { get; set; }
        //StaticObsticleType StaticObsticleType { set; get; }
    }
}
