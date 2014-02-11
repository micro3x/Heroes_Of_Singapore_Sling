using System;
using System.Collections.Generic;
using System.Drawing;
using GameCommon;


namespace GameAssets
{

    public class StaticObsticle : Obsticle
    {
        #region Vars
        private readonly string fileLocation;
        #endregion
        
        #region Constructors
        /// <summary>
        /// Each instance is an object on the terrain
        /// </summary>
        /// <param name="typeOfObsticle">this is the type of static obsticle (Tree, Stone, Fence ....)</param>
        /// <param name="posTop">Position of the object on the terrain </param>
        /// <param name="posLeft">Position of the object on the terrain </param>
        public StaticObsticle(StaticObsticleType staticObsticleType, int posTop, int posLeft)
        {
            positionTop = posTop;
            positionLeft = posLeft;
            fileLocation = Environment.CurrentDirectory;
            fileLocation += ImagePaths.StaticObsticleImagePathDict[staticObsticleType];
            BuildBackground();
         }
        
        #endregion
        
        #region Methods
        /// <summary>
        /// Here we set the actual image propartie
        /// </summary>
        private void BuildBackground()
        {
            Bitmap image = new Bitmap(fileLocation);
            Height = image.Height;
            Width = image.Width;
            ImageBitmap = image;
        }

        #endregion
    }
}