using System;
using System.Drawing;
using System.Linq;

namespace GameAssets
{
    // Anyone who wants to move will have to follow this rules!
    public interface IMovable
    {
        event EventHandler<MoveEventArgs> Move;

        Bitmap ExploreImage { get; set; }
        int PositionTop { get; set; }
        int PositionLeft { get; set; }
        void ChangePosition(int newPositionTop, int newPositionLeft);
        
    }
}
