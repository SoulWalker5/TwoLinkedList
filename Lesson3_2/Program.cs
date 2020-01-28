using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var igor = new Notebook(1, "Igor");
            var vasia = new Notebook(2, "vasia");
            var kurlik = new Notebook(3, "KYPJIbIK");
            var acer = new Notebook(2432, "Acer");
            var asus = new Notebook(4897, "Asus");

            var nc = new TwoLinkedListCustomList<Notebook>();

            nc.Add(igor);
            nc.Add(vasia);
            nc.Add(kurlik);
            nc.Add(acer);
            nc.Add(asus);
            foreach (var notebook in nc)
                Console.WriteLine("{0} {1}", notebook.Name, notebook.SerialNumber);

            nc.Delete(nc[1]);
            nc.Delete(nc[3]);

            Console.WriteLine();
            Console.WriteLine("===================");
            Console.WriteLine();

            foreach (Notebook notebook in nc)
                Console.WriteLine("{0} {1}", notebook.Name, notebook.SerialNumber);
            Console.ReadKey();
        }
    }
}