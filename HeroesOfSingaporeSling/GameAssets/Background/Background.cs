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
    public class Background : IDrawable
    {
        // tova ne ni trqbva kato obsticle a IDrawable!
        private Bitmap bkground;


        public static Dictionary<BackgroundType, string> BackgroundImagePathDict =
            new Dictionary<BackgroundType, string>()
        {
            { BackgroundType.Grass, "\\Images\\Backgrounds\\grass-background.jpg" },
        };
        #region Proparties
        public Bitmap ExploreImage
        {
            get { return bkground; }
            set { bkground = value; }
        }
        #endregion

        #region Constructors
        public Background(BackgroundType backgroundType)
        {
            ExploreImage = new Bitmap(Environment.CurrentDirectory + BackgroundImagePathDict[backgroundType]);
            BackgroundMusic.PlayIngameMusic();
        }
        #endregion

    }
}
