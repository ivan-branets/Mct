using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Nodes;

namespace DataStructures
{
    public class Bst<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        private BstNode<T> Root { get; set; }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new BstNode<T>(value);
                return;
            }


            BstNode<T> node, lastNode;

            if (Find(Root, value, out node, out lastNode))
            {
                node.Right = new BstNode<T>(value) { Right = node.Right };
                return;
            }

            if (value.CompareTo(lastNode.Value) < 0)
            {
                lastNode.Left = new BstNode<T>(value);
            }
            else
            {
                lastNode.Right = new BstNode<T>(value);
            }
        }

        public bool AddUnique(T value)
        {
            if (Root == null)
            {
                Root = new BstNode<T>(value);
                return true;
            }

            BstNode<T> node, lastNode;

            if (Find(Root, value, out node, out lastNode)) return false;

            if (value.CompareTo(lastNode.Value) < 0)
            {
                lastNode.Left = new BstNode<T>(value);
            }
            else
            {
                lastNode.Right = new BstNode<T>(value);
            }

            return true;
        }

        public bool Contains(T value)
        {
            if (Root == null) return false;

            BstNode<T> node, lastNode;
            return Find(Root, value, out node, out lastNode);
        }

        private bool Find(BstNode<T> current, T value, out BstNode<T> node, out BstNode<T> lastNode)
        {
            var cmp = value.CompareTo(current.Value);
            if (cmp == 0)
            {
                node = current;
                lastNode = null;

                return true;
            }

            if ((cmp < 0 && current.Left == null) || (cmp > 0 && current.Right == null))
            {
                node = null;
                lastNode = current;

                return false;
            }

            return cmp < 0
                ? Find(current.Left, value, out node, out lastNode)
                : Find(current.Right, value, out node, out lastNode);
        }

        public int Depth()
        {
            return Depth(Root);
        }

        private int Depth(BstNode<T> node)
        {
            if (node == null) return 0;

            var leftDepth = Depth(node.Left);
            var rightDepth = Depth(node.Right);

            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;
        }

        public void TraversalPreOrder(Action<BstNode<T>> action)
        {
            TraversalPreOrder(Root, action);
        }

        private void TraversalPreOrder(BstNode<T> node, Action<BstNode<T>> action)
        {
            if (node == null) return;

            action(node);
            TraversalPreOrder(node.Left, action);
            TraversalPreOrder(node.Right, action);
        }

        public void TraversalInOrder(Action<BstNode<T>> action)
        {
            TraversalInOrder(Root, action);
        }

        private void TraversalInOrder(BstNode<T> node, Action<BstNode<T>> action)
        {
            if (node == null) return;

            TraversalInOrder(node.Left, action);
            action(node);
            TraversalInOrder(node.Right, action);
        }

        public void TraversalPostOrder(Action<BstNode<T>> action)
        {
            TraversalPostOrder(Root, action);
        }

        private void TraversalPostOrder(BstNode<T> node, Action<BstNode<T>> action)
        {
            if (node == null) return;

            TraversalPostOrder(node.Left, action);
            TraversalPostOrder(node.Right, action);
            action(node);
        }

        public IEnumerable<T> EnumeratePreOrder()
        {
            return Enumerate(TraversalPreOrder);
        }

        public IEnumerable<T> EnumerateInOrder()
        {
            return Enumerate(TraversalInOrder);
        }

        public IEnumerable<T> EnumeratePostOrder()
        {
            return Enumerate(TraversalPostOrder);
        }

        private IEnumerable<T> Enumerate(Action<Action<BstNode<T>>> enumerate)
        {
            if (Root == null) return Enumerable.Empty<T>();

            var list = new Lists.LinkedList<T>();
            enumerate(node => list.Add(node.Value));

            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return EnumeratePreOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}