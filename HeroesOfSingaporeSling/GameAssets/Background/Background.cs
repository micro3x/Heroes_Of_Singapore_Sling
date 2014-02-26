using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameAssets
{
    public enum BackgroundType
    {
        Grass, Water, SomethingElse
    }

    /// <summary>
    /// Used to get the background for the MainScreen
    /// </summary>
    [Serializable]
    public class Background : Obsticle
    {
        public static Dictionary<BackgroundType, string> BackgroundImagePathDict =
            new Dictionary<BackgroundType, string>()
        {
            { BackgroundType.Grass, "\\Images\\Backgrounds\\grass-background.jpg" },
            
        };
        #region Proparties
        public Bitmap BackgroundImage
        {
            get { return ExploreImage; }
        }
        #endregion

        #region Constructors
        public Background(BackgroundType backgroundType)
        {
            BuildBackground(Environment.CurrentDirectory + BackgroundImagePathDict[backgroundType]);
            BackgroundMusic.PlayIngameMusic();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Sets the image propartie
        /// </summary>
        private void BuildBackground(string fileLocation)
        {
            //BackgroundMusic.PlayIngameMusic();
            Image image = Image.FromFile(fileLocation);
            Height = image.Height;
            Width = image.Width;
            ExploreImage = new Bitmap(Height, Width);
            Graphics.FromImage(ExploreImage).DrawImage(image, new Point(0, 0));
        }
        #endregion
    }
}
