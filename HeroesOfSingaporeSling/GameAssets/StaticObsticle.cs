using System;
using System.Drawing;
using GameCommon;

namespace GameAssets
{

    public class StaticObsticle : ImageProperties
    {
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
            
            BuildBackground(Environment.CurrentDirectory + ImagePaths.StaticObsticleImagePathDict[staticObsticleType]);
        }
        
        #endregion
        
        #region Methods
      
        private void BuildBackground(string fileLocation)
        {
            Bitmap image = new Bitmap(fileLocation);
            Height = image.Height;
            Width = image.Width;
            ImageBitmap = image;
        }

        #endregion
    }
}