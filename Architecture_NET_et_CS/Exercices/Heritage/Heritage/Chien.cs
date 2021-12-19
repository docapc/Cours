using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    public class Chien : Animales
    {
        public Chien()
        {

        }
        public Chien(string nom, int age = 2) : base(nom, age) // base permet d'appeler le constructeur de la classe mère
        {
        }
        public override void Manger()
        {
            Console.WriteLine($"Le Chien mange");
        }

        public virtual void Courrir() //virtual permet de surcharger la méthode (obligatoire)
        {
            Console.WriteLine($"Le Chien cours");
        }
    }
}
