namespace DataStructures.Nodes
{
    public class BaseLinkedListNode<TNode, TValue> : Node<TValue>
        where TNode: BaseLinkedListNode<TNode, TValue>, new()
    {
        public BaseLinkedListNode()
        {
        }

        public BaseLinkedListNode(TValue value)
            : base(value)
        {
        }

        public BaseLinkedListNode(TValue value, TNode next)
            : base(value)
        {
            Next = next;
        }

        public TNode Next { get; internal set; }

        public virtual TNode AddNext(TValue value)
        {
            Next = new TNode { Value = value, Next = Next };
            return Next;
        }
    }
}
