using System;

namespace Algorithms.Problems
{
    public static partial class BST
    {
        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static bool Validate(BinarySearchTree tree)
        {
            return Validate(tree, Int32.MinValue, Int32.MaxValue);
        }

        private static bool Validate(BinarySearchTree tree, int lowest, int highest)
        {
            if(tree.left != null && !Validate(tree.left, lowest, tree.value))
            {                
                return false;
            }
            if(tree.right != null && !Validate(tree.right, tree.value, highest))
            {
                return false;
            }
            return tree.value >= lowest && tree.value < highest ? true : false;
        }
    }
}