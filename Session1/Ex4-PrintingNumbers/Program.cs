using System;

namespace Ex4_PrintingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new();
            calculator.GetEvenNumbers(9);
            calculator.GetOddNumbers(9);
            calculator.GteDivisibleBy(4, 20);
        }
    }
}