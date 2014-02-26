using System;
// Here we will write all Events
// For example the event Fight, Hit, Obsticle hit ......
using System.Security.Permissions;

namespace GameAssets
{

    public class LevelUpEventArgs : EventArgs
    {
        public LevelUpEventArgs(int newLvl, int nextLvlAt)
        {
            LevelReached = newLvl;
            NextLevelAt = nextLvlAt;
        }


        public int LevelReached { get; set; }
        public int NextLevelAt { get; set; }
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

    public class BattleEventArgs : EventArgs
    {
        private Creature hero;
        private Creature enemy;

        public Creature Hero { get { return hero; } }
        public Creature Enemy { get { return enemy; } }

        public BattleEventArgs(Creature hero, Creature enemy)
        {
            this.hero = hero;
            this.enemy = enemy;
        }
    }

public class ChangeScreenEventArgs : EventArgs
    {
        private int next;

        public int NextScreen { get { return next; } }

        public ChangeScreenEventArgs(int nextScreen)
        {
            next = nextScreen;
        }
    }

}
