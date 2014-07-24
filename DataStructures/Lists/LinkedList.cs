using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Lists
{
    public class LinkedList<T> : ICollection<T>
    {
        protected Nodes.LinkedListNode<T> Head { get; set; }

        protected Nodes.LinkedListNode<T> Tail { get; set; }

        public virtual void Add(T value)
        {
            if (Head == null)
            {
                Head = new Nodes.LinkedListNode<T>(value);
                Tail = Head;
            }
            else
            {
                Tail = Tail.AddNext(value);
            }

            Count++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Enumerable.Contains(this, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var value in this)
            {
                array[arrayIndex++] = value;
            }
        }

        public bool Remove(T item)
        {
            if (Head == null) return false;

            var prev = Head;
            var current = prev.Next;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    prev.Next = current.Next;
                    Count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }

        public int Count { get; protected set; }

        public bool IsReadOnly
        {
            get { return false; }
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

        public T GetMiddle()
        {
            if (Head == null) throw new InvalidOperationException("List doesn't contain elements");

            var current = Head;

            for (var i = 0; i < Count / 2; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
