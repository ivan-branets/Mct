namespace DataStructures.Nodes
{
    public class LinkedListNode<T> : BaseLinkedListNode<LinkedListNode<T>, T>
    {
        public LinkedListNode()
        {
        }

        public LinkedListNode(T value)
            : base(value)
        {
        }

        public LinkedListNode(T value, LinkedListNode<T> next)
            : base(value, next)
        {
        }
    }
}
