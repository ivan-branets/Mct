namespace DataStructures.Nodes
{
    public class Node<T>
    {
        public Node()
        {
        }

        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}
