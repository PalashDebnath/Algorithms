namespace Algorithms.Application
{
    public class Kadan
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int FindMaximumSumOfSubArray(int[] array)
        {
            int currectSum = array[0];
            int totalSum = array[0];
            for(int i = 1; i < array.Length; i++)
            {
                currectSum = currectSum + array[i] >= array[i] ? currectSum + array[i] : array[i];
                totalSum = totalSum >= currectSum ? totalSum : currectSum;
            }
            return totalSum;
        }

        //Time Complexity: O(n)
        //Space Complexity: O(m).
        public static int[] FindSubArrayOfMaximumSum(int[] array)
        {
            int currectSum = array[0], totalSum = array[0], startIndex = 0, endIndex = 0;
            int[] subArray;
            for(int i = 1; i < array.Length; i++)
            {
                if(currectSum + array[i] >= array[i])
                {
                    currectSum = currectSum + array[i];
                }
                else
                {
                    currectSum = array[i];
                    startIndex = i;
                }

                if(totalSum < currectSum)
                {
                    totalSum = currectSum;
                    endIndex = i;
                }
            }

            subArray = new int[(endIndex - startIndex) + 1];

            for(int i = 0; i < subArray.Length; i++)
            {
                subArray[i] = array[startIndex];
                startIndex = startIndex + 1;
            }

            return subArray;
        }
    }
}