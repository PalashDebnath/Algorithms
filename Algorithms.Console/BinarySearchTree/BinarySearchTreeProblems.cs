using System;
using System.Collections.Generic;

namespace Algorithms.Application
{
    public class BinarySearchTree
    {
        public int value;
        public BinarySearchTree left;
        public BinarySearchTree right;

        public BinarySearchTree(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }

        //Non Recursive BinarySearchTree Insert
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(1)
        public BinarySearchTree IterativeInsert(int value)
        {
            BinarySearchTree current = this;
            while(true)
            {
                if(value < current.value)
                {
                    if(current.left != null)
                    {
                        current = current.left;
                    }
                    else
                    {
                        current.left = new BinarySearchTree(value);
                        break;
                    }
                }
                else
                {
                    if(current.right != null)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current.right = new BinarySearchTree(value);
                        break;
                    }
                }
            }
            return this;
        }
        
        //Non Recursive BinarySearchTree Search
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(1)
        public bool IterativeContain(int value)
        {
            BinarySearchTree current = this;
            while(current != null)
            {
                if(value < current.value)
                {
                    current = current.left;
                }
                else if(value > current.value)
                {
                    current = current.right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        //Non Recursive BinarySearchTree Delete
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(1)
        public BinarySearchTree IterativeRemove(int value)
        {
            IterativeRemove(value, null);
            return this;
        }

        private void IterativeRemove(int value, BinarySearchTree parent)
        {
            BinarySearchTree current = this;
            while(current != null)
            {
                 if(value < current.value)
                {
                    parent = current;
                    current = current.left;
                }
                else if(value > current.value)
                {
                    parent = current;
                    current = current.right;
                }
                else
                {
                    if(current.left != null && current.right != null)
                    {
                        current.value = current.right.GetMinimumRightChildValue();
                        current.right.IterativeRemove(current.value, current);
                    }
                    else if(parent == null)
                    {
                        if(current.left != null)
                        {
                            current.value = current.left.value;
                            current.right = current.left.right;
                            current.left = current.left.left;
                        }
                        else if(current.right != null)
                        {
                            current.value = current.right.value;
                            current.left = current.right.left;
                            current.right = current.right.right;
                        }
                        else
                        {
                            current = null;
                        }
                    }
                    else if(parent.left == current)
                    {
                        parent.left = current.left != null ? current.left : current.right; 
                    }
                    else if(parent.right == current)
                    {
                        parent.right = current.left != null ? current.left : current.right; 
                    }
                    break;
                }
            }
        }

        //Recursive BinarySearchTree Insert
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: Average case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree
        //                  @@Each Recursive call will hold a frame in call stack      
        public BinarySearchTree RecursiveInsert(int value)
        {
            if(value < this.value)
            {
                if(this.left != null)
                {
                    left.RecursiveInsert(value);
                }
                else
                {
                    left = new BinarySearchTree(value);
                }
            }
            else
            {
                if(this.right != null)
                {
                    right.RecursiveInsert(value);
                }
                else
                {
                    right = new BinarySearchTree(value);
                }
            }
            return this;
        }

        //Recursive BinarySearchTree Search
        //Time Complexity: Average Case --> O(lon(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: Average case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree
        //                  @@Each Recursive call will hold a frame in call stack
        public bool RecursiveContain(int value)
        {
            if(this != null)
            {
                if(value < this.value)
                {
                    return left.RecursiveContain(value);
                }
                else if(value > this.value)
                {
                    return right.RecursiveContain(value);
                }
                else
                {
                    return true;
                }
            }
            return false;            
        }

        //Recursive BinarySearchTree Delete
        //Time Complexity: Average Case --> O(lon(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: Average case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree
        //                  @@Each Recursive call will hold a frame in call stack
        public BinarySearchTree RecursiveRemove(int value)
        {
            RecursiveRemove(value, null);
            return this;
        }

        private void RecursiveRemove(int value, BinarySearchTree parent)
        {
            if(value < this.value)
            {
                if(left != null)
                {
                    left.RecursiveRemove(value, this);
                }
            }
            else if(value > this.value)
            {
                if(right != null)
                {
                    right.RecursiveRemove(value, this);
                }
            }
            else
            {
                if(this.left != null && this.right != null)
                {
                    this.value = this.right.GetMinimumRightChildValue();
                    this.right.RecursiveRemove(this.value, this);
                }
                else if(parent == null)
                {
                    if(this.left != null)
                    {
                        this.value = this.left.value;
                        this.right = this.left.right;
                        this.left = this.left.left;
                    }
                    else if(this.right != null)
                    {
                        this.value = this.right.value;
                        this.left = this.right.left;
                        this.right = this.right.right;
                    }
                    else
                    {
                        this.value = 0;
                    }
                }
                else if(parent.left == this)
                {
                    parent.left = this.left != null ? this.left : this.right; 
                }
                else if(parent.right == this)
                {
                    parent.right = this.left != null ? this.left : this.right;
                }
            }
        }

        //Non Recursively find the closest value in BinarySearchTree
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(1)
        public int IterativeClosestFinder(int target)
        {
            BinarySearchTree current = this;
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
        public int RecursiveClosestFinder(int target)
        {
            return RecursiveClosestFinder(this, target, this.value);            
        }

        private int RecursiveClosestFinder(BinarySearchTree tree, int target, int closest)
        {
            if(Math.Abs(target - closest) > Math.Abs(target - tree.value))
            {
                closest = tree.value;
            }
            if(target < tree.value && tree.left != null)
            {
                return RecursiveClosestFinder(tree.left, target, closest);
            }
            else if(target > tree.value && tree.right != null)
            {
                return RecursiveClosestFinder(tree.right, target, closest);
            }
            else
            {
                return (int)closest;
            }
        }

        private int GetMinimumRightChildValue()
        {
            if(left == null)
            {
                return value;
            }
            else
            {
                return left.GetMinimumRightChildValue();
            }
        }
    }

    public static class BinarySearchTreeMethods
    {
        //Time Complexity: O(n^2) for eash record in the array you are going through the entire array to find out the next left or right child of the BinarySearchTree.
        //Space Complexity: O(d) it will genarate d(depth of the tree) number of frame in call stack for recursive call.
        public static bool CheckSimilarity(List<int> arrayOne, List<int> arrayTwo)
        {
            return CheckSimilarity(arrayOne, arrayTwo, 0, 0, Int32.MinValue, Int32.MaxValue);;
        }

        private static bool CheckSimilarity(List<int> arrayOne, List<int> arrayTwo, int leftRoot, int rightRoot, int minValue, int maxValue)
        {
            if(leftRoot < 0 || rightRoot < 0)
            {
                return leftRoot == rightRoot;
            }
            else if(arrayOne[leftRoot] != arrayTwo[rightRoot])
            {
                return false;
            }
            else
            {
                int smallerIndexLeft = 0, smallerIndexRight = 0, largerIndexLeft = 0, largerIndexRight = 0;
                smallerIndexLeft = GetFirstSmallerIndex(arrayOne, minValue, leftRoot);
                smallerIndexRight = GetFirstSmallerIndex(arrayTwo, minValue, rightRoot);
                largerIndexLeft = GetFirstLargerIndex(arrayOne, maxValue, leftRoot);
                largerIndexRight = GetFirstLargerIndex(arrayTwo, maxValue, rightRoot);
                return CheckSimilarity(arrayOne, arrayTwo, smallerIndexLeft, smallerIndexRight, minValue, arrayOne[leftRoot])
                        && CheckSimilarity(arrayOne, arrayTwo, largerIndexLeft, largerIndexRight, arrayOne[leftRoot], maxValue);
            }
        }

        private static int GetFirstSmallerIndex(List<int> array, int minValue, int rootIndex)
        {
            for(int i = rootIndex + 1; i < array.Count; i++)
            {
                if(array[i] < array[rootIndex] && array[i] >= minValue)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int GetFirstLargerIndex(List<int> array, int maxValue, int rootIndex)
        {
            for(int i = rootIndex + 1; i < array.Count; i++)
            {
                if(array[i] >= array[rootIndex] && array[i] <= maxValue)
                {
                    return i;
                }
            }

            return -1;
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static bool ValidateBinarySearchTree(BinarySearchTree tree)
        {
            return ValidateBinarySearchTree(tree, Int32.MinValue, Int32.MaxValue);
        }

        private static bool ValidateBinarySearchTree(BinarySearchTree tree, int lowest, int highest)
        {
            if(tree.left != null && !ValidateBinarySearchTree(tree.left, lowest, tree.value))
            {                
                return false;
            }
            if(tree.right != null && !ValidateBinarySearchTree(tree.right, tree.value, highest))
            {
                return false;
            }
            return tree.value >= lowest && tree.value < highest ? true : false;
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static List<int> InOrderTraverse(BinarySearchTree tree, List<int> array)
        {
            if(tree.left != null)
            {
                InOrderTraverse(tree.left, array);
            }

            array.Add(tree.value);

            if(tree.right != null)
            {
                InOrderTraverse(tree.right, array);
            }
            return array;
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static List<int> PreOrderTraverse(BinarySearchTree tree, List<int> array)
        {
            array.Add(tree.value);

            if(tree.left != null)
            {
                PreOrderTraverse(tree.left, array);
            }            
            
            if(tree.right != null)
            {
                PreOrderTraverse(tree.right, array);
            }
            return array;
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static List<int> PostOrderTraverse(BinarySearchTree tree, List<int> array)
        {
            if(tree.left != null)
            {
                PostOrderTraverse(tree.left, array);
            }            
            
            if(tree.right != null)
            {
                PostOrderTraverse(tree.right, array);
            }

            array.Add(tree.value);
            return array;
        }
    }
}