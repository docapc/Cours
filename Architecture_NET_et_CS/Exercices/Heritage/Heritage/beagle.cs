using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    class Beagle : Chien
    {
        public Beagle()
        {
        }

        public Beagle(string nom, int age = 2) : base(nom, age) // base permet d'appeler le constructeur de la classe mère
        {
        }

        public override void Courrir() // override est nécessaire pour remplacer le comportement de la méthode mère par la méthode fille
        {
            Console.WriteLine($"Le Beagle cours");
        }

        public void test (string a)
        {

        }
        public void test(int a)
        {

        }
    }
}
