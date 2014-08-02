namespace DataStructures.Nodes
{
    public class BaseDoublyLinkedListNode<TNode, TValue> : BaseLinkedListNode<TNode, TValue>
        where TNode : BaseDoublyLinkedListNode<TNode, TValue>, new()
    {
        public BaseDoublyLinkedListNode<TNode, TValue> Prev { get; set; }

        public override TNode AddNext(TValue value)
        {
            var next = base.AddNext(value);
            next.Prev = this;

            return next;
        }

        public BaseDoublyLinkedListNode<TNode, TValue> AddPrev(TValue value)
        {
            Prev = new TNode { Prev = Prev, Next = (TNode) this };
            return Prev;
        }
    }
}