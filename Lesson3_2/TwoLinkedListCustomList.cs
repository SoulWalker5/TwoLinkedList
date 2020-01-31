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
            base.Add(value);
        }
        protected override Node<T> AssignmentNode(T value)
        {
            return new TwoLinkedNode<T>(value, null, null);
        }
        protected override void SetTail(Node<T> node)
        {
            base.SetTail(node);
            ((TwoLinkedNode<T>)node).PreviousElement = (TwoLinkedNode<T>)base.Tail;
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
                        ((TwoLinkedNode<T>)Head).PreviousElement = (((TwoLinkedNode<T>)Head).PreviousElement).PreviousElement;
                        if (Head == null)
                        {
                            Tail = null;
                        }
                        return;
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
                        ((TwoLinkedNode<T>)Tail).NextElement = Tail.NextElement.NextElement;
                        if (Tail == null)
                        {
                            Head = null;
                        }
                        return;
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
