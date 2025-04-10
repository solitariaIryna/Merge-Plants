using System.Collections.Generic;
using System;

namespace MergePlants.Helpers.Extentions
{
    public static class RandomExtentions
    {
        public static List<T> Randomize<T>(this List<T> list, int count)
        {
            if (list.Count < 0 || list.Count < count)
                throw new ArgumentException("List is Empty or List has fewer items than need to randomise");

            List<T> randomList = new();

            do
            {
                int randomNumber = UnityEngine.Random.Range(0, list.Count);
                T randomValue = list[randomNumber];

                if (randomList.Contains(randomValue))
                    continue;

                randomList.Add(randomValue);
            }
            while (randomList.Count < count);

            return randomList;
        }
        public static List<T> Randomize<T>(this T[] array, int count)
        {
            if (array.Length < 0 || array.Length < count)
                throw new ArgumentException("List is Empty or List has fewer items than need to randomise");

            List<T> randomList = new();

            do
            {
                int randomNumber = UnityEngine.Random.Range(0, array.Length);
                T randomValue = array[randomNumber];

                if (randomList.Contains(randomValue))
                    continue;

                randomList.Add(randomValue);
            }
            while (randomList.Count < count);

            return randomList;
        }
        public static T Randomize<T>(this List<T> list)
        {
            if (list.Count < 0)
                throw new ArgumentException("List is Empty or List has fewer items than need to randomise");

            int randomNumber = UnityEngine.Random.Range(0, list.Count);
            T randomValue = list[randomNumber];

            return randomValue;
        }
    }
}
