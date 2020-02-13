namespace Algorithms.Application
{
    public class SelectionSort
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
                    int smallest = array[i];
                    int position = i;
                    for(int j = i + 1; j < array.Length; j++)
                    {
                        if(smallest > array[j])
                        {
                            smallest = array[j];
                            position = j;
                        }
                    }
                    array[position] = array[i];
                    array[i] = smallest;
                }
                return array;
            }
        }
    }
}