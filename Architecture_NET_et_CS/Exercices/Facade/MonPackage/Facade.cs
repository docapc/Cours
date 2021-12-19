using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Note
namespace ExempleFacade
{
    public class Facade
    {
        private readonly DataAccess dataAccess = new DataAccess(); // readonly empèche les modification de l'instance après sa création ()
                                                                   // la variable ne pourra plus etre changé (l'adresse mémoire est figée)
        public bool Save()
        {
            return dataAccess.Save();
        }

        private SubSys my_subsystem = new SubSys(); //ctrl+; permet de créer une classe qui n'existe pas encore
        public void CallSub() // internal fait que seuls les classe du package peuvent utiliser 
        {
            Console.WriteLine("Facade appelé via CallSub()");
            my_subsystem.CallMe();
        }

    }
}
