using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets
{
    class Background
    {
        private string _fileLocation;
        private readonly string _fileName;
        private int height;
        private int width;
        private Bitmap backgroundImage;
        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }

        public Bitmap BackgroundImage
        {
            get { return backgroundImage; }
        }

        public string FileLocation
        {
            get
            {
                return _fileLocation + _fileName;
            }
            private set { _fileLocation = value;}
        }
        public Background()
        {
            _fileLocation = Environment.CurrentDirectory;
            _fileLocation += "\\Images\\Backgrounds";
            _fileName = BackgroungImageFileName();
            BuildBackground();
        }

        private string BackgroungImageFileName()
        {
            return "\\grass-background.jpg";
        }
        private void BuildBackground()
        {
            Image image = Image.FromFile(FileLocation);
            height = image.Height;
            width = image.Width;
            backgroundImage = new Bitmap(height, width);
            Graphics.FromImage(backgroundImage).DrawImage(image, new Point(0, 0));
        }
    }
}
