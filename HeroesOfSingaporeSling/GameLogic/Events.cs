using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAssets;


namespace GameLogic
{
    public delegate void LevelUpEventHandler(object Sender, LevelUpEventArgs e);

    public class LevelUpEventArgs : EventArgs
    {
        
    }

    class Events
    {
    }
}
