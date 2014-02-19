using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAssets;

namespace GameLogic
{
    [Serializable]
    public sealed class Game
    {
        private static volatile Game instance;
        private static object syncRoot = new object();

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
