using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class SmallestSubstring
    {
        public static string Containing(string bigstring, string smallstring)
        {
            Dictionary<char, int> targetCharCounts = GetCharacterCount(smallstring);
            List<int> bound = GetSubstringBound(bigstring, targetCharCounts);
            return bound.Count == 0 ? "" : bigstring.Substring(bound[0], bound[1] - bound[0] + 1);
        }

        private static List<int> GetSubstringBound(string str, Dictionary<char, int> targetCharCounts)
        {
            int left = 0, right = 0, totalCharactersFound = 0;
            List<int> bound = new List<int>();
            Dictionary<char, int> substringCharCounts = new Dictionary<char, int>();
            while(right < str.Length)
            {
                char rightChar = str[right];
                if(!targetCharCounts.ContainsKey(rightChar))
                {
                    right++;
                    continue;
                }

                if(substringCharCounts.ContainsKey(rightChar))
                    substringCharCounts[rightChar] += 1;
                else
                    substringCharCounts.Add(rightChar, 1);

                if(substringCharCounts[rightChar] == targetCharCounts[rightChar])
                    totalCharactersFound += 1;

                while (targetCharCounts.Count == totalCharactersFound && left <= right)
                {
                    if(bound.Count == 0)
                    {
                        bound.Add(left);
                        bound.Add(right);
                    }
                    else if((bound[1] - bound[0]) > (right - left))
                    {
                        bound.Clear();
                        bound.Add(left);
                        bound.Add(right);
                    }

                    char leftChar = str[left];
                    
                    if(!targetCharCounts.ContainsKey(leftChar))
                    {
                        left += 1;
                        continue;
                    }

                    if(substringCharCounts[leftChar] == targetCharCounts[leftChar])
                        totalCharactersFound -= 1;

                    substringCharCounts[leftChar] -= 1;

                    left += 1;
                }
                right += 1;
            }
            return bound;
        }

        private static Dictionary<char, int> GetCharacterCount(string str)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if(counts.ContainsKey(c))
                {
                    counts[c] += 1;
                }
                else
                {
                    counts.Add(c, 1);
                }
            }
            return counts;
        }
    }
}