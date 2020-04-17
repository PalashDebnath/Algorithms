namespace Algorithms.Problems
{
    public static class SortedMatrix
    {
        //Time Complexity: O(m + n)
        //Space Complexity: O(1)
        public static int[] Search(int[,] matrix, int target)
        {
            int row = 0, col = matrix.GetLength(1) - 1;
            while(row < matrix.GetLength(0) && col >= 0)
            {
                if(matrix[row, col] > target)
                {
                    col -= 1;
                }
                else if(matrix[row, col] < target)
                {
                    row += 1;
                }
                else
                {
                    return new int[] { row, col};
                }
            }
            return new int[] {-1, -1};
        }
    }
}