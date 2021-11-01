using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex5_Math_in_separate_namespaces.MathLib
{
    public class Calculator
    {
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public int Add(int[] array)
        {
            int result = 0;

            foreach (int x in array)
            {
                result = result + x;
            }
            
            return result;
        }

        public void Add()
        {
            Console.Write("Input two numbers: ");
            List<int> a = Console.ReadLine().Split().Select(s => int.Parse(s)).ToList();

            if (a[0] > a[1])
            {
                Console.Write(a[0]);
            }
            else
            {
                Console.Write(a[1]);
            }
        }
    }
}