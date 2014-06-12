using System.Collections;
using System.Collections.Generic;
using DataStructures.Enumerators;

namespace DataStructures.Lists
{
    public class LinkedList<T> : IEnumerable<T>
    {
        internal Nodes.LinkedListNode<T> Root { get; set; }
        private Nodes.LinkedListNode<T> Last { get; set; }

        public virtual void Add(T value)
        {
            if (Root == null)
            {
                Root = new Nodes.LinkedListNode<T>(value);
                Last = Root;
            }
            else
            {
                Last = Last.AddNext(value);
            }
        }

        public virtual void Reverse()
        {
            if (Root == null) return;

            var current = Root;
            var next = current.Next;
            current.Next = null;

            while (next != null)
            {
                var prevNext = next.Next;
                next.Next = current;
                current = next;
                next = prevNext;
            }

            Root = current;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }
    }
}
