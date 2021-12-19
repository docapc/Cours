using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesCSharp
{
    class ExerciceRefOutParDefaut
    {

        public void PrintRes(int a, ref int b, out string c, int d = 12, int e = 100)
        {
            a = 52;
            Console.WriteLine($"Dans classe : a = {a}");
            b = a + b;
            Console.WriteLine($"Dans classe : b = {b}");
            c = b.ToString()+" en string";
            Console.WriteLine($"Dans classe : c = {c}");
            Console.WriteLine($"Dans classe : d = {d}");
            Console.WriteLine($"Dans classe : e = {e}");
        }

    }
}
