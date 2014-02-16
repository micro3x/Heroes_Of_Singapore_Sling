using System;

// Here we will write all Events
// For example the event Fight, Hit, Obsticle hit ......

namespace GameAssets
{

    public class LevelUpEventArgs : EventArgs
    {
        
    }
    
    public class MoveEventArgs : EventArgs
    {
        public int posTop { set; get; }
        public int posLeft { set; get; }

        public MoveEventArgs(int top, int left)
        {
            posTop = top;
            posLeft = left;
        }
    }

    public class ObsticleHitEventArgs : EventArgs
    {
        private Obsticle _firstObsticle;
        private Obsticle _secondObsticle;

        public Obsticle firstObsticle { get { return _firstObsticle; } }
        public Obsticle secondObsticle { get { return _secondObsticle; } }

        public ObsticleHitEventArgs(Obsticle first, Obsticle second)
        {
            _firstObsticle = first;
            _secondObsticle = second;
        }
    }


}
