namespace Algorithms.Problems
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

    }
}