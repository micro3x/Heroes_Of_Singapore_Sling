using System;
using System.Drawing;
using System.Linq;

namespace GameAssets
{
    public interface IWearable
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
