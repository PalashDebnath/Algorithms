using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class LargestRange
    {
        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static int[] Find(int[] array)
        {
            Dictionary<int, bool> memorize = new Dictionary<int, bool>();
            int rangeLength = 0, start = 0, end = 0;
            foreach(int num in array)
            {
                if(!memorize.ContainsKey(num))
                {
                    memorize.Add(num, false);
                }
            }

            foreach(int num in array)
            {
                int left = num - 1, right = num + 1, length = 0;
                while(!memorize[num])
                {
                    if(memorize.ContainsKey(left))
                    {
                        memorize[left] = true;
                        left =  left - 1;
                        length = length + 1;
                    }
                    else if(memorize.ContainsKey(right))
                    {
                        memorize[right] = true;
                        right = right + 1;
                        length = length + 1;
                    }
                    else
                    {
                        memorize[num] = true;
                        length = length + 1;
                    }
                }

                if(rangeLength < length)
                {
                    rangeLength = length;
                    start = left + 1;
                    end = right - 1;
                }
            }
            return new int[] {start, end};
        } 
    }
}