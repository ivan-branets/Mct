using System;
using DataStructures.Nodes;

namespace DataStructures.Lists
{
    public class SortedList<T> : LinkedList<T>
        where T: IComparable
    {
        public override void Add(T value)
        {
            if (Root == null)
            {
                Root = new LinkedListNode<T>(value);
                return;
            }

            if (Root.Value.CompareTo(value) > 0)
            {
                var newRoot = new LinkedListNode<T>(value, Root);
                Root = newRoot;

                return;
            }

            LinkedListNode<T> current;
            for (current = Root; current.Next != null && current.Next.Value.CompareTo(value) < 0; current = current.Next) ;

            current.Next = new LinkedListNode<T>(value, current.Next);
        }
    }
}
