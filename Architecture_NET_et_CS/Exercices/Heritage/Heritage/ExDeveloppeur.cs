using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    public class ExDeveloppeur
    {
        public string Name { get; set; }
       
        public virtual void Coder() // si pas de virtual on ne peut pas override la méthode chez les Filles
        {
            Console.WriteLine($"{Name}!");
        }

    }
}
