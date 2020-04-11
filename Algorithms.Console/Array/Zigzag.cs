using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class Zigzag
    {
        //Time Complexity: O(n)
        //Space Complexity: O(n)
        public static List<int> Traverse(List<List<int>> array)
        {
            int row = 0, column = 0, height = array.Count - 1, width = array[0].Count - 1;
            bool isDown = true;
            List<int> result = new List<int>();
            while(column >= 0 && column <= width && row >= 0 && row <= height)
            {
                result.Add(array[row][column]);
                if(isDown)
                {
                    if(column == 0 || row == height)
                    {
                        isDown = false;
                        if(row == height)
                        {
                            column++;
                        }
                        else
                        {
                            row++;
                        }
                    }
                    else
                    {
                        row++;
                        column--;
                    }
                }
                else
                {
                    if(row == 0 || column == width)
                    {
                        isDown = true;
                        if(column == width)
                        {
                            row++;
                        }
                        else
                        {
                            column++;
                        }
                    }
                    else
                    {
                        row--;
                        column++;
                    }
                }
            }
            return result;
        }
    }
}