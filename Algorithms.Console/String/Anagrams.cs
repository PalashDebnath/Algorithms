using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class Anagrams
    {
        //Time Complexity: O(w*l) w --> Number of Words, l --> Number of Letter in Word
        //Space Complexity: O(w*l)
        public static List<List<string>> Group(List<string> words)
        {
            Dictionary<int, List<string>> memorize = new Dictionary<int, List<string>>();
            List<List<string>> results = new List<List<string>>();
            foreach (var word in words)
            {
                int weightage = 0;
                foreach (var letter in word)
                {
                    weightage += (int)letter;
                }

                if(memorize.ContainsKey(weightage))
                {
                    memorize[weightage].Add(word);
                }
                else
                {
                    memorize.Add(weightage, new List<string>() { word });
                }
            }

            foreach (var item in memorize)
            {
                results.Add(item.Value);
            }

            return results;
        }
    }
}