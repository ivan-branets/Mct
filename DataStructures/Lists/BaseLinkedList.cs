using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Lists
{
    public abstract class BaseLinkedList<T> : ICollection<T>, ICollection
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

        public bool Contains(T value)
        {
            return GetNode(n => n.Value.Equals(value)) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var value in this)
            {
                array[arrayIndex++] = value;
            }
        }

        public void CopyTo(Array array, int arrayIndex)
        {
            foreach (var value in this)
            {
                array.SetValue(value, arrayIndex);
            }
        }

        public bool Remove(T value)
        {
            if (Head == null) return false;

            if (Head.Value.Equals(value))
            {
                Head = Head.Next;

                if (Head == null)
                {
                    Tail = null;
                }
            }

            var current = GetNode(n => n.Next != null && n.Next.Value.Equals(value));

            if (current != null)
            {
                if (current.Next == Tail)
                {
                    current.Next = null;
                    Tail = current;
                }
                else
                {
                    current.Next = current.Next.Next;                    
                }

                return true;
            }

            return false;
        }

        public int Count { get; protected set; }
        public object SyncRoot { get { return false; } }
        public bool IsSynchronized { get { return false; } }
        public bool IsReadOnly { get { return false; } }

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

        public T this[int index]
        {
            get
            {
                return GetNodeAt(index).Value;
            }
            set
            {
                GetNodeAt(index).Value = value;
            }
        }

        protected Nodes.LinkedListNode<T> GetNode(Func<Nodes.LinkedListNode<T>, bool> predicate)
        {
            var current = Head;
            while (current != null)
            {
                if (predicate(current)) return current;
                current = current.Next;
            }

            return null;
        }

        protected Nodes.LinkedListNode<T> GetNodeAt(int index)
        {
            if (Head == null) throw new InvalidOperationException("List doesn't contain elements");
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            var current = Head;

            for (var i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public T GetMiddle()
        {
            return this[Count / 2];
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
