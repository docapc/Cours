using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public static class CalculationExtention
    {
        public static int NouvelleMethodeDeCalcul(this Calcul calcul, int a, int b)
        {
            return a + b;
        }

        public static void MonJolieInt(this int a)
        {
            Console.WriteLine($"Je suis {a} et beau");
        }
    }
}
