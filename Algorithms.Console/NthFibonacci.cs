using System.Collections.Generic;

namespace Algorithms.Application
{
    public class Fibonacci
    {
        //For Recursive call one call will genarate two subsequent calls ---> time complexity == O(2^n). 
        //Until one half of the recursion finished another half will not execute. so at a time max call frame in stack will be n ---> Space Complexity == O(n)  
        //Time Complexity: O(2^n)
        //Space Complexity: O(n)
        public static int GetNthFibonacciUsingRecursion(int n)
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
                return GetNthFibonacciUsingRecursion(n - 2) + GetNthFibonacciUsingRecursion(n - 1);
            }
        }

        //Simple while loop --> O(n) and search on Hash table --> O(1) | Nth record will genarate same number of <key, value> pair in the hash table.
        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static int GetNthFibonacciUsingHashTable(int n)
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
        public static int GetNthFibonacciUsingArray(int n)
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
}