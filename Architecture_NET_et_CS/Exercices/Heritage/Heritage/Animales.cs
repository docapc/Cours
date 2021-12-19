using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{

    public abstract class Animales // abstract est nécessaire pour déclarrer des méthodes, propriétes ou attribut abstrait par la suite
    {
        public string Nom { get; set; }

        public int Age { get; set; }

        public Animales()
        {
        }
        public Animales(string nom, int age = 1)
        {
            Nom = nom;
            Age = age;
        }

        public void Dormir()
        {
            Console.WriteLine($"Je m'apelle {Nom} et je dors");
        }

        public abstract void Manger(); // déclaration, pas implémentation

    }
}
