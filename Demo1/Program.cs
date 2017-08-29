using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Demo1
{
    class Program

    {
        static void Main(string[] args)
        {
            Person xm, xn;
            xm = new Person();
            xm.Value = 6;
            xn = xm;
            Console.WriteLine(xn.Value);
            xn.Value = 9;
            Console.WriteLine(xm.Value);

            Console.WriteLine(xm.Add(4, 7));
            Console.ReadKey();
        }
    }
}
