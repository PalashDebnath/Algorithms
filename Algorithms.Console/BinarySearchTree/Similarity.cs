using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static partial class BST
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
    }
}