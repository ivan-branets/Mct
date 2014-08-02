using System;
using DataStructures.Nodes;

namespace DataStructures.Lists
{
    public class LinkedList<T> : BaseLinkedList<LinkedListNode<T>,  T>
    {
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            if (Count == 1)
            {
                Clear();
            }
            else if (index == 0)
            {
                Head = Head.Next;
                Count--;
            }
            else if (index == Count - 1)
            {
                var current = GetNodeAt(Count - 2);
                current.Next = null;
                Tail = current;

                Count--;
            }
            else
            {
                var current = GetNodeAt(index - 1);
                current.Next = current.Next.Next;

                Count--;
            }
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();

            if (index == Count)
            {
                Add(value);
            }
            else if (index == 0)
            {
                Head = new LinkedListNode<T>(value, Head);
                Count++;
            }
            else
            {
                Count++;
                var current = GetNodeAt(index - 1);
                current.Next = new LinkedListNode<T>(value, current.Next);                
            }
        }

        public virtual void Reverse()
        {
            if (Head == null) return;

            var current = Head;
            var next = current.Next;
            current.Next = null;

            while (next != null)
            {
                var prevNext = next.Next;
                next.Next = current;
                current = next;
                next = prevNext;
            }

            Tail = Head;
            Head = current;
        }

        public void AddLoop(T value)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    Tail.Next = current;
                    return;
                }
                current = current.Next;
            }
        }

        public bool HasLoop()
        {
            var initialHead = Head;
            Reverse();

            return initialHead == Head;
        }
    }
}
