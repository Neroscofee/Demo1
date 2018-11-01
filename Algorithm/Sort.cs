using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
   
    public class Sort
    {
        private string name;
        private string newclass;
        public string Name { get { return "xinyi"; } set { name = value; } }
        public string Class { set { newclass = value; } }


        public static int[] QuickSort(int[] a, int left, int right)
        {
            if (left > right)
            {
                return a;
            }
            int i = left;
            int j = right;
            int key = a[left];
            while (i < j)
            {
                while (i < j && key <= a[j])
                {
                    j--;
                }
                a[i] = a[j];
                while (i < j && key >= a[i])
                {
                    i++;
                }
                a[j] = a[i];
            }
            a[i] = key;
            QuickSort(a, left, i - 1);
            QuickSort(a, i + 1, right);
            return a;
        }

        public int[] BubbleSort(int[] a)
        {
            int temp = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - 1 - i; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
            return a;
        }

        public int SimpleCut(int a)
        {
            if (a / 10 == 0)
            {
                return a;
            }
            int sum = 0;
            while (a > 0)
            {
                sum = sum + a % 10;
                a = a / 10;
            }
            if (sum / 10 > 0)
            {
                sum = SimpleCut(sum);
            }
            return sum;
        }


    }
}
