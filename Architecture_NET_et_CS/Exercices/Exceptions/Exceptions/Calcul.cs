using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class Calcul
    {
    

        public int Calc(int a, int b)
        {
            if (a > 0)
            {
                throw new ArgumentException("L'argument a n'est pas valide, il doit etre positif");
            }
            if (a < 0 && b > 0)
            {
                throw new MyException("a >0 et b <0 recquis", a, b);
            }
            return a + b;
        }
    }
}
