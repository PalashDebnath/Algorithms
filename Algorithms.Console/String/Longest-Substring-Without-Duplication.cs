using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class LongestSubstringWithoutDuplication
    {
        //Time Complexity: O(n)
        //Space Complexity: O(Min(n,a)) a repensent number of unique character in the hash table 
        public static int Length(string s) {
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

        //Time Complexity: O(n)
        //Space Complexity: O(Min(n,a)) a repensent number of unique character in the hash table 
        public static string Value(string s) {
            Dictionary<char, int> memorize = new Dictionary<char, int>();
            int start = 0;
            string subString = null;
            for(int i = 0; i < s.Length; i++) {
                if(memorize.ContainsKey(s[i])) {
                    start = Math.Max(start, memorize[s[i]] + 1);
                    memorize[s[i]] = i;
                }
                else {
                    memorize.Add(s[i], i);
                }
                if(String.IsNullOrEmpty(subString))
                    subString = s.Substring(start, i - start + 1);
                else
                    subString = (i - start + 1) > subString.Length ? s.Substring(start, i - start + 1) : subString;
            }
            return subString;
        }
    }
}