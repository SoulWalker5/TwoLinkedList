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
        public override void Add(T value)
        {
            Node<T> node = AssignmentNode(value);

            if (Head == null)
                base.Add(value);
            else if (Head.NextElement == null)
            {
                ((TwoLinkedNode<T>)Tail).PreviousElement = null;
                Tail.NextElement = node;
                Tail = (TwoLinkedNode<T>)node;
                ((TwoLinkedNode<T>)Tail).PreviousElement = (TwoLinkedNode<T>)Head;
            }
            else
            {
                Tail.NextElement = node;
                ((TwoLinkedNode<T>)Head).PreviousElement = (TwoLinkedNode<T>)Tail;
                Tail = (TwoLinkedNode<T>)node;
                ((TwoLinkedNode<T>)Tail).PreviousElement = ((TwoLinkedNode<T>)Head).PreviousElement;
                ((TwoLinkedNode<T>)Head).PreviousElement = null;
            }
        }
        protected override Node<T> AssignmentNode(T value)
        {
            return new TwoLinkedNode<T>(value, null, null);
        }
        public override void Delete(T value)
        {
            TwoLinkedNode<T> previousfirst = null;
            TwoLinkedNode<T> first = (TwoLinkedNode<T>)Head;
            TwoLinkedNode<T> last = (TwoLinkedNode<T>)Tail;
            TwoLinkedNode<T> previouslast = null;
            while (first != null || last != null)
            {
                if (first.Element.Equals(value))
                {
                    if (previousfirst != null)
                    {
                        previousfirst.NextElement = first.NextElement;
                        last = first;
                        last.PreviousElement = (TwoLinkedNode<T>)last.NextElement;
                        {
                            if (first.NextElement == null)
                            {
                                Tail = first;
                            }
                        }
                        return;
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
                        first = last;
                        first.PreviousElement = (TwoLinkedNode<T>)first.NextElement;
                        {
                            if (last.PreviousElement == null)
                            {
                                Tail = previouslast;
                            }
                        }
                        return;
                    }
                    else
                    {
                        Tail = ((TwoLinkedNode<T>)Tail).PreviousElement;
                        if (Tail == null)
                        {
                            Head = null;
                        }
                    }
                }
                previouslast = last;
                last = last.PreviousElement;
                previousfirst = first;
                first = (TwoLinkedNode<T>)first.NextElement;
            }
        }
        public new IEnumerator<T> GetEnumerator()
        {
            return new TwoLinkedListCustomListIEnumerator<T>((TwoLinkedNode<T>)Head);
        }
    }
}
