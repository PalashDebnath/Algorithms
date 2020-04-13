namespace Algorithms.Problems
{
    public static class Insertion
    {
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] Sort(int[] array)
        {
            if(array.Length == 0)
            {
                return new int[]{};
            }
            else
            {
                for(int i = 0; i < array.Length - 1; i++)
                {
                    for(int j = i + 1; j > 0; j--)
                    {
                        if(array[j-1] > array[j])
                        {
                            int temp = array[j-1];
                            array[j-1] = array[j];
                            array[j] = temp;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return array;
            }
        }
    }
}