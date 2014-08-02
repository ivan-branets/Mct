using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Nodes;

namespace DataStructures.Lists
{
    public abstract class BaseLinkedList<TNode, TValue> : ICollection<TValue>, ICollection
        where TNode: BaseLinkedListNode<TNode, TValue>, new()
    {
        protected TNode Head { get; set; }

        protected TNode Tail { get; set; }

        public virtual void Add(TValue value)
        {
            if (Head == null)
            {
                Head = new TNode { Value = value };
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

        public bool Contains(TValue value)
        {
            return GetNode(n => n.Value.Equals(value)) != null;
        }

        public void CopyTo(TValue[] array, int arrayIndex)
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

        public virtual bool Remove(TValue value)
        {
            return GetRemoved(value) != null;
        }

        protected TNode GetRemoved(TValue value)
        {
            if (Head == null) return null;

            TNode toBeRemoved = null;

            if (Head.Value.Equals(value))
            {
                toBeRemoved = Head;
                Head = Head.Next;

                if (Head == null)
                {
                    Tail = null;
                }

                Count--;
            }
            else
            {
                var current = GetNode(n => n.Next != null && n.Next.Value.Equals(value));

                if (current != null)
                {
                    toBeRemoved = current.Next;

                    if (toBeRemoved == Tail)
                    {
                        current.Next = null;
                        Tail = current;
                    }
                    else
                    {
                        current.Next = current.Next.Next;
                    }

                    Count--;
                }                
            }

            return toBeRemoved;
        }

        public int Count { get; protected set; }
        public object SyncRoot { get { return false; } }
        public bool IsSynchronized { get { return false; } }
        public bool IsReadOnly { get { return false; } }

        public TValue this[int index]
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

        protected TNode GetNode(Func<TNode, bool> predicate)
        {
            var current = Head;
            while (current != null)
            {
                if (predicate(current)) return current;
                current = current.Next;
            }

            return null;
        }

        protected TNode GetNodeAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            var current = Head;

            for (var i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public TValue GetMiddle()
        {
            return this[Count / 2];
        }

        public virtual IEnumerator<TValue> GetEnumerator()
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