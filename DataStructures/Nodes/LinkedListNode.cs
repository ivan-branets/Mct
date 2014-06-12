namespace DataStructures.Nodes
{
    class LinkedListNode<T> : Node<T>
    {
        public LinkedListNode()
        {
        }

        public LinkedListNode(T value)
            : base(value)
        {
        }

        public LinkedListNode(T value, LinkedListNode<T> next)
            : base(value)
        {
            Next = next;
        }

        public virtual LinkedListNode<T> Next { get; internal set; }

        public virtual LinkedListNode<T> AddNext(T value)
        {
            Next = new LinkedListNode<T>(value);
            return Next;
        }
    }
}
