using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static partial class BT
    {
        //Time Complexity: O(n) as we touching all the nodes in the Binary Tree
        //Space Complexity: o(log(n)) as we will create log(n) number of frames on call stack for recursion
        public static int MaxPathSum(BinaryTree tree)
        {
            List<int> maxSumArray = GetMaxPathSum(tree);
            return maxSumArray[1];
        }

        private static List<int> GetMaxPathSum(BinaryTree tree)
        {
            if(tree == null)
            {
                return new List<int>(){0, 0};
            }

            List<int> leftMaxSumArray = GetMaxPathSum(tree.left);
            int leftMaxSumAsBranch = leftMaxSumArray[0];
            int leftMaxSumAsPath = leftMaxSumArray[1];

            List<int> rightMaxSumArray = GetMaxPathSum(tree.right);
            int rightMaxSumAsBranch = rightMaxSumArray[0];
            int rightMaxSumAsPath = rightMaxSumArray[1];

            int maxChildSumAsBranch = Math.Max(leftMaxSumAsBranch, rightMaxSumAsBranch);
            int maxSumAsBranch = Math.Max(tree.value, maxChildSumAsBranch + tree.value);
            int maxSumAsRootNode = Math.Max(maxSumAsBranch, leftMaxSumAsBranch + rightMaxSumAsBranch + tree.value);
            int maxPathSum = Math.Max(leftMaxSumAsPath, Math.Max(rightMaxSumAsPath, maxSumAsRootNode));
            return new List<int>(){maxSumAsBranch, maxPathSum};            
        }
    }
}