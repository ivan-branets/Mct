using System;
using DataStructures.Nodes;

namespace DataStructures
{
    public class Bsd<T> where T: IComparable<T>
    {
        private BsdNode<T> Root { get; set; }

        public bool Add(T value)
        {
            if (Root == null)
            {
                Root = new BsdNode<T>(value);
                return true;
            }
            return Root.Add(value);
        }

        public bool Contains(T value)
        {
            if (Root == null) return false;

            BsdNode<T> node, lastNode;
            return Root.Find(value, out node, out lastNode);
        }
    }
}
