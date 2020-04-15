using System.Collections.Generic;
using System.Text;

namespace Algorithms.Problems
{
    public static class PatternMatcher
    {
        //Time Complexity: O(n^2 + m) n --> Length of the main string, m --> Length of the pattern
        //Space Complexity: O(n + m)
        public static string[] Attributes(string pattern, string str)
        {
            if(pattern.Length > str.Length)
                return new string[] {};
            char[] newPattern = ConvertPattern(pattern);
            bool isConverted = newPattern[0] != pattern[0];
            Dictionary<char, int> counts = new Dictionary<char, int>();
            counts.Add('x', 0);
            counts.Add('y', 0);
            int yFirstIndex = GetCounts(newPattern, counts);
            if(counts['y'] != 0)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    int xLength = i + 1;
                    int yLength = (str.Length - xLength * counts['x']) / counts['y'];
                    if(yLength <= 0)
                        continue;
                    string xValue = str.Substring(0, xLength);
                    string yValue = str.Substring(yFirstIndex * xLength, yLength);
                    string potentialMatch = BuildStringFromPattern(newPattern, xValue, yValue);
                    if(str.Equals(potentialMatch))
                        return isConverted ? new string[] {yValue, xValue} : new string[] {xValue, yValue}; 
                }
            }
            else
            {
                int xLength = str.Length / counts['x'];
                string xValue = str.Substring(0, xLength);
                string potentialMatch = BuildStringFromPattern(newPattern, xValue, "");
                if(str.Equals(potentialMatch))
                    return isConverted ? new string[] {"", xValue} : new string[] {xValue, ""};
            }

            return new string[] {};
        }

        private static char[] ConvertPattern(string pattern)
        {
            char[] newPattern = pattern.ToCharArray();

            if(newPattern[0] == 'x')
                return newPattern;

            for (int i = 0; i < newPattern.Length; i++)
            {
                if(newPattern[i] == 'y')
                {
                    newPattern[i] = 'x';
                }
                else
                {
                    newPattern[i] = 'y';
                }
            }
            return newPattern;
        }

        private static int GetCounts(char[] pattern, Dictionary<char, int> counts)
        {
            int yFirstIndex = -1;            
            for (int i = 0; i < pattern.Length; i++)
            {
                if(pattern[i] == 'x')
                {
                    counts['x'] += 1;
                }
                else
                {
                    if(counts['y'] == 0)
                        yFirstIndex = i;
                    counts['y'] += 1;
                }
            }
            return yFirstIndex;
        }

        private static string BuildStringFromPattern(char[] pattern, string xValue, string yValue)
        {
            StringBuilder build = new StringBuilder();
            for (int i = 0; i < pattern.Length; i++)
            {
                if(pattern[i] == 'x')
                    build.Append(xValue);
                else
                    build.Append(yValue);
            }
            
            return build.ToString();
        }
    }
}