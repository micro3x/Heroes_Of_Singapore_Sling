using System;
using System.Drawing;
using System.Linq;

namespace GameAssets
{
    /// <summary>
    /// Used to get the background for the MainScreen
    /// </summary>
    public class Background : ImageProperties
    {
        #region Proparties
        public Bitmap BackgroundImage
        {
           get { return ImageBitmap; }
        }
        #endregion
       
        #region Constructors
        public Background(GameCommon.BackgroundType backgroundType)
        {
            BuildBackground(Environment.CurrentDirectory + GameCommon.ImagePaths.BackgroundImagePathDict[backgroundType]);
        }
        #endregion

        #region Methods
       
        /// <summary>
        /// Sets the image propartie
        /// </summary>
        private void BuildBackground(string fileLocation)
        {
            Image image = Image.FromFile(fileLocation);
            Height = image.Height;
            Width = image.Width;
            ImageBitmap = new Bitmap(Height, Width);
            Graphics.FromImage(ImageBitmap).DrawImage(image, new Point(0, 0));
        }
        #endregion
    }
}
