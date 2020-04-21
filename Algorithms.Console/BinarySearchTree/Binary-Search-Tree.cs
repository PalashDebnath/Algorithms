namespace Algorithms.Problems
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