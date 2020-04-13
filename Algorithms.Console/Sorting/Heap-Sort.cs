using System;

namespace Algorithms.Problems
{
    public static class Heap
    {
        public enum OrderBy
        {
            ASC,
            DESC
        }
        public static int[] Sort(int[] array, OrderBy orderBy = OrderBy.DESC)
        {
            Func<int, int, bool> compare;
            if(orderBy == OrderBy.ASC)
            {
                compare = (a, b) => a > b;
            }
            else
            {
                compare = (a, b) => a < b;
            }

            HeapBuilder(array, compare);
            for (int endIndex = array.Length - 1; endIndex > 0; endIndex--)
            {
                Swap(0, endIndex, array);
                SiftDown(0, endIndex - 1, array, compare);
            }
            return array;
        }

        private static void HeapBuilder(int[] array, Func<int, int, bool> compare)
        {
            int firstParentIndex = (array.Length - 2) / 2;
            int endIndex = array.Length - 1;
            for (int currentIndex = firstParentIndex; currentIndex >= 0; currentIndex--)
            {
                SiftDown(currentIndex, endIndex, array, compare);
            }
        }

        private static void SiftDown(int currentIndex, int endIndex, int[] array, Func<int, int, bool> compare)
        {
            int firstChildIndex = currentIndex * 2 + 1;
            while(firstChildIndex <= endIndex)
            {
                int secondChildIndex = currentIndex * 2 + 2 <= endIndex ? currentIndex * 2 + 2 : -1;
                int targetIndex;

                if(secondChildIndex != -1 && compare(array[secondChildIndex], array[firstChildIndex]))
                {
                    targetIndex = secondChildIndex;
                }
                else
                {
                    targetIndex = firstChildIndex;
                }

                if(compare(array[targetIndex], array[currentIndex]))
                {
                    Swap(currentIndex, targetIndex, array);
                    currentIndex = targetIndex;
                    firstChildIndex = currentIndex * 2 + 1;
                }
                else
                {
                    break;
                }
            }
        }

        private static void Swap(int sourceIndex, int targetIndex, int[] array)
        {
            int temp = array[sourceIndex];
            array[sourceIndex] = array[targetIndex];
            array[targetIndex] = temp;
        }
    }
}