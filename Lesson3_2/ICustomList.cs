using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_2
{
    public interface ICustomList<T>
    {
        void Add(T value);
        T this[int index] { get; }
        void Delete(T value);
    }
}
