using System;

namespace Algorithms.Problems
{
    public static partial class BST
    {
        //Find the closest value in BinarySearchTree Iteratively
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(1)
        public static int FindClosestValueIteratively(BinarySearchTree tree, int target)
        {
            BinarySearchTree current = tree;
            int closest = current.value;
            while(current != null)
            {
                if(Math.Abs(target - closest) > Math.Abs(target - current.value))
                {
                    closest = current.value;
                }
                if(target < current.value)
                {
                    current = current.left;
                }
                else if(target > current.value)
                {
                    current = current.right;
                }
                else
                {
                    break; 
                }
            }
            return (int)closest;
        }

        //Recursively find the closest value in BinarySearchTree
        //Time Complexity: Average Case --> O(lon(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: Average case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree
        //                  @@Each Recursive call will hold a frame in call stack
        public static int FindClosestValueRecursively(BinarySearchTree tree, int target)
        {
            return FindClosestValueRecursively(tree, target, tree.value);            
        }

        private static int FindClosestValueRecursively(BinarySearchTree tree, int target, int closest)
        {
            if(Math.Abs(target - closest) > Math.Abs(target - tree.value))
            {
                closest = tree.value;
            }
            if(target < tree.value && tree.left != null)
            {
                return FindClosestValueRecursively(tree.left, target, closest);
            }
            else if(target > tree.value && tree.right != null)
            {
                return FindClosestValueRecursively(tree.right, target, closest);
            }
            else
            {
                return (int)closest;
            }
        }
    }
}