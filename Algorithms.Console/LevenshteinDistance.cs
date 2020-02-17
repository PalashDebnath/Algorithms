using System;

namespace Algorithms.Application
{
    public class LevenshteinDistance
    {
        //Time Complexity: O(mn) where m and n is the length of given strings
        //Space Complexity: O(mn) where m and n is the lenght of given strings.
        public static int NumberOfOperation(string str1, string str2)
        {
            int[,] operations = new int[str2.Length + 1, str1.Length + 1];
            for(int i = 0; i < str2.Length + 1; i++)
            {
                for(int j = 0; j < str1.Length + 1; j++)
                {
                    operations[i,j] = j;
                }
                operations[i,0] = i;
            }

            for(int i = 1; i < str2.Length + 1; i++)
            {
                for(int j = 1; j < str1.Length + 1; j++)
                {
                    //you should decrease the counter as the array length is always 1 position bigger then the string input
                    if(str1[j - 1] == str2[i - 1])
                    {
                        operations[i,j] = operations[i-1,j-1];
                    }
                    else
                    {
                        operations[i,j] = 1 + Math.Min(Math.Min(operations[i,j-1], operations[i-1,j-1]), operations[i-1,j]);
                    }
                }
            }
            return operations[str2.Length, str1.Length];
        }
    }
}