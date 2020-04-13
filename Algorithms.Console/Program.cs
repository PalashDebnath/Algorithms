using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int[]> sort = FourNumberSum.UsingHashTable(new int[] {-10, -3, -5, 2, 15, -7, 28, -6, 12, 8, 11, 5}, 20);
            foreach (var s in sort)
            {
                foreach (var item in s)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }            
        }
    }
}
