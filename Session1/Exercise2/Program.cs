using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new();
            person.Introduce = "Andrej";
            Console.Write(person.Introduce);
        }
    }
}