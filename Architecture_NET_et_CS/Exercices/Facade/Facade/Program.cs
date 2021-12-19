using System;

namespace ExempleFacade
{

    class Program
    {
        static void Main(string[] args)
        {
            var my_facade = new Facade(); // var est l'équivalent du auto en c++
            // on pourrait aussi faire 
            // Facade my_facade = new(); // C# 9
            my_facade.CallSub();

            var a = my_facade.Save();

            Console.WriteLine(a);
            Console.ReadLine(); // demande à l'utilisateur de saisir qq chose avant de fermer la consol
                                // petit trick pour bloquer l'exécution d'un programme.

        }
    }
}
