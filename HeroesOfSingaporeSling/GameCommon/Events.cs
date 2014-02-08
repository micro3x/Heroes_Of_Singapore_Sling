using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Here we will write all Events
// For example the event Fight, Hit, Obsticle hit ......

namespace GameCommon
{
    public delegate void LevelUpEventHandler(object Sender, LevelUpEventArgs e);

    public class LevelUpEventArgs : EventArgs
    {
        
    }

    class Events
    {
    }
}
