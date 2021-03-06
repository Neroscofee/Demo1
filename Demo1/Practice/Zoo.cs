﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo1.Practice
{
    class Zoo
    {
        //public void Show(Dog dog)
        //{
        //    dog.LikeFood();
        //}
        //public void Show(Cat cat)
        //{
        //    cat.LikeFood();
        //}
        //public void Show(Monkey monkey)
        //{
        //    monkey.LikeFood();
        //}
        public void Show(Animal animal)
        {
            animal.LikeFood();
        }

        public void QuickSort(int[] a, int left, int right)
        {
            if (left > right)
            {
                return;
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
        }
    }
}
