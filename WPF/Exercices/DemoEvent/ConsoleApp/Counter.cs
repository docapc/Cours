using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Counter
    {
        public event EventHandler CounterEvent; //Déclaration de l'event
        // pointeur vers la méthode qui sera déclenché (la méthode appelante
        // qui peut être générique voir la version de nico)

        //public Counter ()
        //{
        //}

        public void Count()
        {
            while (true)
            {
                CounterEvent?.Invoke(this, new EventArgs());// this est le sender
                                                           // pour un argument cutsom il faut un objet 
                                                           // hérité de EventArgs
                // COunterEvent potentiellement nullable (le cas si pas d'abonné)
                Thread.Sleep(1000); // on attend une seconde
            }
        }

    }
}
