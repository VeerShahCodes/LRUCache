using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCacheClass
{
    public class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode<T>? Previous { get; set; }
        public DoubleLinkedListNode<T>? Next { get; set; }
        public T Value { get; set; }
        public DoubleLinkedListNode(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

    }
}
