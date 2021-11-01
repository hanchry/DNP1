using System;
using System.Net.Security;

namespace Ex9___Substring
{
    class Program
    {
        static string nTwice(string input, int n)
        {
            return input.Substring(0, n) + input.Substring(input.Length-n, n);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(nTwice("hello", 2));
            Console.WriteLine(nTwice("chocolate", 3));
            Console.WriteLine(nTwice("chocolate", 1));
        }
    }
}