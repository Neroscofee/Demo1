using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Sort s = new Sort();
            int[] array = { 3, 7, 4, 8, 1, 2, 9 };
            //var t1 = Sort.QuickSort(array, 0, array.Length - 1);
            var t2 = s.BubbleSort(array);
            int a = s.SimpleCut(38);
            
        }

        void BubbleSort()
        {

        }
    }
}
