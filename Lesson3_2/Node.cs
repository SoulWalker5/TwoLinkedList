using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_2
{
    public class Node<T>
    {
        public Node(T element, Node<T> nextElement)
        {
            Element = element;
            NextElement = nextElement;
        }
        public T Element { get; set; }
        public Node<T> NextElement { get; set; }
    }
}
