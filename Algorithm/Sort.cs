﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Sort
    {
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

    }
}