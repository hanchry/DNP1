using System;

namespace Ex4_PrintingNumbers
{
    public class Calculator
    {

        public void GetEvenNumbers(int limit)
        {
            for (int i = 2; i <= limit; i = i + 2 )
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void GetOddNumbers(int limit)
        {
            for (int i = -1; i <= limit; i = i + 2 )
            {
                if (i > 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        public void GteDivisibleBy(int divider, int limit)
        {
            for (int i = 0; i <= limit; i++ )
            {
                if (i % divider == 0 && i > 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}