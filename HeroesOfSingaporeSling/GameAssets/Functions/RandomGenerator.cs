using System;

namespace GameAssets
{
    public static class RandomGenerator
    {
        static Random rand = new Random();

        public static int GetRandom(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
