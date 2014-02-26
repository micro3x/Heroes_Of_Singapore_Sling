using System;
using System.Linq;
using GameAssets;

namespace GameLogic
{
    [Serializable]
    public sealed class Game
    {
        private static volatile Game instance;
        private static readonly object syncRoot = new object();

        private Game()
        {
        }

        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if(instance == null)
                            instance = new Game();
                    }
                }
                return instance;
            }
        }

        public Terrain[] Map { get; set; }
        public Hero PlayerHero { get; set; }
        public int CurrentTerrain { get; set; }



    }
}
