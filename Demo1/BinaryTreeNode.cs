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
        public BinaryTreeNode<T> CreateAndJoinRight(string name, T data = default(T))
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
            if (Right != null)
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
            BinaryTreeNode<T> node = this;//得到根节点
            while (node != null || stack.Count != 0)//根节点不为空或者栈里有值（不为0）
            {
                while (node != null)//当根节点不为空时
                {
                    Trace.WriteLine(node.Name);//输出根节点的值
                    stack.Push(node);//把根节点压进栈内
                    node = node.Left;//把左子节点赋值成新的根节点
                }
                if (stack.Count != 0)//如果栈里有值（Count不为0）
                {
                    node = stack.Pop();//弹栈，由于栈是先进后出，所以就返回上一根节点,把栈顶的值赋值成新的根节点
                    node = node.Right;//再把上一根节点的右子节点赋值成新的根节点
                }
            }
        }
        /// <summary>
        /// 中序遍历
        /// </summary>
        public void InOrderTraversal()
        {
            if (Left != null)
            {
                Left.InOrderTraversal();
            }
            if (this != null)
            {
                Trace.WriteLine(Name);
            }
            if (Right != null)
            {
                Right.InOrderTraversal();
            }
        }
        /// <summary>
        /// 中序遍历 非递归
        /// </summary>
        public void InOrderTraversalEx()
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> node = this;
            while (node != null || stack.Count != 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                if (stack.Count != 0)
                {
                    //node = stack.Peek();//返回栈顶的对象但不移除
                    //stack.Pop();
                    node = stack.Pop();
                    Trace.WriteLine(node.Name);
                    node = node.Right;
                }
            }
        }
        /// <summary>
        /// 后序遍历
        /// </summary>
        public void PostOrderTraversal()
        {
            if (Left != null)
            {
                Left.PostOrderTraversal();
            }
            if (Right != null)
            {
                Right.PostOrderTraversal();
            }
            if (this != null)
            {
                Trace.WriteLine(Name);
            }
        }
        /// <summary>
        /// 后序遍历 非递归
        /// </summary>
        public void PostOrderTraversalEx()
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> node = this;
            BinaryTreeNode<T> lastNode = null;
            stack.Push(node);
            while (stack.Count != 0)
            {
                node = stack.Peek();
                if ((node.Left == null && node.Right == null) || (lastNode != null && (lastNode == node.Left || lastNode == node.Right)))
                {
                    //如果当前节点没有子节点或者子节点都已被访问过就输出 因为后序遍历是先子节点再根节点
                    Trace.WriteLine(node.Name);
                    stack.Pop();
                    lastNode = node;//设定本次访问的节点为上一次访问的节点
                }
                else
                {
                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }
                    if (node.Left != null)
                    {
                        stack.Push(node.Left);
                    }
                }
            }
        }
        /// <summary>
        /// 逐层遍历
        /// </summary>
        public void Traversal()
        {
            if (this == null)
            {
                return;
            }
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(this);
            while (queue.Any())//如果队列里有值
            {
                BinaryTreeNode<T> node = queue.Dequeue();//队列是先进先出，所以这里移除并返回队列最前端的元素
                Trace.WriteLine(node.Name);
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }
        /// <summary>
        /// 逐层遍历 非递归
        /// </summary>
        public void TraversalEx()
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(this);
            while (stack.Count > 0)
            {
                BinaryTreeNode<T> temp = stack.Peek();
                Trace.WriteLine(temp.Name);
                temp = stack.Pop();
                if (temp.Left !=null)
                {
                    stack.Push(temp.Left);
                }
                if (temp.Right != null)
                {
                    stack.Push(temp.Right);
                }
            }
        }
        /// <summary>
        /// 反转二叉树 递归
        /// </summary>
        /// <returns></returns>
        public BinaryTreeNode<T> ReverseWithRecursive()
        {
            if (this == null)
            {
                return null;
            }
            if (!(Left == null && Right == null))
            {
                BinaryTreeNode<T> temp = Right;//左右节点反转
                Right = Left;
                Left = temp;
                if (Left != null)
                {
                    Left = Left.ReverseWithRecursive();//递归反转左子节点
                }
                if (Right != null)
                {
                    Right = Right.ReverseWithRecursive();
                }
            }
            return this;
        }
        /// <summary>
        /// 反转二叉树 非递归
        /// 思路：定义一个队列来临时存储即将反转的节点，获取队列中存储的节点，
        /// 获取到一个节点后队列中的此节点已无用将其删除，然后把获取到的节点的左右子节点反转，
        /// 将反转后的左右子节点都放入队列用于下一次循环，重复执行直到反转完所有树节点
        /// </summary>
        /// <returns></returns>
        public BinaryTreeNode<T> Reverse()
        {
            if (this == null)
            {
                return null;
            }
            Queue<BinaryTreeNode<T>> nodeQueue = new Queue<BinaryTreeNode<T>>();
            nodeQueue.Enqueue(this);
            while (nodeQueue.Count > 0)
            {
                BinaryTreeNode<T> node = nodeQueue.Peek();
                nodeQueue.Dequeue();
                BinaryTreeNode<T> tempeNode = node.Right;
                node.Right = node.Left;
                node.Left = tempeNode;
                if (node.Left != null)
                {
                    nodeQueue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    nodeQueue.Enqueue(node.Right);
                }
            }
            return this;
        }
        /// <summary>
        /// 反转二叉树 非递归 栈
        /// </summary>
        /// <returns></returns>
        public BinaryTreeNode<T> ReverseEx()
        {
            if (this == null)
            {
                return null;
            }
            Stack<BinaryTreeNode<T>> nodeStack = new Stack<BinaryTreeNode<T>>();
            nodeStack.Push(this);
            while (nodeStack.Count > 0)
            {
                BinaryTreeNode<T> node = nodeStack.Peek();
                nodeStack.Pop();
                BinaryTreeNode<T> tempNode = node.Right;
                node.Right = node.Left;
                node.Left = tempNode;
                if (node.Left != null)
                {
                    nodeStack.Push(node.Left);
                }
                if (node.Right != null)
                {
                    nodeStack.Push(node.Right);
                }
            }
            return this;
        }


    }





}
