using System;
using System.Collections;

namespace Lesson3_2
{
    public class CustomList<T> : IEnumerable, ICustomList<T>
    {
        public TwoLinkedNode<T> Head { get; set; }
        public TwoLinkedNode<T> Tail { get; set; }
        public T this[int index]
        {
            get
            {
                Node<T> current = Head;
                int i = 0;

                while (current != null && i != index)
                {
                    current = current.NextElement;
                    i++;
                }
                return current.Element;
            }
        }

        public void Add(T value)
        {
            TwoLinkedNode<T> node = new TwoLinkedNode<T>(value, null, null);
            if (Head == null)
            {
                Head = (TwoLinkedNode<T>)node;
                Tail = (TwoLinkedNode<T>)node;
            }
            else
            {
                Tail.NextElement = node;
                Tail = (TwoLinkedNode<T>)node;
            }
        }

        public virtual void Delete(T value)
        {
            TwoLinkedNode<T> previous = null;
            TwoLinkedNode<T> current = Head;

            while (current != null)
            {
                if (current.Element.Equals(value))
                {
                    if (previous != null)
                    {
                        previous.NextElement = current.NextElement;
                        {
                            if (current.NextElement == null)
                            {
                                Tail = (TwoLinkedNode<T>)previous;
                            }
                        }
                    }
                    else
                    {
                        Head = (TwoLinkedNode<T>)Head.NextElement;
                        if (Head == null)
                        {
                            Tail = null;
                        }
                    }
                }
                previous = current;
                current = (TwoLinkedNode<T>)current.NextElement;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new CustomListIEnumerator<T>(Head);
        }
    }
}
