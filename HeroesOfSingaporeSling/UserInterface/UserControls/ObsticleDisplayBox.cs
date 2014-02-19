using System.Windows.Forms;

namespace UserInterface.UserControls
{
    /// <summary>
    /// This is a Custom Control that adds the propartie ID to the 
    /// picture box so that we can use it to indentify the specific
    /// object behind the picture.
    /// </summary>
    public partial class ObsticleDisplayBox : PictureBox
    {
        private int _itemId;

        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        public override string ToString()
        {
            return this.Tag.ToString();
        }
    }
}
