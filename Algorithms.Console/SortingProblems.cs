namespace Algorithms.Application
{
    public class Sort
    {
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] Bubble(int[] array)
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
    
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] Insertion(int[] array)
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
    
        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int[] Selection(int[] array)
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