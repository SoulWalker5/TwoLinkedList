using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_2
{
    class TwoLinkedListCustomListIEnumerator<T> : IEnumerator<T>
    {
        private TwoLinkedNode<T> Head;
        private TwoLinkedNode<T> CurrentNode;
        public TwoLinkedListCustomListIEnumerator(TwoLinkedNode<T> head)
        {
            Head = head;
            CurrentNode = null;
        }
        public T Current => Head.Element;
        object IEnumerator.Current => Head.Element;
        public void Dispose()
        { }
        public bool MoveNext()
        {
            if (CurrentNode == null)
            {
                CurrentNode = Head;
                return true;
            }
            else if (Head.Element != null && Head.NextElement != null)
            {
                Head = (TwoLinkedNode<T>)Head.NextElement;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            Head = null;
        }
    }
}
