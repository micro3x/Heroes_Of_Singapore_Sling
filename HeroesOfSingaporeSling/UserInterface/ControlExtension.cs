using System.Windows.Forms;

namespace UserInterface
{
    public static class ControlExtension
    {
        /// <summary>
        /// This extention method allows us to manualy set the z-order of any control on the screen
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="z"></param>
        public static void SetControlZIndex(this Control ctrl, int z)
        {
            ctrl.Parent.Controls.SetChildIndex(ctrl, z);
        }
    }
}
