using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Application
{
    public static class String
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static bool CheckPalindroneUsingTraversal(string value)
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
        public static bool CheckPalindromeUsingRecursion(string value)
        {
            int left = 0;
            int right = value.Length - 1;
            return left == right ? true : value[left] == value[right] && CheckPalindromeUsingRecursion(value.Substring(1, right - 1));
        }

        //You have to loop through the entire string which is O(n) and each time you will end up creating new string, which is another O(n)
        //Time Complexity: O(n*n) == O(n^2)
        //Space Complexity: O(n) --- Because you create a new reverse string of the same size of given array.
        public static bool CheckPalindroneUsingNewString(string value)
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
        public static bool CheckPalindroneUsingStringBuilder(string value)
        {
            StringBuilder reverseString = new StringBuilder();

            for(int i = value.Length - 1; i >= 0 ; i--)
            {
                reverseString.Append(value[i]);
            }

            return reverseString.Equals(value);
        }
    
        //Time Complexity: O(n)
        //Space Complexity: O(Min(n,a)) a repensent number of unique character in the hash table 
        public static int LengthOfLongestSubstring(string s) {
            Dictionary<char, int> memorize = new Dictionary<char, int>();
            int start = 0, maxLength = 0;
            for(int i = 0; i < s.Length; i++) {
                if(memorize.ContainsKey(s[i])) {
                    start = Math.Max(start, memorize[s[i]] + 1);
                    memorize[s[i]] = i;
                }
                else {
                    memorize.Add(s[i], i);
                }
                maxLength = Math.Max(maxLength, i - start + 1);
            }
            return maxLength;
        }

        //Time Complexity: O(n^2)
        //Space Complexity: O(n)
        public static string LongestPalindromicSubstring(string s) {
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

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static string Encryptor(string value, int key)
        {
            StringBuilder encryptValue = new StringBuilder();
            int ascii = 0;
            for(int i = 0; i < value.Length; i++)
            {
                ascii = (int)value[i] + key;
                ascii = ascii > 122 ? 96 + ((ascii - 122) % 26) : ascii;
                encryptValue.Append((char)ascii);
            }
            return encryptValue.ToString();
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static string Decryptor(string value, int key)
        {
            StringBuilder encryptValue = new StringBuilder();
            int ascii = 0;
            for(int i = 0; i < value.Length; i++)
            {
                ascii = (int)value[i] - key;
                ascii = ascii < 97 ? 123 - (97 - ascii) : ascii;
                encryptValue.Append((char)ascii);
            }
            return encryptValue.ToString();
        }

        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static string ZigzagConversion(string s, int numRows)
        {
            StringBuilder result = new StringBuilder();
            int step = 2 * (numRows - 1);
            if(numRows == 1)
            {
                return s;
            }
            for(int i = 0; i < numRows; i++)
            {
                if(i == 0 || i == numRows - 1)
                {
                    for(int j = i; j < s.Length; j += step)
                    {
                        result.Append(s[j]);
                    }
                }
                else
                {
                    int j = i;
                    bool flag = true;
                    int step1 = 2 * (numRows - 1 - i);
                    int step2 = step - step1;
                    while(j < s.Length)
                    {
                        result.Append(s[j]);
                        if(flag)
                        {
                            j = j + step1;
                        }
                        else
                        {
                            j = j + step2;
                        }
                        flag = !flag;
                    }
                }
            }
            return result.ToString();
        }
    }
}