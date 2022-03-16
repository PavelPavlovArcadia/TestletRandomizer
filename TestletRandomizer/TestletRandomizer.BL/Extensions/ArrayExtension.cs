using System;

namespace TestletRandomizer.BL.Extensions
{
    public static class ArrayExtensions
    {
        public static void Shuffle<T>(this T[] array, Random random)
        {
            var length = array.Length;

            while (length > 1)
            {
                var randomizedIndex = random.Next(length--);

                (array[length], array[randomizedIndex]) = (array[randomizedIndex], array[length]);
            }
        }
    }
}