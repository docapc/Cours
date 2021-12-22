using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal class Menu
    {
        private CarWorkshop WorkShop { get; set; }

        public Menu()
        {
            WorkShop = new CarWorkshop();
        }

        public void Run()
        {

            Console.WriteLine("Entrée au Garage");
            while (true)
            {
                PrintMenu();
                var input = ReadIntFromUser();
                switch (input)
                {
                    case 1: { CallAdd(); break; }
                    case 2: { CallSuppress(); break; }
                    case 3: { CallChangeState(); break; }
                    case 4: { PrintGarage(); break; }
                    case 5: { return; }
                    default: Console.WriteLine("Valeur entrée invalide, Réessayer."); break;
                }
            }
        }

        private void CallAdd()
        {
            if (!WorkShop.IsAtMaxCapacity)
            {
                Console.WriteLine("Quelle genre de véhicule voulez vous rajouter?");
                Console.WriteLine("Tappez 1 pour un véhicule à 2 roues, 2 pour un véhicule à 4 roues");
                while (true)
                {
                    var input = ReadIntFromUser();
                    if (input == 1 | input == 2)
                    {
                     //   var vehicle = MakeVehicle(input);
                        return;
                    }
                    Console.WriteLine("Valeur entrée invalide, Réessayer.");
                }
            }
            else
            {
                Console.WriteLine("Le garage est plein!!!");
            }
        }

        //private Vehicle MakeVehicle(int type)
        //{
        //    if type == 1
        //    {
        //        return new FourWheels()
        //    }
        //    else
        //    {
        //        return new TwoWheels()
        //    }
        //}

        private void CallSuppress()
        {
            
            if (WorkShop.Vehicles.Any()) // IEnumerable.Any() renvoie vrai si il y a au moins 1 élément, faux sinon
            {
                PrintGarage();
                Console.WriteLine("Quelle véhicule voulez vous supprimer?");
                var index = ReadIntFromUser();
                try
                {
                    WorkShop.RemoveVehicle(index);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"Cet emplacement du garage n'existe pas ({e.Message}).\n Retour au menu. Revenez pour réessayer"); 
                }
            }
            else
            {
                Console.WriteLine("Il n'y a aucun véhicules dans le garage");
                Console.WriteLine("Retour au menu.");
            }
        
        }

        private void CallChangeState()
        {
            Console.WriteLine("Quel véhicule modifier?");
            PrintGarage();
            var index = ReadIntFromUser();
            try
            {
                WorkShop.RemoveVehicle(index);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Cet emplacement du garage n'existe pas ({e.Message}).\n Retour au menu. Revenez pour réessayer");
            }
        }

        private void PrintGarage()
        {
            Console.WriteLine("Véhicules Disponibles");
            var vehicles = WorkShop.Vehicles.ToList();
            for(int i=0; i<vehicles.Count();i++)
            {
                Console.WriteLine($"Place {i} : {vehicles[i]}");
            }
        }

//        private void PrintPossiblesState()
//        {
//            var names = Enum.GetValues(typeof(VehicleState)); VehicleState.
//            Console.WriteLine("Etats disponibles");
//            for (int i = 0; i < names.Length; i++)
//            {
//                Console.WriteLine($"{i} : {VehicleState}");
////                string m = Enum.GetName(typeof(MyEnumClass), value);
//            }
//        }
        private void PrintMenu()
        {
            Console.WriteLine("Que faire? (Choisissez un nombre valide)");
            Console.WriteLine("1 - Ajouter un vehicule");
            Console.WriteLine("2 - Enlever un véhicule");
            Console.WriteLine("3 - Modifier l'état d'un véhicule");
            Console.WriteLine("4 - Lister les véhicules présents");
            Console.WriteLine("5 - Quitter l'application");
        }

        private int ReadIntFromUser()
        {
            while (true)
            {             
            int index;
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    return index;
                }
                else
                {
                    Console.WriteLine("La valeur entrée n'est pas un int. Réessayez.");
                }
            }
        }
    }
}
