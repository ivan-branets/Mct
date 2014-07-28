using System;
using DataStructures.Nodes;

namespace DataStructures.Lists
{
    public class LinkedList<T> : BaseLinkedList<T>
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
    }
}
