using System;

namespace Ex7_ABBA
{
    class Program
    {
        static string makeAbba(String a, string b)
        {
            return a + b + b + a;
        }
        static void Main(string[] args)
        {
            Console.Write( makeAbba("Yo", "Sup"));
        }
    }
}