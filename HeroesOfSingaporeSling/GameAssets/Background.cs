using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets
{
    /// <summary>
    /// Used to get the background for the MainScreen
    /// </summary>
    class Background
    {
        #region Vars
        /// <summary>
        /// Where is the image file
        /// </summary>
        private readonly string _fileLocation;
        /// <summary>
        /// What is the file name
        /// </summary>
        private readonly string _fileName;
        private int _height;
        private int _width;
        /// <summary>
        /// Holding the image to return
        /// </summary>
        private Bitmap _backgroundImage;
        #endregion

        #region Proparties
        public Bitmap BackgroundImage
        {
            get { return _backgroundImage; }
        }
        #endregion

        #region Constructors
        public Background()
        {
            // here we get the directory where the program is running from
            _fileLocation = Environment.CurrentDirectory;
            // here we set the location in the subdirectory
            _fileLocation += "\\Images\\Backgrounds";
            // setting the filename
            _fileName = BackgroungImageFileName();
            BuildBackground();
        }
        #endregion

        #region Methods
        /// <summary>
        /// this is a separate method because the background image may differ.
        /// for example: desert, grass, stone
        /// </summary>
        /// <returns>the filename of the image</returns>
        private string BackgroungImageFileName()
        {
            return "\\grass-background.jpg";
        }
        /// <summary>
        /// Sets the image propartie
        /// </summary>
        private void BuildBackground()
        {
            Image image = Image.FromFile(_fileLocation + _fileName);
            _height = image.Height;
            _width = image.Width;
            _backgroundImage = new Bitmap(_height, _width);
            Graphics.FromImage(_backgroundImage).DrawImage(image, new Point(0, 0));
        }
        #endregion
    }
}
