using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo1
{
    class Person
    {
        public int Value;
        public int Add(int a,int b)
        {
            return a + b;
        }
        public int Subtract(int a,int b)
        {
            return a > b ? a - b : b - a;
        }
        public int Multiply(int a,int b)
        {
            return a * b;
        }
    }
}
