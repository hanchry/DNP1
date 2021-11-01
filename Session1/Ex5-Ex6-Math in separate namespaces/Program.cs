using System;
using Ex5_Math_in_separate_namespaces.MathLib;

namespace Ex5_Math_in_separate_namespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] asd = new[] {1, 2, 3, 4, 5};
            Calculator calculator = new();
            Console.Write(calculator.Add(2,2) + " ");
            Console.WriteLine(calculator.Add(asd));
            calculator.Add();
        }
    }
}