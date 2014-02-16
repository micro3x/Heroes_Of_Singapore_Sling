using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GameCommon;

namespace GameAssets
{
    // Anyone who wants to move will have to follow this rules!
    public interface IMoveble
    {
        event EventHandler<MoveEventArgs> Move;

        Bitmap ExploreImage { get; set; }
        int PositionTop { get; set; }
        int PositionLeft { get; set; }
        void ChangePosition(int newPositionTop, int newPositionLeft);
        
    }
}
