using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    public class Chat : Animales
    {
        public Chat()
        {

        }
        public Chat(string nom, int age = 1) : base(nom, age) // base permet d'appeler le constructeur de la classe mère
        {
        }
        public override void Manger()
        {
            Console.WriteLine($"Le Chat mange");
        }

        public void Jouer()
        {
            Console.WriteLine($"Je joue");
        }
    }
}
