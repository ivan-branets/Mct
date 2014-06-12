using System;

namespace DataStructures.Nodes
{
    class BsdNode<T> : Node<T>
        where T : IComparable<T>
    {
        public BsdNode()
        {
        }

        public BsdNode(T value)
            : base(value)
        {
        }

        public BsdNode<T> Left { get; set; }
        public BsdNode<T> Right { get; set; }

        public bool Add(T value)
        {
            BsdNode<T> node, lastNode;

            if (Find(value, out node, out lastNode)) return false;

            if (value.CompareTo(lastNode.Value) < 0)
            {
                lastNode.Left = new BsdNode<T>(value);
            }
            else
            {
                lastNode.Right = new BsdNode<T>(value);
            }

            return true;
        }

        public bool Find(T value, out BsdNode<T> node, out BsdNode<T> lastNode)
        {
            var cmp = value.CompareTo(Value);
            if (cmp == 0)
            {
                node = this;
                lastNode = null;

                return true;
            }

            return cmp < 0
                ? ProccessChild(Left, value, out node, out lastNode)
                : ProccessChild(Right, value, out node, out lastNode);
        }

        private bool ProccessChild(BsdNode<T> child, T value, out BsdNode<T> node, out BsdNode<T> lastNode)
        {
            if (child == null)
            {
                node = null;
                lastNode = this;

                return false;
            }

            return child.Find(value, out node, out lastNode);
        }
    }
}
