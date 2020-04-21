using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static partial class BST
    {
        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static List<int> InOrder(BinarySearchTree tree, List<int> array)
        {
            if(tree.left != null)
            {
                InOrder(tree.left, array);
            }

            array.Add(tree.value);

            if(tree.right != null)
            {
                InOrder(tree.right, array);
            }
            return array;
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static List<int> PreOrder(BinarySearchTree tree, List<int> array)
        {
            array.Add(tree.value);

            if(tree.left != null)
            {
                PreOrder(tree.left, array);
            }            
            
            if(tree.right != null)
            {
                PreOrder(tree.right, array);
            }
            return array;
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static List<int> PostOrder(BinarySearchTree tree, List<int> array)
        {
            if(tree.left != null)
            {
                PostOrder(tree.left, array);
            }            
            
            if(tree.right != null)
            {
                PostOrder(tree.right, array);
            }

            array.Add(tree.value);
            return array;
        }
    }
}