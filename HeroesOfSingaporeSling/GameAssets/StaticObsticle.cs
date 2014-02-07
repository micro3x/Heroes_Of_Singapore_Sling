using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets
{
    public class StaticObsticle : Obsticle
    {
        StaticObsticleType staticObsticleType;
        private string _fileLocation;

        public StaticObsticleType StaticObsticleType
        {
            get { return staticObsticleType; }
            set { staticObsticleType = value; }
        }

        public StaticObsticle(StaticObsticleType typeOfObsticle, int posTop, int posLeft)
        {
            switch (typeOfObsticle)
            {
                case StaticObsticleType.Tree:
                    _fileLocation = Environment.CurrentDirectory;
                    _fileLocation += "\\Images\\Tree";
                    _fileLocation += BackgroungImageFileName(typeOfObsticle);
                    BuildBackground();
                    staticObsticleType = typeOfObsticle;
                    positionTop = posTop;
                    positionLeft = posLeft;
                    break;
                case StaticObsticleType.Rock:
                    _fileLocation = Environment.CurrentDirectory;
                    _fileLocation += "\\Images\\Stone";
                    _fileLocation += BackgroungImageFileName(typeOfObsticle);
                    BuildBackground();
                    staticObsticleType = typeOfObsticle;
                    positionTop = posTop;
                    positionLeft = posLeft;
                    break;
                case StaticObsticleType.Fence:
                    _fileLocation = Environment.CurrentDirectory;
                    _fileLocation += "\\Images\\Fence";
                    _fileLocation += BackgroungImageFileName(typeOfObsticle);
                    BuildBackground();
                    staticObsticleType = typeOfObsticle;
                    positionTop = posTop;
                    positionLeft = posLeft;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("typeOfObsticle");
            }
            ObsticleType = ObsticleType.Static;
        }

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
            return "\\small40x50.png";
        }
        private void BuildBackground()
        {
            Bitmap image = new Bitmap(_fileLocation);
            Height = image.Height;
            Width = image.Width;
            ImageBitmap = image;
        }
    }

    public enum StaticObsticleType
    {
        Tree, Rock, Fence
    }
}
