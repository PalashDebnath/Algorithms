using System;

namespace Algorithms.Problems
{
    public static partial class BT
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static void InOrder(BinaryTree tree, Action<BinaryTree> callback)
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
        public static void PreOrder(BinaryTree tree, Action<BinaryTree> callback)
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
        public static void PostOrder(BinaryTree tree, Action<BinaryTree> callback)
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