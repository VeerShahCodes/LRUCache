using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCacheClass
{
    public class DoublyLinkedList<T>
    {
        public int Count { get; private set; } = 0;
        public DoubleLinkedListNode<T>? Head;
        public DoubleLinkedListNode<T> Tail { 
           get
           {
                return Head.Previous;
           }
        }



        public void AddFirst(T item)
        {
            if (Head == null)
            {
                Head = new DoubleLinkedListNode<T>(item);
                Head.Previous = Head;

            }
            else
            {
                DoubleLinkedListNode<T> nodeToInsert = new DoubleLinkedListNode<T>(item);
                nodeToInsert.Next = Head;
                nodeToInsert.Previous = Head.Previous;
                Head.Previous = nodeToInsert;
                Head = nodeToInsert;


            }
            Count++;
        }

        public void AddLast(T item)
        {
            if (Head.Previous == null)
            {
                Head = new DoubleLinkedListNode<T>(item);
                Head.Previous = Head;


            }
            else
            {
                DoubleLinkedListNode<T> nodeToInsert = new DoubleLinkedListNode<T>(item);
                Head.Previous.Next = nodeToInsert;
                nodeToInsert.Previous = Head.Previous;

                Head.Previous = nodeToInsert;
                Head.Previous.Next = Head;

            }
            Count++;
        }

        public DoubleLinkedListNode<T> LookFor(T valueToLookFor)
        {
            DoubleLinkedListNode<T> currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(valueToLookFor))
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }
            return null;
        }
        public void AddAfter(T valueToAddAfter, T valueToAdd)
        {
            if (Head == null)
            {
                AddFirst(valueToAdd);
                return;
            }

            DoubleLinkedListNode<T> nodeToInsert = new DoubleLinkedListNode<T>(valueToAdd);

            DoubleLinkedListNode<T> nodeToAddAfter = LookFor(valueToAddAfter);

            if (Head.Previous == nodeToAddAfter)
            {
                AddLast(valueToAdd);
                return;
            }

            if (nodeToAddAfter != null)
            {
                nodeToInsert.Next = nodeToAddAfter.Next;
                nodeToAddAfter.Next.Previous = nodeToInsert;
                nodeToAddAfter.Next = nodeToInsert;
                nodeToInsert.Previous = nodeToAddAfter;

                Count++;

            }

        }

        public void AddBefore(T valueToAddBefore, T valueToAdd)
        {
            if (Head == null)
            {
                AddFirst(valueToAdd);
                return;
            }

            DoubleLinkedListNode<T> nodeToInsert = new DoubleLinkedListNode<T>(valueToAdd);
            DoubleLinkedListNode<T> nodeToAddBefore = LookFor(valueToAddBefore);
            if (Head == nodeToAddBefore)
            {
                AddFirst(valueToAdd);
                return;
            }

            if (nodeToAddBefore != null)
            {
                nodeToInsert.Previous = nodeToAddBefore.Previous;
                nodeToAddBefore.Previous.Next = nodeToInsert;
                nodeToAddBefore.Previous = nodeToInsert;
                nodeToInsert.Next = nodeToAddBefore;

                Count++;
            }

        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                return;
            }

            Head.Next.Previous = Head.Previous;
            Head = Head.Next;

            Count--;
        }

        public void RemoveLast()
        {
            if (Head.Previous == null)
            {
                return;
            }
            Head.Previous.Previous.Next = Head;
            Head.Previous = Head.Previous.Previous;
            Count--;
        }

        public void Remove(T valueToRemove)
        {
            if (Head == null)
            {
                return;
            }

            DoubleLinkedListNode<T> nodeToRemove = LookFor(valueToRemove);
            if (nodeToRemove == null)
            {
                return;
            }

            if (Head.Previous == nodeToRemove)
            {
                RemoveLast();
                return;
            }
            else if (Head == nodeToRemove)
            {
                RemoveFirst();
                return;
            }

            nodeToRemove.Previous.Next = nodeToRemove.Next;
            nodeToRemove.Next.Previous = nodeToRemove.Previous;
            Count--;
        }

        public void WriteList()
        {
            DoubleLinkedListNode<T> current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
                if (current == Head)
                {
                    break;
                }
            }
        }


    }


}
