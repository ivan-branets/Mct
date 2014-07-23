using System;
using DataStructures.Nodes;

namespace DataStructures.Lists
{
    public class SortedList<T> : LinkedList<T>
        where T: IComparable
    {
        public override void Add(T value)
        {
            Count++;

            if (Head == null)
            {
                Head = new LinkedListNode<T>(value);
                Tail = Head;
                return;
            }

            if (Head.Value.CompareTo(value) > 0)
            {
                var newRoot = new LinkedListNode<T>(value, Head);
                Head = newRoot;

                return;
            }

            if (Tail.Value.CompareTo(value) < 0)
            {
                var newTail = new LinkedListNode<T>(value);
                Tail.Next = newTail;
                Tail = newTail;

                return;
            }

            var current = Head;

            while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
            {
                current = current.Next;
            }

            current.Next = new LinkedListNode<T>(value, current.Next);
        }
    }
}
