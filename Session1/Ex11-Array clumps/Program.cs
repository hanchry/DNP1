using System;
using System.Collections.Generic;

namespace Ex11___Array_clumps
{
    class Program
    {
        static int countClumps(int[] array)
        {
            int asd = 0;
            Boolean repetitive = false;
            int result = 0;
            
            foreach (int i in array)
            {
                if (i == asd && repetitive.Equals(false))
                {
                    result++;
                    repetitive = true;
                }
                else if (i != asd)
                {
                    asd = i;
                    repetitive = false;
                }
            }

            return result;
        }
        
        static void Main(string[] args)
        {
            int[] x1 = new[] {1, 2, 2, 3, 4, 4};
            int[] x2 = new[] {1, 1, 2, 1, 1};
            int[] x3 = new[] {1, 1, 1, 1, 1, 1};
            Console.WriteLine(countClumps(x1));
            Console.WriteLine(countClumps(x2));
            Console.WriteLine(countClumps(x3));
        }
    }
}