using System;
using System.Linq;
using GameAssets;
using GameCommon;

namespace GameLogic
{
    public class Battle
    {
        public static event EventHandler<BattleEventArgs> BattleStart;

        public static void OnBattleStart(BattleEventArgs e)
        {
            EventHandler<BattleEventArgs> handler = BattleStart;
            if (handler != null) handler(null, e);
        }
    }
}
