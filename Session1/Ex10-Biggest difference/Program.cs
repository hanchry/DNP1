using System;

namespace Ex10___Biggest_difference
{
    class Program
    {
        static int bigDiff(int[] input)
        {
            int biggest = input[0];
            int smallest = input[0];
            
            foreach (int i in input)
            {
                if (biggest < i)
                {
                    biggest = i;
                }

                if (smallest > i)
                {
                    smallest = i;
                }
            }
            return biggest - smallest;
        }
        static void Main(string[] args)
        {
            int[] x = new[] {10, 3, 5, 6};
            Console.WriteLine(bigDiff(x));
        }
    }
}