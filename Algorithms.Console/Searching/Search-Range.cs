namespace Algorithms.Problems
{
    public static partial class BinarySearch
    {
        //Time Complexity: O(log(n))
        //Space Complexity: O(1)
        public static int[] RangeIteratively(int[] array, int target)
        {
            int[] indices = new int[2] {-1, -1};
            RangeIteratively(array, target, indices, true);
            RangeIteratively(array, target, indices, false);
            return indices;
        }

        private static void RangeIteratively(int[] array, int target, int[] indices, bool exploreLeft)
        {
            int left = 0, right = array.Length - 1, middle = 0;
            while(left <= right)
            {
                middle = (left + right) / 2;
                if(array[middle] == target)
                {
                    if(exploreLeft)
                    {
                        if(middle == 0 || array[middle - 1] != target)
                        {
                            indices[0] = middle;
                            return;
                        }
                        else
                        {
                            right = middle - 1;
                        }
                    }
                    else
                    {
                        if(middle == array.Length - 1 || array[middle + 1] != target)
                        {
                            indices[1] = middle;
                            return;
                        }
                        else
                        {
                            left = middle + 1;
                        }
                    }
                }
                else if(array[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int[] RangeIteratively_Optional(int[] array, int target)
        {
            int left = 0, right = array.Length - 1, middle = 0;

            while(left <= right)
            {
                    middle = (left + right) / 2;
                    if(array[middle] == target)
                    {
                        left = middle - 1;
                        right = middle + 1;
                        while (right < array.Length && array[right] == target)
                        {
                            right = right + 1;
                        }
                        while (left >= 0 && array[left] == target)
                        {
                            left = left - 1;
                        }
                        return new int[] { left + 1, right - 1};
                    }
                    else if(array[middle] > target)
                    {
                            right = middle - 1;
                    }
                    else
                    {
                            left = middle + 1;
                    }
            }
            return new int[] {-1, -1};
        }

        //Time Complexity: O(log(n))
        //Space Complexity: O(log(n))
        public static int[] RangeRecursively(int[] array, int target)
        {
            int[] indices = new int[] {-1, -1};
            RangeRecursively(array, target, indices, 0, array.Length - 1, true);
            RangeRecursively(array, target, indices, 0, array.Length - 1, false);
            return indices;
        }

        private static void RangeRecursively(int[] array, int target, int[] indices, int left, int right, bool exploreLeft)
        {
            if(left > right)
                return;
            
            int middle = (left + right) / 2;
            if(array[middle] == target)
            {
                if(exploreLeft)
                {
                    if(middle == 0 || array[middle - 1] != target)
                    {
                        indices[0] = middle;
                        return;
                    }
                    else
                    {
                        RangeRecursively(array, target, indices, left, middle - 1, exploreLeft);
                    }
                }
                else
                {
                    if(middle == array.Length - 1 || array[middle + 1] != target)
                    {
                        indices[1] = middle;
                        return;
                    }
                    else
                    {
                        RangeRecursively(array, target, indices, middle + 1, right, exploreLeft);
                    }
                }
            }
            else if(array[middle] > target)
            {
                RangeRecursively(array, target, indices, left, middle - 1, exploreLeft);
            }
            else
            {
                RangeRecursively(array, target, indices, middle + 1, right, exploreLeft);
            }
        }
    }
}