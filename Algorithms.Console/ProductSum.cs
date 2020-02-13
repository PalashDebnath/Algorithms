using System.Collections.Generic;

namespace Algorithms.Application
{
    public class ProductSum
    {
        //Here you bacially loop through all the elements in main list along with the sub-lists
        //for example [1,2,[3,4],[5,[6,7]],10] -- total iteration is 10 where if you only consider the main list, it has 5 element
        //Time Complexity: O(n)
        //Space Complexity: O(n) we have recursive calls.So number of call frames will be equal to the highest depth of the list   
        public static int Sum(List<object> array)
        {
            return Sum(1, array);
        }

        private static int Sum(int level, List<object> array)
        {
            int totalSum = 0;
            foreach(object currect in array)
            {
                if(currect is int)
                {
                    totalSum = totalSum + (int)currect;
                }
                else
                {
                    totalSum = totalSum + Sum(level + 1, (List<object>)currect);
                }
            }
            return totalSum * level;
        }
    }
}