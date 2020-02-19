namespace Algorithms.Application
{
    public class CycleCheck
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static bool HasAtFirstPosition(int[] array)
        {
            int currentIndex = 0, jumps = 0;
            while(jumps < array.Length)
            {
                if(jumps > 0 && currentIndex == 0)
                {
                    return false;
                }
                jumps = jumps + 1;
                currentIndex = GetTargetIndex(currentIndex, array);
            }
            return currentIndex == 0;
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static bool HasAtNthPosition(int[] array, int startIndex)
        {
            int currentIndex = startIndex, jumps = 0;
            while(jumps < array.Length)
            {
                if(jumps > 0 && currentIndex == startIndex)
                {
                    return false;
                }
                jumps = jumps + 1;
                currentIndex = GetTargetIndex(currentIndex, array);
            }
            return currentIndex == startIndex;
        }

        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int TotalNumber(int[] array)
        {
            int cycles = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if(HasAtNthPosition(array, i))
                {
                    cycles = cycles + 1;
                }
            }
            return cycles;
        }

        private static int GetTargetIndex(int currentIndex, int[] array)
        {
            int jump = array[currentIndex];
            //In c# Mod of negative number works as below
            //-5%5=0;-4%5=-4;-3%5=-3
            int nextIndex = (currentIndex + jump) % array.Length;
            return nextIndex >= 0 ? nextIndex : nextIndex + array.Length;
        }
    }
}