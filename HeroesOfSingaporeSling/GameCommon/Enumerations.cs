using System;// Here we will Write all enumerations :)

namespace GameCommon
{
    public enum ObsticleType
    {
        Static,
        Createre,
        Item
    }

    public enum StaticObsticleType
    {
        Tree, Rock, Fence, BorderVertical, BorderHorizontal
    }

    public enum BackgroundType
    {
        Grass, Water, SomethingElse
    }

    public enum HeroType
    {
        Warrior, Mage, Rogue, Paladin, SomethingElse
    }
}