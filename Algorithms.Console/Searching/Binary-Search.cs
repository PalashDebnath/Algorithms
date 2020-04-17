namespace Algorithms.Problems
{
    public static partial class BinarySearch
    {
        //Time Complexity: O(log(n))
        //Space Complexity: O(1) 
        public static int ElementIteratively(int[] sourceArray, int targetValue)
        {
            int left, right, middle;
            left = 0;
            right = sourceArray.Length - 1;
            while(left <= right)
            {
                middle = (left + right) / 2;
                if(targetValue == sourceArray[middle])
                {
                    return middle;
                }
                else if(targetValue > sourceArray[middle])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return -1;
        }

        //Time Complexity: O(log(n))
        //Space Complexity: O(log(n)) 
        public static int ElementRecursively(int[] sourceArray, int targetValue)
        {
            return ElementRecursively(sourceArray, targetValue, 0, sourceArray.Length - 1);
        }

        private static int ElementRecursively(int[] sourceArray, int targetValue, int left, int right)
        {
            int middle;
            middle = (left + right) / 2;
            if(left > right)
            {
                return -1;
            }
            if(targetValue == sourceArray[middle])
            {
                return middle;
            }
            else if(targetValue > sourceArray[middle])
            {
                return ElementRecursively(sourceArray, targetValue, middle + 1, right);
            }
            else
            {
                return ElementRecursively(sourceArray, targetValue, left, middle - 1);
            }
        }
    }
}