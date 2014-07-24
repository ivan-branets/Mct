using System;
using DataStructures.Nodes;

namespace DataStructures.Lists
{
    public class LinkedList<T> : BaseLinkedList<T>
    {
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            Count--;

            if (Count == 1)
            {
                Clear();
            }
            else if (index == Count - 1)
            {
                var current = GetNodeAt(Count - 2);
                current.Next = null;
                Tail = current;
            }
            else
            {
                var current = GetNodeAt(index - 1);
                current.Next = current.Next.Next;
            }
        }

        public void Insert(T value, int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            Count++;

            if (index == Count - 1)
            {
                Add(value);
            }
            else if (index == 0)
            {
                Head = new LinkedListNode<T>(value, Head);
            }
            else
            {
                var current = GetNodeAt(index - 1);
                current.Next = new LinkedListNode<T>(value, current.Next);                
            }
        }
    }
}
