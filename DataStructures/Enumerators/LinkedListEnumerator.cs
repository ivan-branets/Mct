using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Enumerators
{
    class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly Lists.LinkedList<T> _list;
        private Nodes.LinkedListNode<T> CurrentNode { get; set; }

        public LinkedListEnumerator(Lists.LinkedList<T> list)
        {
            _list = list;
        }

        public T Current
        {
            get { return CurrentNode.Value; }
        }

        public bool MoveNext()
        {
            CurrentNode = CurrentNode == null ? _list.Root : CurrentNode.Next;
            return CurrentNode != null;
        }

        public void Reset()
        {
            CurrentNode = _list.Root;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            CurrentNode = null;
        }
    }
}
