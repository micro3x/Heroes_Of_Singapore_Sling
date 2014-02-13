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
        private ImageProperties _firstObsticle;
        private ImageProperties _secondObsticle;

        public ImageProperties firstObsticle { get { return _firstObsticle; } }
        public ImageProperties secondObsticle { get { return _secondObsticle; } }

        public ObsticleHitEventArgs(ImageProperties first, ImageProperties second)
        {
            _firstObsticle = first;
            _secondObsticle = second;
        }
    }


}
