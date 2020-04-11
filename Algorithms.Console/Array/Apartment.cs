using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Problems
{
    public static class Apartment
    {
        //Time Complexity: O((b^2)*r) where the b is the length of the blocks list and r is the size of the reqs list
        //Space Complexity: O(1)
        public static int FindMethodOne(List<Dictionary<string,bool>> blocks, string[] reqs)
        {
            int blockIndex = 0, minDistance = Int32.MaxValue;
            for(int i = 0; i < blocks.Count; i++)
            {
                int maxDistance = Int32.MinValue;
                foreach(string req in reqs)
                {
                    int closestDistance = Int32.MaxValue;
                    for(int j = 0; j < blocks.Count; j++)
                    {
                        if(blocks[j].ContainsKey(req) && blocks[j][req])
                        {
                            closestDistance = Math.Min(closestDistance, Math.Abs(i - j));
                        }
                    }
                    maxDistance = Math.Max(maxDistance, closestDistance);
                }
                if(minDistance > maxDistance)
                {
                    minDistance = maxDistance;
                    blockIndex = i;
                } 
            }
            return blockIndex;
        }

        //Time Complexity: O(b*r) where the b is the length of the blocks list and r is the size of the reqs list
        //Space Complexity: O(b)
        public static int FindMethodTwo(List<Dictionary<string,bool>> blocks, string[] reqs)
        {
            int[] maxDistances = new int[blocks.Count];
            int[] closestDistances = new int[blocks.Count];
            Array.Fill(maxDistances, Int32.MinValue);
            foreach(string req in reqs)
            {
                Array.Fill(closestDistances, Int32.MaxValue);
                for(int j = 0; j < blocks.Count; j++)
                {
                    if(blocks[j].ContainsKey(req) && blocks[j][req])
                    {
                        closestDistances[j] = 0;
                    }
                    else
                    {
                        if(j > 0)
                        {
                            closestDistances[j] = closestDistances[j - 1] == Int32.MaxValue ? Int32.MaxValue : closestDistances[j - 1] + 1;
                        }
                    }                     
                }
                for(int i = closestDistances.Length - 2; i >= 0; i--)
                {
                    closestDistances[i] = Math.Min(closestDistances[i], closestDistances[i + 1] + 1);
                }
                for(int i = 0; i < blocks.Count; i++)
                {
                    Console.Write(closestDistances[i] + " ");
                    maxDistances[i] = Math.Max(maxDistances[i], closestDistances[i]);
                }
                Console.WriteLine();
            }
            return Array.IndexOf(maxDistances, maxDistances.Min());
        }
    }
}