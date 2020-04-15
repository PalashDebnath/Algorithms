using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class Underscorify
    {
        //Time Complexity: O(n*m)
        //Space Complexity: O(n)
        public static string Substring(string str, string substring)
        {
            List<int[]> indices = GetIndices(str, substring);
            indices = MergeIndices(indices);
            string output = Modify(str, indices);
            return output;
        }

        private static List<int[]> GetIndices(string mainString, string substring)
        {
            List<int[]> indices = new List<int[]>();
            int sIndex = 0;
            while(sIndex < mainString.Length)
            {
                int nIndex = mainString.IndexOf(substring, sIndex);
                if(nIndex >= 0)
                {
                    indices.Add(new int[]{ nIndex, nIndex + substring.Length });
                    sIndex = nIndex + 1;
                }
                else
                {
                    break;
                }
            }
            return indices;
        }

        private static List<int[]> MergeIndices(List<int[]> indices)
        {
            if(indices.Count <= 1)
                return indices;

            List<int[]> mergeIndices = new List<int[]>();
            mergeIndices.Add(indices[0]);
            int[] previous = mergeIndices[0];
            for (int i = 1; i < indices.Count; i++)
            {
                int[] current = indices[i];
                if(current[0] <= previous[1])
                {
                    previous[1] = current[1];
                }
                else
                {
                    mergeIndices.Add(current);
                    previous = current;
                }
            }
            return mergeIndices;
        }

        private static string Modify(string mainString, List<int[]> indices)
        {
            List<char> letters = new List<char>();
            int sIndex = 0, iIndex = 0, i = 0;
            bool isMiddle = false;
            while (sIndex < mainString.Length && iIndex < indices.Count)
            {
                if(sIndex == indices[iIndex][i])
                {
                    letters.Add('_');
                    isMiddle = !isMiddle;
                    if(!isMiddle)
                        iIndex += 1;
                    i = i == 1 ? 0 : 1;
                }
                letters.Add(mainString[sIndex]);
                sIndex += 1;
            }
            if(iIndex < indices.Count)
                letters.Add('_');
            while(sIndex < mainString.Length)
            {
                letters.Add(mainString[sIndex]);
                sIndex += 1;
            }
            return String.Join("", letters);
        }
    }
}