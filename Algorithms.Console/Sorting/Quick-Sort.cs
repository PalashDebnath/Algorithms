namespace Algorithms.Problems
{
    //Time Complexity: Worst Case O(n^2) | Average Case O(nlog(n)) | Best Case O(nlog(n))
    //Space Complexity: Worst Case O(log(n)) | Average Case O(log(n)) | Best Case O(log(n))
    public static class Quick
    {
        public static int[] Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
            return array;
        }

        private static void Sort(int[] array, int sIndex, int eIndex)
        {
            if (sIndex >= eIndex)
            {
                return;
            }

            int pivot = array[sIndex], left = sIndex + 1, right = eIndex;

            while (left <= right)
            {
                if(array[left] >= pivot && array[right] < pivot)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left += 1;
                    right -= 1;
                }
                else
                {
                    if(array[left] < pivot)
                        left += 1;
                    if(array[right] >= pivot)
                        right -= 1;
                }
            }
            array[sIndex] = array[right];
            array[right] = pivot;

            //As per the Quick Sort nomenclature you should sort the smaller sub array first.
            //Here we havn't consider that.
            Sort(array, sIndex, right - 1);
            Sort(array, right + 1, eIndex);
        }
    }
}