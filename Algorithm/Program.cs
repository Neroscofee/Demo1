using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //使用static修饰的方法可以不用实例化对象
            var t1 = Sort.QuickSort(array, 0, array.Length - 1);

            var t2 = s.BubbleSort(array);
            int a = s.SimpleCut(38);
            PlayCard(5);


            







        }

        void  BubbleSort()
        {

        }


        public static void PlayCard(int n)
        {
            //int[] arr = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    arr[i] = i+1;
            //}

            //12345
            //1234524
            //123456
            //123456246
            //135264
            //1

            List<int> arr = new List<int>();
            for (int i = 0; i < n; i++)
            {
                arr.Add(i + 1);
            }


            List<int> desk = new List<int>();
            List<int> cardstack = new List<int>();
            for (int i = 0; ; i++)
            {
                desk.Add(arr[0]);
                if (desk.Count == n)
                {
                    break;
                }
                cardstack.Add(arr[1]);
                arr.RemoveAt(0);
                arr.Add(cardstack[i]);
                arr.RemoveAt(0);

            }


            //13542 ===> 15243
            //temp:
            /*
           
            
            a[1]=1
            a[3]=2
            a[5]=3
            a[4]=4
            a[2]=5

            a[0]=1
            a[1]=3
            a[2]=5
            a[3]=4
            a[4]=2

            a[1]=1
            a[2]=3
            a[3]=5
            a[4]=4
            a[5]=2

            public static void anotherSwap(int[] arr){
        int[] swap=new int[arr.length];
        for(int i=0;i<arr.length;i++){
            swap[arr[i]]=i;

        }
        for(int i=0;i<swap.length;i++){
            System.out.print(swap[i]);
        }
        }

           13542 ===> 15243
             */

            List<int> temp = new List<int>();
            int[] origin = new int[desk.Count];

            Dictionary<int, int> dic = new Dictionary<int, int>();
            Dictionary<int, int> newDic = new Dictionary<int, int>();




            for (int i = 0; i < desk.Count; i++)
            {
                origin[desk[i] - 1] = i + 1;
                //temp.Insert(desk[i], i+1);
                dic.Add(i + 1, desk[i]);
                newDic.Add(desk[i], i + 1);

            }

            List<int> values = new List<int>();

            foreach (var item in dic)
            {

                int num1 = item.Key;
                int num2 = item.Value;
                //values.Add(num2);



            }

            for (int i = 0; i < newDic.Count; i++)
            {
                values.Add(newDic[i+1]);
            }




            int a = 1;

            for (int i = 0; i < origin.Count(); i++)
            {
                Trace.WriteLine(origin[i]);
                Console.WriteLine(origin[i]);

            }

            //Dictionary<int,int> 

            Console.ReadKey();


        }




    }
}
