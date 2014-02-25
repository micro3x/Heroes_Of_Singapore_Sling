using System;
using System.Drawing;
using System.Linq;

// Here we will put all interfaces :)
namespace GameAssets
{
    /// <summary>
    /// All clases that inherit this interface can be drawn on the terrain 
    /// </summary>
    public interface IDrawable
    {
        int Width { get; set; }
        int Height { get; set; }
        Bitmap ImageBitmap { get; set; }
        int PositionTop { get; set; }
        int PositionLeft { get; set; }

    }
}
