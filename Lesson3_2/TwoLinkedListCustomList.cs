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
            Node<T> node;
            SomeMethod(value , out node);
            if (Head == null)
                base.Add(value);
            else if (Head == Tail)
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
        protected override void SomeMethod(T value, out Node<T> node)
        {
            node = new TwoLinkedNode<T>(value, null, null);
        }

        public override void Delete(T value)
        {
            Node<T> last = Tail;
            Node<T> previouslast = null;
            base.Delete(value);
            while (last != null)
            {
                if (last.Element.Equals(value))
                {
                    if (previouslast != null)
                    {
                        ((TwoLinkedNode<T>)previouslast).PreviousElement = ((TwoLinkedNode<T>)last).PreviousElement;
                        {
                            if (((TwoLinkedNode<T>)last).PreviousElement == null)
                            {
                                Tail = previouslast;
                            }
                        }
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
                last = ((TwoLinkedNode<T>)last).PreviousElement;
            }
        }
        public new IEnumerator<T> GetEnumerator()
        {
            return new TwoLinkedListCustomListIEnumerator<T>((TwoLinkedNode<T>)Head);
        }
    }
}
