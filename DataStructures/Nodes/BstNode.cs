using System;

namespace DataStructures.Nodes
{
    public class BstNode<T> : Node<T>
        where T : IComparable<T>
    {
        public BstNode()
        {
        }

        public BstNode(T value)
            : base(value)
        {
        }

        public BstNode<T> Left { get; set; }
        public BstNode<T> Right { get; set; }
    }
}
