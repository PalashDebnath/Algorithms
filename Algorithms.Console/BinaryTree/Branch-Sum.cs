using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static partial class BT
    {
        //Recursively find the sum of the branch in BinaryTree
        //Time Complexity: Average Case --> O(lon(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(log(n)) + O(n/2) --> O(n), Where O(log(n)) is the number of frame in call stack and o(n/2) is the list size which will be equal to the leaf node in the tree ~~ n/2
        public static List<int> BranchSum(BinaryTree tree)
        {
            return BranchSum(tree, new List<int>(), 0);
        }

        private static List<int> BranchSum(BinaryTree tree, List<int> sums,int currentSum)
        {
            currentSum = currentSum + tree.value;
            if(tree.left == null && tree.right == null)
            {
                sums.Add(currentSum);
            }
            else
            {
                if(tree.left != null)
                {
                    BranchSum(tree.left, sums, currentSum);
                }
                if(tree.right != null)
                {
                    BranchSum(tree.right, sums, currentSum);
                }
            }
            return sums;
        }
    }
}