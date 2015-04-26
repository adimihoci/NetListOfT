using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetListOfT
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> lista = new MyList<int>(100);
            MyList<int> new_list = new MyList<int>(100);
            Func<int, bool> match = x => x != 1;
            
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            lista.RemoveAt(1);

            Console.WriteLine(lista.Count());

            foreach (var VARIABLE in lista)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine(lista.Contains(3));

            new_list = lista.FindAll(match);

            foreach (var VARIABLE in new_list)
            {
                Console.WriteLine(VARIABLE);
            }

            new_list.Clear();

            foreach (var VARIABLE in new_list)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}
