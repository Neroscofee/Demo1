using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Demo1
{
    public class BinaryTreeNode<T>
    {
        public string Name { get; set; }
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        private bool _isLeaf;
        public bool IsLeaf
        {
            get
            {
                _isLeaf = (Left == null && Right == null);
                return _isLeaf;
            }
        }
        public BinaryTreeNode(string name, T data = default(T))
        {
            Name = name;
            Data = data;
        }
        public BinaryTreeNode<T> CreateAndJoinLeft(string name, T data = default(T))
        {
            return Left = new BinaryTreeNode<T>(name, data);
        }
        public BinaryTreeNode<T> CreateAndJoinRight(string name,T data = default(T))
        {
            return Right = new BinaryTreeNode<T>(name, data);
        }
        /// <summary>
        /// 前序遍历
        /// </summary>
        public void PreOrderTraversal()
        {
            if (this != null)
            {
                Trace.WriteLine(Name);
            }
            if (Left != null)
            {
                Left.PreOrderTraversal();
            }
            if (Right!=null)
            {
                Right.PreOrderTraversal();
            }
        }
        /// <summary>
        /// 前序遍历 非递归
        /// </summary>
        public void PreOrderTraversalEx()
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> node = this;
            while (node!=null || stack.Count != 0)
            {
                while (node!= null)
                {
                    Trace.WriteLine(node.Name);
                    stack.Push(node);
                    node = node.Left;
                }
                if (stack.Count !=0)
                {
                    node = stack.Pop();
                    node = node.Right;
                }
            }
        }
        /// <summary>
        /// 中序遍历
        /// </summary>
        public void InOrderTraversal()
        {
            if (Left!=null)
            {
                Left.InOrderTraversal();
            }
            if (this!=null)
            {
                Trace.WriteLine(Name);
            }
            if (Right!=null)
            {
                Right.InOrderTraversal();
            }
        }
        public void InOrderTraversalEx()
        {
            
        }

    }





}
