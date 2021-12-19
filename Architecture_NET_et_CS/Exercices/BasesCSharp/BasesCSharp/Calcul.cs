using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Sur out et ref // ref impose une initialisation d'une variable, ce qui n'est pas le out
namespace BasesCSharp
{
    class Calcul
    {
        public MonEnum Animal { get; set };
        public int CalculInt(int a, int b, out int c, ref int d)
        {
            a++;
            a = a + b;
            c = a + b;
            return a + b + c;
        }

        public (int, int, int) CalculInt2(int a, int b, out int c, ref int d)
        {
            a++;
            a = a + b;
            c = a + b;
            return (a,b,c); // Tuple pour retourner plusieur valeur (voir Tuple<int, int, int>)
        }

        //public Retour CalculInt2(int a, int b, out int c, ref int d) // On suppose que retour existe
        //{
        //    a++;
        //    a = a + b;
        //    c = a + b;
        //    return new Retour // via les list object initalizer (ne fonctionne qu'avec les Propriétés)
        //    {
        //        Val1 = a,
        //        Val2 = b,
        //        Val3 = c
        //    }; 
        //}

        //Sur les paramètres par défault
        public int Calc2(int a, int b = 5, int c = 10) // b a une valeur par défaut, cela permet de ne pas donner b lors d'un appel 
                                           // ou bien de le modifier.
        {
            return a + b;
        }

    }
}
