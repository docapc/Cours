using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAndList.Models
{
    internal class User
    {
        private string _name;

        public User(): this(string.Empty)
        {
        }
        //public User(string name)
        //{
        //    _name = name;
        //}

        // même chose en peu mieux car avec vérification de donnée
        public User(string name)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name; // ici on a un exmemple de l'opérateur ternaire
                                // si le nom est Null ou Vide on lève une exception
        }

        private string Name { get; private set; }

    }
}
