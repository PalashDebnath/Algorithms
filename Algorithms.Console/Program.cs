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
            List<int[]> abcd = FourNumberSum.UsingHashTable(new int[] {1, 2, 3, 4, 5, 6, 7}, 10);
            foreach (var item in abcd)
            {
                foreach (var i in item)
                {
                    Console.Write(i);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
