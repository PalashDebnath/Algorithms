using System.Collections.Generic;

namespace Algorithms.Application
{
    public class Fibonacci
    {
        //For Recursive call one call will genarate two subsequent calls ---> time complexity == O(2^n). 
        //Until one half of the recursion finished another half will not execute. so at a time max call frame in stack will be n ---> Space Complexity == O(n)  
        //Time Complexity: O(2^n)
        //Space Complexity: O(n)
        public static int GetNthUsingRecursion(int n)
        {
            if(n == 1)
            {
                return 0;
            }
            else if(n == 2)
            {
                return 1;
            }
            else
            {
                return GetNthUsingRecursion(n - 2) + GetNthUsingRecursion(n - 1);
            }
        }

        //Simple while loop --> O(n) and search on Hash table --> O(1) | Nth record will genarate same number of <key, value> pair in the hash table.
        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static int GetNthUsingHashTable(int n)
        {
            Dictionary<int, int> memorize = new Dictionary<int, int>();
            memorize.Add(1, 0);
            memorize.Add(2, 1);
            int counter = 3;
            while(counter <= n)
            {
                memorize.Add(counter, memorize[counter - 2] + memorize[counter - 1]);
                counter++;
            }
            return memorize[n];
        }

        //Simple while loop --> O(n) and no additional space.
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int GetNthUsingArray(int n)
        {
            int[] memorize = new int[] {0, 1};
            int counter = 3;
            while(counter <= n)
            {
                int nextFib = memorize[0] + memorize[1];
                memorize[0] = memorize[1];
                memorize[1] = nextFib;
                counter++;
            }
            return n == 1 ? memorize[0] : memorize[1]; 
        }
    }

    public class Product
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