using System;
using System.Drawing;
using GameCommon;

namespace GameAssets
{
    public class StaticObsticle : Obsticle
    {
        #region Vars
        private string _fileLocation;
        #endregion

        #region Proparties
        public StaticObsticleType StaticObsticleType { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Each instance is an object on the terrain
        /// </summary>
        /// <param name="typeOfObsticle">this is the type of static obsticle (Tree, Stone, Fence ....)</param>
        /// <param name="posTop">Position of the object on the terrain </param>
        /// <param name="posLeft">Position of the object on the terrain </param>
        public StaticObsticle(StaticObsticleType typeOfObsticle, int posTop, int posLeft)
        {
            // here we set the proparties depending on the type of static obsticle
            switch (typeOfObsticle)
            {
                case StaticObsticleType.Tree:
                    _fileLocation = Environment.CurrentDirectory;
                    _fileLocation += "\\Images\\Tree";
                    _fileLocation += BackgroungImageFileName(typeOfObsticle);
                    BuildBackground();
                    StaticObsticleType = typeOfObsticle;
                    positionTop = posTop;
                    positionLeft = posLeft;
                    break;
                case StaticObsticleType.Rock:
                    _fileLocation = Environment.CurrentDirectory;
                    _fileLocation += "\\Images\\Stone";
                    _fileLocation += BackgroungImageFileName(typeOfObsticle);
                    BuildBackground();
                    StaticObsticleType = typeOfObsticle;
                    positionTop = posTop;
                    positionLeft = posLeft;
                    break;
                case StaticObsticleType.Fence:
                    _fileLocation = Environment.CurrentDirectory;
                    _fileLocation += "\\Images\\Fence";
                    _fileLocation += BackgroungImageFileName(typeOfObsticle);
                    BuildBackground();
                    StaticObsticleType = typeOfObsticle;
                    positionTop = posTop;
                    positionLeft = posLeft;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("typeOfObsticle");
            }
            ObsticleType = ObsticleType.Static;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Here we set the image filename depending on the type of obsticle
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string BackgroungImageFileName(StaticObsticleType type)
        {
            switch (type)
            {
                case StaticObsticleType.Tree:
                    return "\\small80x100.png";
                case StaticObsticleType.Rock:
                    return "\\small70x70.png";
                case StaticObsticleType.Fence:
                    return "\\small60x60.png";
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
        /// <summary>
        /// Here we set the actual image propartie
        /// </summary>
        private void BuildBackground()
        {
            Bitmap image = new Bitmap(_fileLocation);
            Height = image.Height;
            Width = image.Width;
            ImageBitmap = image;
        }
        #endregion
    }

}
