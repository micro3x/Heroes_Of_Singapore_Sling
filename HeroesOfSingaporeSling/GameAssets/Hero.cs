using System;
using System.Linq;
using GameCommon;

namespace GameAssets
{
    
    public class Hero : Creature, IMoveble
    {
        public event EventHandler<MoveEventArgs> Move;

        protected virtual void OnMove(MoveEventArgs e)
        {
            EventHandler<MoveEventArgs> handler = Move;
            if (handler != null) handler(this, e);
        }
        public void ChangePosition(int newPositionTop, int newPositionLeft)
        {
            OnMove(new MoveEventArgs(newPositionTop, newPositionLeft));
            PositionTop = newPositionTop;
            PositionLeft = newPositionLeft;
        }
    }
}
