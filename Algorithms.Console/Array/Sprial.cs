using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class Sprial
    {
        //Time Complexity: O(n)
        //Space Comlexity: O(n)
        public static List<int> TraverseIteratively(int[,] array)
        {
            List<int> output = new List<int>(array.Length);
            int sRow = 0, eRow = array.GetLength(0) - 1, sCol = 0, eCol = array.GetLength(1) - 1;
            while(sRow <= eRow && sCol <= eCol)
            {
                for (int i = sCol; i <= eCol; i++)
                {
                    output.Add(array[sRow, i]);
                }
                for (int i = sRow + 1; i <= eRow; i++)
                {
                    output.Add(array[i, eCol]);
                }
                for (int i = eCol - 1; i >= sCol; i--)
                {   
                    if(sRow == eRow)
                        break;
                    output.Add(array[eRow, i]);
                }
                for (int i = eRow - 1; i > sRow; i--)
                {
                    if(sCol == eCol)
                        break;
                    output.Add(array[i, sCol]);
                }
                sRow++;
                eRow--;
                sCol++;
                eCol--;
            }
            return output;
        }

        public static List<int> TraverseRecursively(int[,] array)
        {
            List<int> output = new List<int>(array.Length);
            TraverseRecursively(0, array.GetLength(0) - 1, 0, array.GetLength(1) - 1, output, array);
            return output;
        }

        private static void TraverseRecursively(int sRow, int eRow, int sCol, int eCol, List<int> output, int[,] array)
        {
            if(sRow > eRow || sCol > eCol)
                return;

            for (int i = sCol; i <= eCol; i++)
            {
                output.Add(array[sRow, i]);
            }
            for (int i = sRow + 1; i <= eRow; i++)
            {
                output.Add(array[i, eCol]);
            }
            for (int i = eCol - 1; i >= sCol; i--)
            {   
                if(sRow == eRow)
                    break;
                output.Add(array[eRow, i]);
            }
            for (int i = eRow - 1; i > sRow; i--)
            {
                if(sCol == eCol)
                    break;
                output.Add(array[i, sCol]);
            }
            TraverseRecursively(sRow + 1, eRow - 1, sCol + 1, eCol - 1, output, array);
        }
    }
}