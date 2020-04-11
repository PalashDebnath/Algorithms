namespace Algorithms.Problems
{
    public static class Monotonic
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static bool Check(int[] array)
        {
            bool isDecresing = true, isIncreasing = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if(array[i] > array[i + 1])
                    isIncreasing = false;
                else if(array[i] < array[i + 1])
                    isDecresing = false;
                else
                    continue;
            }
            return isDecresing || isIncreasing;
        }
    }
}