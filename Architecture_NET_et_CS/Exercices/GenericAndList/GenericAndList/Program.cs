using System;
using System.Collections.Generic; // pour les List
using GenericAndList.Models;

namespace GenericAndList
{
  


    class Program
    {
        static void Main(string[] args)
        {
            // Generic de type string
            var usersName = new List<string>(); // un breakpoint ici
            usersName.Add("Exemple");

            // Generic de type User
            var u = new UserList<User>();
            var defaultUser = u.GetUser();

            Console.WriteLine("Fin"); // Juste pour éviter la fin  prématurée du programme en mode debug
        }
    }
}
