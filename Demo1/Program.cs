using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine(xm.Multiply(5, 7));
            Console.ReadKey();

            BinaryTreeNode<int> tree = new BinaryTreeNode<int>("0");
            BinaryTreeNode<int> n01 = tree.CreateAndJoinLeft("01");
            BinaryTreeNode<int> n02 = tree.CreateAndJoinRight("02");
            BinaryTreeNode<int> n011 = n01.CreateAndJoinLeft("011");
            BinaryTreeNode<int> n012 = n01.CreateAndJoinRight("012");
            BinaryTreeNode<int> n021 = n02.CreateAndJoinLeft("021");
            BinaryTreeNode<int> n022 = n02.CreateAndJoinRight("022");
            BinaryTreeNode<int> n0111 = n011.CreateAndJoinRight("0111");
            BinaryTreeNode<int> n0222 = n022.CreateAndJoinLeft("0222");
            Trace.WriteLine("--前序--");
            tree.PreOrderTraversal();
            Trace.WriteLine("--前序--非递归--");
            tree.PreOrderTraversalEx();

            Trace.WriteLine("--中序--");
            tree.InOrderTraversal();
            Trace.WriteLine("--中序--非递归--");
            tree.InOrderTraversalEx();

            Trace.WriteLine("--后序--");
            tree.PostOrderTraversal();
            Trace.WriteLine("--后序--非递归--");
            tree.PostOrderTraversalEx();


            Trace.WriteLine("--逐层--队列--");
            tree.Traversal();

            Trace.WriteLine("--反转二叉树--");
            BinaryTreeNode<int> treeReverse = tree.ReverseEx();
            treeReverse.Traversal();

            //BinaryTreeNode<int> tree = new BinaryTreeNode<int>("0");//rootNode
            //BinaryTreeNode<int> n01 = tree.CreateAndJoinLeft("01");
            //BinaryTreeNode<int> n02 = tree.CreateAndJoinRight("02");
            //BinaryTreeNode<int> n011 = n01.CreateAndJoinLeft("011");
            //BinaryTreeNode<int> n012 = n01.CreateAndJoinRight("012");
            //BinaryTreeNode<int> n021 = n02.CreateAndJoinLeft("021");
            //BinaryTreeNode<int> n0211 = n021.CreateAndJoinLeft("0211");
            //BinaryTreeNode<int> n0212 = n021.CreateAndJoinRight("0212");

            ////遍历输出
            //tree.Traversal();


        }
    }
}
