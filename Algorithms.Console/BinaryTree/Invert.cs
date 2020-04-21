using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static partial class BT
    {
        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static BinaryTree InvertIteratively(BinaryTree tree)
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
        public static BinaryTree InvertRecursively(BinaryTree tree)
        {
            BinaryTree temp = tree.left;
            tree.left = tree.right;
            tree.right = temp;
            if(tree.left != null)
            {
                InvertRecursively(tree.left);
            }
            if(tree.right != null)
            {
                InvertRecursively(tree.right);
            }
            return tree;
        }
    }
}