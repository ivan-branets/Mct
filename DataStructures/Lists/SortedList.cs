using System;
using DataStructures.Nodes;

namespace DataStructures.Lists
{
    public class SortedList<T> : LinkedList<T>
        where T: IComparable
    {
        public override void Add(T value)
        {
            if (Head == null)
            {
                Head = new LinkedListNode<T>(value);
                return;
            }

            if (Head.Value.CompareTo(value) > 0)
            {
                var newRoot = new LinkedListNode<T>(value, Head);
                Head = newRoot;

                return;
            }

            LinkedListNode<T> current;
            for (current = Head; current.Next != null && current.Next.Value.CompareTo(value) < 0; current = current.Next) ;

            current.Next = new LinkedListNode<T>(value, current.Next);
        }
    }
}
