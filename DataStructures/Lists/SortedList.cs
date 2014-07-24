using System;
using System.Collections.Generic;

namespace DataStructures.Lists
{
    public class SortedList<T> : BaseLinkedList<T>
        where T: IComparable
    {
        public override void Add(T value)
        {
            Count++;

            if (Head == null)
            {
                Head = new Nodes.LinkedListNode<T>(value);
                Tail = Head;
                return;
            }

            if (Head.Value.CompareTo(value) > 0)
            {
                var newRoot = new Nodes.LinkedListNode<T>(value, Head);
                Head = newRoot;

                return;
            }

            if (Tail.Value.CompareTo(value) < 0)
            {
                var newTail = new Nodes.LinkedListNode<T>(value);
                Tail.Next = newTail;
                Tail = newTail;

                return;
            }

            var current = GetNode(n => n.Next != null && n.Next.Value.CompareTo(value) > 0);
            current.Next = new Nodes.LinkedListNode<T>(value, current.Next);
        }

        public IEnumerable<T> GetUnique()
        {
            var lastUniqueValue = default (T);
            var isStarted = false;

            var current = Head;
            while (current != null)
            {
                if (isStarted)
                {
                    if (!lastUniqueValue.Equals(current.Value))
                    {
                        lastUniqueValue = current.Value;
                        yield return lastUniqueValue;
                    }
                }
                else
                {
                    isStarted = true;
                    lastUniqueValue = current.Value;
                    yield return lastUniqueValue;
                }

                current = current.Next;
            }
        }
    }
}
