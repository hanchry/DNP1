using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex8___Surround_with
{
    class Program
    {
        static string makeOutWorld(string a, string b)
        {
           return a.Substring(0,a.Length/2) + b + a.Substring(2,a.Length/2);
        }
        static void Main(string[] args)
        {
            Console.Write(makeOutWorld("<<>>","asd"));
        }
    }
}