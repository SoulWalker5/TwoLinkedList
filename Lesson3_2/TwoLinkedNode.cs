using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_2
{
    public class TwoLinkedNode<T> : Node<T>
    {
        public TwoLinkedNode<T> PreviousElement { get; set; }
        public TwoLinkedNode(T element, TwoLinkedNode<T> nextElement, TwoLinkedNode<T> previousElement) : base(element, nextElement)
        {
            PreviousElement = previousElement;
        }
    }
}
