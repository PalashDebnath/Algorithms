using System;
using System.Linq;

namespace Algorithms.Problems
{
    public static class MinimumRewards
    {
        //Time Complexity: O(n^2)
        //Space Complexity: O(n)
        public static int FindMethodOne(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            Array.Fill(rewards, 1);
            for(int i = 0; i < scores.Length; i++)
            {
                int left = i - 1;
                int right = i;
                while(left >= 0 && scores[left] > scores[right] && rewards[left] == rewards[right])
                {
                    rewards[left] =  rewards[right] + 1;
                    left = left - 1;
                    right = right - 1;
                }
                if(left >= 0 && scores[left] < scores[i] && left == i - 1)
                {
                    rewards[i] = rewards[left] + 1;
                }
            }
            return rewards.Sum();
        }

        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static int FindMethodTwo(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            Array.Fill(rewards, 1);
            for(int i = 1; i < scores.Length; i++)
            {
                if(scores[i] > scores[i - 1])
                {
                    rewards[i] = rewards[i - 1] + 1;
                }
            }

            for(int i = scores.Length - 2; i >= 0; i--)
            {
                if(scores[i] > scores[i + 1])
                {
                    rewards[i] = Math.Max(rewards[i], rewards[i + 1] + 1);
                }
            }
            return rewards.Sum();
        }
    }
}