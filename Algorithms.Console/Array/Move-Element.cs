namespace Algorithms.Problems
{
    public static class MoveElement
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int[] ToStart(int[] array, int toMove)
        {
            int leftPointer = 0, rightPointer = array.Length - 1;
            while(leftPointer < rightPointer)
            {
                if(array[leftPointer] == toMove)
                {
                    leftPointer = leftPointer + 1;
                }
                else if(array[rightPointer] != toMove)
                {
                    rightPointer = rightPointer - 1;
                }
                else
                {
                    int temp = array[leftPointer];
                    array[leftPointer] = array[rightPointer];
                    array[rightPointer] = temp;
                }

            }
            return array;
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static int[] ToEnd(int[] array, int toMove)
        {
            int leftPointer = 0, rightPointer = array.Length - 1;
            while(leftPointer < rightPointer)
            {
                if(array[rightPointer] == toMove)
                {
                    rightPointer = rightPointer - 1;
                }
                else if(array[leftPointer] != toMove)
                {
                    leftPointer = leftPointer + 1;
                }
                else
                {
                    int temp = array[rightPointer];
                    array[rightPointer] = array[leftPointer];
                    array[leftPointer] = temp;
                }

            }
            return array;
        }
    }
}