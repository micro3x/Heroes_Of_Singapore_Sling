using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets
{
    interface IWearable
    {
        bool CanWear(Hero hero);
        Bitmap WearImage { get; }

        int BonusToDamage { get; }

        int BonusToDefence { get; }

        int BonusToStrenght { get; }

        int BonusToAgility { get; }

        int BonusToVitality { get; }

        int BonusToWisdom { get; }

        OnCharacterLocation WearLocation { get; }

        int RequireStrenght { get; }
        int RequireAgility { get; }
        int RequireVitality { get; }
        int RequireWisdom { get; }

    }
}
