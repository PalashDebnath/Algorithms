using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Algorithms.Application
{
    public class BinaryTree
    {
        public int value;
        public BinaryTree left;
        public BinaryTree right;
        public BinaryTree parent;

        public BinaryTree(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }

        //Recursively find the sum of the branch in BinaryTree
        //Time Complexity: Average Case --> O(lon(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(log(n)) + O(n/2) --> O(n), Where O(log(n)) is the number of frame in call stack and o(n/2) is the list size which will be equal to the leaf node in the tree ~~ n/2
        public List<int> BranchSum()
        {
            return BranchSum(this, new List<int>(), 0);
        }

        private List<int> BranchSum(BinaryTree tree, List<int> sums,int currentSum)
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

    public static class BinaryTreeMethods
    {
        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static BinaryTree IterativeInvertBinaryTree(BinaryTree tree)
        {
            List<BinaryTree> queue = new List<BinaryTree>();
            int index = 0;
            queue.Add(tree);
            while(index < queue.Count)
            {
                BinaryTree temp = queue[index].left;
                queue[index].left = queue[index].right;
                queue[index].right = temp;
                if(queue[index].left != null)
                {
                    queue.Add(queue[index].left);
                }
                if(queue[index].right != null)
                {
                    queue.Add(queue[index].right);
                }
                index = index + 1;
            }
            return tree;
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static BinaryTree RecursiveInvertBinaryTree(BinaryTree tree)
        {
            BinaryTree temp = tree.left;
            tree.left = tree.right;
            tree.right = temp;
            if(tree.left != null)
            {
                RecursiveInvertBinaryTree(tree.left);
            }
            if(tree.right != null)
            {
                RecursiveInvertBinaryTree(tree.right);
            }
            return tree;
        }

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

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static void IterativeInOrderTraversal(BinaryTree tree, Action<BinaryTree> callback)
        {
            BinaryTree previuos = null;
            BinaryTree current = tree;
            while(current != null)
            {
                if(previuos == null || current.parent == previuos)
                {
                    if(current.left != null)
                    {
                        previuos = current;
                        current = current.left;
                    }
                    else if(current.right != null)
                    {
                        callback(current);
                        previuos = current;
                        current = current.right;
                    }
                    else
                    {
                        callback(current);
                        previuos = current;
                        current = current.parent;
                    }
                }
                else
                {
                    if(current.left == previuos)
                    {
                        callback(current);
                        if(current.right != null)
                        {
                            previuos = current;
                            current = current.right;
                        }
                        else
                        {
                            previuos = current;
                            current = current.parent;
                        }
                    }
                    else
                    {
                        previuos = current;
                        current = current.parent;
                    }
                    
                }
            }
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static void IterativePreOrderTraversal(BinaryTree tree, Action<BinaryTree> callback)
        {
            BinaryTree previuos = null;
            BinaryTree current = tree;
            while(current != null)
            {
                if(previuos == null || current.parent == previuos)
                {
                    if(current.left != null)
                    {
                        callback(current);
                        previuos = current;
                        current = current.left;
                    }
                    else if(current.right != null)
                    {
                        previuos = current;
                        current = current.right;
                    }
                    else
                    {
                        callback(current);
                        previuos = current;
                        current = current.parent;
                    }
                }
                else
                {
                    if(current.left == previuos)
                    {
                        if(current.right != null)
                        {
                            previuos = current;
                            current = current.right;
                        }
                        else
                        {
                            previuos = current;
                            current = current.parent;
                        }
                    }
                    else
                    {
                        previuos = current;
                        current = current.parent;
                    }
                    
                }
            }
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static void IterativePostOrderTraversal(BinaryTree tree, Action<BinaryTree> callback)
        {
            BinaryTree previuos = null;
            BinaryTree current = tree;
            while(current != null)
            {
                if(previuos == null || current.parent == previuos)
                {
                    if(current.left != null)
                    {
                        previuos = current;
                        current = current.left;
                    }
                    else if(current.right != null)
                    {
                        previuos = current;
                        current = current.right;
                    }
                    else
                    {
                        callback(current);
                        previuos = current;
                        current = current.parent;
                    }
                }
                else
                {
                    if(current.left == previuos)
                    {
                        if(current.right != null)
                        {
                            previuos = current;
                            current = current.right;
                        }
                        else
                        {
                            previuos = current;
                            current = current.parent;
                        }
                    }
                    else
                    {
                        callback(current);
                        previuos = current;
                        current = current.parent;
                    }
                    
                }
            }
        }
    }
}