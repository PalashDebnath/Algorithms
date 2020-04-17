namespace Algorithms.Problems
{
    public static class ShiftedBinarySearch
    {
        //Time Complexity: O(log(n))
        //Space Complexity: O(1)
        public static int ElementIteratively(int[] array, int target)
        {
            int left = 0, right = array.Length - 1, middle = 0;

            while(left <= right)
            {
                middle = (left + right) / 2;
                if(array[middle] == target)
                {
                    return middle;
                }
                else if(array[left] <= array[middle])
                {
                    if(target < array[middle] && target >= array[left])
                        right = middle - 1;
                    else
                        left = middle + 1;
                }
                else
                {
                    if(target > array[middle] && target <= array[right])
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
            }
            return -1;
        }

        //Time Complexity: O(log(n))
        //Space Complexity: O(log(n))
        public static int ElementRecursivly(int[] array, int target)
        {
            int index = ElementRecursivly(array, 0, array.Length - 1, target);
            return index;
        }

        private static int ElementRecursivly(int[] array, int left, int right, int target)
        {
            if(left > right)
                return -1;

            int middle = (left + right) / 2;
            if(array[middle] == target)
            {
                return middle;
            }
            else if(array[left] <= array[middle])
            {
                if(target < array[middle] && target >= array[left])
                    return ElementRecursivly(array, left, middle - 1, target);
                else
                    return ElementRecursivly(array, middle + 1, right, target);
            }
            else
            {
                if(target > array[middle] && target <= array[right])
                    return ElementRecursivly(array, middle + 1, right, target);
                else
                    return ElementRecursivly(array, left, middle - 1, target);
            }
        }
    }
}