using System;

// exemple naif https://refactoring.guru/fr/design-patterns/singleton/csharp/example#example-0
// pour du trade safe https://refactoring.guru/fr/design-patterns/singleton/csharp/example#example-1 avec lock qui empèche plusieur thread
// de partager une instance

namespace Singleton // sans héritage tt objet hérite de System.ObjectModel
{
    sealed class Single// sealed signifie que l'on ne peut pas hériter 
    {
        private static Single m_instance;
        // Constructeur
        private Single()
        {

        }
        // En c# les méthodes commencent par une majuscule
        public static Single GetInstance()
        {
            if (m_instance == null) // # condition entre parenthèse obligatoirement
            {
                m_instance = new Single(); // new est obligatoire pour déclarer une nouvelle instance
            }
            return m_instance;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Single my_singleton = Single.GetInstance(); 
            Single my_other_singleton = Single.GetInstance();

            Console.WriteLine(my_singleton.GetHashCode()); // GetHashCode est une fonction de Hashage par défaut
            Console.WriteLine(my_other_singleton.GetHashCode());
        }
    }
}
