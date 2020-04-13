namespace Algorithms.Problems
{
    public static class Bubble
    {
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] Sort(int[] array)
        {
            bool isSorted = false;
            int maxIteration = array.Length - 1;
            if(maxIteration == 0)
            {
                return new int[]{};			
            }
            else
            {
                while(!isSorted)
                {
                    isSorted = true;
                    for(int i = 0; i < maxIteration; i++)
                    {
                        if(array[i] > array[i+1])
                        {
                            int temp = array[i];
                            array[i] = array[i+1];
                            array[i + 1] = temp;
                            isSorted = false;
                        }
                    }
                    maxIteration = maxIteration - 1;
                }
                return array;
            }
        }
    }
}