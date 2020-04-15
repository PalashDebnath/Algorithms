using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Problems
{
    public static class Palindrome
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static bool CheckIteratively(string value)
        {
            int left = 0;
            int right = value.Length - 1;
            bool isPalindrome = true;
            while(left < right)
            {
                if(value[left] == value[right])
                {
                    left = left + 1;
                    right = right - 1;
                }
                else
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome;
        }

        //Time Complexity: O(n)
        //Space Complexity: O(n) -- for each recursive call there will be a frame in call stack
        public static bool CheckRecursively(string value)
        {
            int left = 0;
            int right = value.Length - 1;
            return left == right ? true : value[left] == value[right] && CheckRecursively(value.Substring(1, right - 1));
        }

        //You have to loop through the entire string which is O(n) and each time you will end up creating new string, which is another O(n)
        //Time Complexity: O(n*n) == O(n^2)
        //Space Complexity: O(n) --- Because you create a new reverse string of the same size of given array.
        public static bool CheckUsingStringConcatenate(string value)
        {
            string reverseString = "";

            for(int i = value.Length - 1; i >= 0 ; i--)
            {
                //Everytime when add an element to the string it will delete the old string and create a new string with all the character
                //which is basically a time complexity of O(n)
                reverseString += value[i];
            }

            return reverseString.Equals(value);
        }

        //You have to loop through the entire string which is O(n) and and append it to the existing string
        //Time Complexity: O(n)
        //Space Complexity: O(n) --- Because you create a new reverse string of the same size of given array.
        public static bool CheckUsingStringBuilder(string value)
        {
            StringBuilder reverseString = new StringBuilder();

            for(int i = value.Length - 1; i >= 0 ; i--)
            {
                reverseString.Append(value[i]);
            }

            return reverseString.Equals(value);
        }        

        //Time Complexity: O(n^2)
        //Space Complexity: O(n)
        public static string LongestSubstring(string s) {
            int start = 0, end = 0;
            for(int i = 0; i < s.Length; i++)
            {
                int left = i - 1, right = i + 1;
                while(left >= 0 && right < s.Length)
                {
                    if(s[left] != s[right])
                    {
                        break;
                    }
                    left = left - 1;
                    right = right + 1;
                }

                left = left + 1;

                if((end - start) < (right - left))
                {
                    start = left;
                    end = right;
                }

                left = i - 1;
                right = i;
                while(left >= 0 && right < s.Length)
                {
                    if(s[left] != s[right])
                    {
                        break;
                    }
                    left = left - 1;
                    right = right + 1;
                }

                left = left + 1;
                if((end - start) < (right - left))
                {
                    start = left;
                    end = right;
                }
            }
            return s.Substring(start, end - start);
        }
    }
}