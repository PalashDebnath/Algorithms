namespace Algorithms.Problems
{
    public static class SortedArraysMedian
    {
        //Time Complexity: O(n)
        //Space Complexity: O(n + m)
        public static double Find(int[] nums1, int[] nums2)
        {
            int left = 0, right = 0, counter = 0;
            int[] merge = new int[nums1.Length + nums2.Length];
            while(left < nums1.Length && right < nums2.Length)
            {
                if(nums1[left] > nums2[right])
                {
                    merge[counter] = nums2[right];
                    right = right + 1;
                }
                else
                {
                    merge[counter] = nums1[left];
                    left = left + 1;
                }
                counter = counter + 1;
            }
            while(left < nums1.Length)
            {
                merge[counter] = nums1[left];
                left = left + 1;
                counter = counter + 1;
            }
            while(right < nums2.Length)
            {
                merge[counter] = nums2[right];
                right = right + 1;
                counter = counter + 1;
            }
            return merge.Length % 2 == 0 ? (double)(merge[(merge.Length / 2) - 1] + merge[merge.Length / 2]) / 2 : merge[merge.Length / 2];
        }
    }
}