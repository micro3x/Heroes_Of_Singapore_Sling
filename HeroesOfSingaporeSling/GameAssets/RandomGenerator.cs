using System;

namespace GameAssets
{
    static class RandomGenerator
    {
        static Random rand = new Random();

        public static int GetRandom(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
