using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_2
{
    public class TwoLinkedListCustomList<T> : CustomList<T> where T : class
    {
        public new void Add(T value)
        {
            TwoLinkedNode<T> node = new TwoLinkedNode<T>(value, null, null);

            if (Head == null)
            {
                base.Add(value);
            }
            else if (Head.NextElement == null)
            {
                Tail.PreviousElement = null;
                Tail.NextElement = node;
                Tail = (TwoLinkedNode<T>)node;
                Tail.PreviousElement = Head;
            }
            else
            {
                Tail.NextElement = node;
                Head.PreviousElement = Tail;
                Tail = (TwoLinkedNode<T>)node;
                Tail.PreviousElement = Head.PreviousElement;
                Head.PreviousElement = null;
            }
        }
        public override void Delete(T value)
        {
            TwoLinkedNode<T> previousfirst = null;
            TwoLinkedNode<T> first = Head;
            TwoLinkedNode<T> last = Tail;
            TwoLinkedNode<T> previouslast = null;

            while (first != null || last != null)
            {
                if (first.Element.Equals(value))
                {
                    if (previousfirst != null)
                    {
                        previousfirst.NextElement = first.NextElement;
                        {
                            if (first.NextElement == null)
                            {
                                Tail = previousfirst;
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
                if (last.Element.Equals(value))
                {
                    if (previouslast != null)
                    {
                        previouslast.PreviousElement = last.PreviousElement;
                        {
                            if (last.PreviousElement == null)
                            {
                                Tail = previouslast;
                            }
                        }
                    }
                    else
                    {
                        Tail = (TwoLinkedNode<T>)Tail.PreviousElement;
                        if (Tail == null)
                        {
                            Head = null;
                        }
                    }
                }
                previouslast = last;
                last = (TwoLinkedNode<T>)last.PreviousElement;
                previousfirst = first;
                first = (TwoLinkedNode<T>)first.NextElement;
            }
        }
        public new IEnumerator<T> GetEnumerator()
        {
            return new TwoLinkedListCustomListIEnumerator<T>(Head);
        }
    }
}
