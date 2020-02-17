using System;
using System.Collections.Generic;

namespace Algorithms.Application
{
    public class BST
    {
        public int value;
        public BST left;
        public BST right;

        public BST(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static bool ValidateBST(BST tree)
        {
            return ValidateBST(tree, Int32.MinValue, Int32.MaxValue);
        }

        private static bool ValidateBST(BST tree, int lowest, int highest)
        {
            if(tree.left != null && !ValidateBST(tree.left, lowest, tree.value))
            {                
                return false;
            }
            if(tree.right != null && !ValidateBST(tree.right, tree.value, highest))
            {
                return false;
            }
            return tree.value >= lowest && tree.value < highest ? true : false;
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static List<int> InOrderTraverse(BST tree, List<int> array)
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
        public static List<int> PreOrderTraverse(BST tree, List<int> array)
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
        public static List<int> PostOrderTraverse(BST tree, List<int> array)
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

        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static void IterativeInvertBinaryTree(BST tree)
        {
            List<BST> queue = new List<BST>();
            int index = 0;
            queue.Add(tree);
            while(index < queue.Count)
            {
                BST temp = queue[index].left;
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
        }

        //Time Comlexity : O(n)
        //Space Complexity: O(d) where d is the depth of the tree. Highest depth of the tree will generate that many frames in call stack
        public static void RecursiveInvertBinaryTree(BST tree)
        {
            BST temp = tree.left;
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
        }

        //Non Recursive BST Insert
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(1)
        public BST IterativeInsert(int value)
        {
            BST current = this;
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
                        current.left = new BST(value);
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
                        current.right = new BST(value);
                        break;
                    }
                }
            }
            return this;
        }
        
        //Non Recursive BST Search
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(1)
        public bool IterativeContain(int value)
        {
            BST current = this;
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

        //Non Recursive BST Delete
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(1)
        public BST IterativeRemove(int value)
        {
            IterativeRemove(value, null);
            return this;
        }

        private void IterativeRemove(int value, BST parent)
        {
            BST current = this;
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

        //Recursive BST Insert
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: Average case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree
        //                  @@Each Recursive call will hold a frame in call stack      
        public BST RecursiveInsert(int value)
        {
            if(value < this.value)
            {
                if(this.left != null)
                {
                    left.RecursiveInsert(value);
                }
                else
                {
                    left = new BST(value);
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
                    right = new BST(value);
                }
            }
            return this;
        }

        //Recursive BST Search
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

        //Recursive BST Delete
        //Time Complexity: Average Case --> O(lon(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: Average case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree
        //                  @@Each Recursive call will hold a frame in call stack
        public BST RecursiveRemove(int value)
        {
            RecursiveRemove(value, null);
            return this;
        }

        private void RecursiveRemove(int value, BST parent)
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

        //Non Recursively find the closest value in BST
        //Time Complexity: Average Case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(1)
        public int IterativeClosestFinder(int target)
        {
            BST current = this;
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

        //Recursively find the closest value in BST
        //Time Complexity: Average Case --> O(lon(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: Average case --> O(log(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree
        //                  @@Each Recursive call will hold a frame in call stack
        public int RecursiveClosestFinder(int target)
        {
            return RecursiveClosestFinder(this, target, this.value);            
        }

        private int RecursiveClosestFinder(BST tree, int target, int closest)
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

        //Recursively find the sum of the branch in BST
        //Time Complexity: Average Case --> O(lon(n)) where the tree is balanced; Worst Case --> O(n) Where we have one long single chain in a tree 
        //Space Complexity: O(log(n)) + O(n/2) --> O(n), Where O(log(n)) is the number of frame in call stack and o(n/2) is the list size which will be equal to the leaf node in the tree ~~ n/2
        public List<int> BranchSum()
        {
            return BranchSum(this, new List<int>(), 0);
        }

        private List<int> BranchSum(BST tree, List<int> sums,int currentSum)
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
}