using System;
using System.Runtime.InteropServices;

namespace Exercise2
{
    public class Person
    {
        private string name;

        public string Introduce
        {
            set { name = value; }
            get { return "Hi i am " + name; }
        }
    }
}