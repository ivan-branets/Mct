using DataStructures.Nodes;

namespace DataStructures.Lists
{
    public class DoublyLinkedList<T> : BaseLinkedList<DoublyLinkedListNode<T>, T>
    {
        public override bool Remove(T value)
        {
            var removed = GetRemoved(value);

            if (removed == null) return false;

            if (removed.Next != null)
            {
                removed.Next.Prev = removed.Prev;                
            }

            return true;
        }
    }
}