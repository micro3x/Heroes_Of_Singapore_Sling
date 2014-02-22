using System;
using System.Drawing;
using GameCommon;
using System.Collections.Generic;

public enum StaticObsticleType
{
    Tree, Rock, Fence, BorderVertical, BorderHorizontal
}

namespace GameAssets
{
    [Serializable]
    public class StaticObsticle : Obsticle
    {
        public static Dictionary<StaticObsticleType, string> StaticObsticleImagePathDict =
            new Dictionary<StaticObsticleType, string>()
        {
            { StaticObsticleType.Tree, Environment.CurrentDirectory +  "\\Images\\StaticObsticle\\Tree\\small80x100.png" },
            { StaticObsticleType.Rock, Environment.CurrentDirectory +  "\\Images\\StaticObsticle\\Stone\\small70x70.png" },
            { StaticObsticleType.Fence, Environment.CurrentDirectory +  "\\Images\\StaticObsticle\\Fence\\small60x60.png" },
            { StaticObsticleType.BorderVertical, Environment.CurrentDirectory +  "\\Images\\StaticObsticle\\Borders\\BorderVertical.png" },
            { StaticObsticleType.BorderHorizontal, Environment.CurrentDirectory +  "\\Images\\StaticObsticle\\Borders\\BorderHorizontal.png" }
        };

        private StaticObsticleType thisStaticObsticleType;
        #region Constructors
        /// <summary>
        /// Each instance is an object on the terrain
        /// </summary>
        /// <param name="typeOfObsticle">this is the type of static obsticle (Tree, Stone, Fence ....)</param>
        /// <param name="posTop">Position of the object on the terrain </param>
        /// <param name="posLeft">Position of the object on the terrain </param>
        /// <param *new: By connecting
        ///   Enviroment directory string and path to file from ImagePaths static class,
        ///   which we get from dicionary with enum keys we get as a
        ///   result tring that keeps information about the full path to some image.
        ///   Then we give file direktory as argument to BuildBackground.
        ///   </param>
        public StaticObsticle(StaticObsticleType staticObsticleType, int posTop, int posLeft)
        {
            PositionTop = posTop;
            PositionLeft = posLeft;
            thisStaticObsticleType = staticObsticleType;
            BuildBackground(StaticObsticleImagePathDict[staticObsticleType]);
        }
        
        #endregion
        
        #region Methods
      
        private void BuildBackground(string fileLocation)
        {
            Bitmap image = new Bitmap(fileLocation);
            Height = image.Height;
            Width = image.Width;
            ExploreImage = image;
        }

        #endregion

        public override string ToString()
        {
            return this.thisStaticObsticleType.ToString();
        }
    }
}