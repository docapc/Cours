using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ExoGarage
{
    internal class Menu
    {
        private CarWorkshop WorkShop { get; }

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

        private void PrintMenu()
        {
            Console.WriteLine("Que faire? (Choisissez un nombre valide)");
            Console.WriteLine("1 - Ajouter un vehicule");
            Console.WriteLine("2 - Enlever un véhicule");
            Console.WriteLine("3 - Modifier l'état d'un véhicule");
            Console.WriteLine("4 - Lister les véhicules présents");
            Console.WriteLine("5 - Quitter l'application");
        }

        /// <summary>
        /// Aucuns controle des input dans la CallAdd donc devrait lever plein d'erreur en cas de mauvaise utilisation
        /// </summary>
        private void CallAdd()
        {
            if (!WorkShop.IsAtMaxCapacity)
            {
                Console.WriteLine("Quelle genre de véhicule voulez vous rajouter?");
                Console.WriteLine("1 pour un véhicule à 2 roues");
                Console.WriteLine("2 pour un véhicule à 4 roues");
                while (true)
                {
                    var input_type = ReadIntFromUser();
                    if (input_type == 1 | input_type == 2)
                    {
                        switch (input_type)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Quelle est le type exact du véhicule?");
                                    Console.WriteLine("Types disponibles : (Choississez un nombre valide)");
                                    int j = 0;
                                    foreach (TwoWheelsSubType elem in Enum.GetValues(typeof(TwoWheelsSubType)))
                                    {
                                        Console.WriteLine($"Emplacement {j} - {elem.GetString()}");
                                        ++j;
                                    }
                                    
                                    int input = ReadIntFromUser();
                                    TwoWheelsSubType subtype = (TwoWheelsSubType)input; 

                                    PrintStates();
                                    input = ReadIntFromUser(); 
                                    VehicleState state = (VehicleState)input;

                                    Console.WriteLine("Quelle est la marque");
                                    var brand = Console.ReadLine();

                                    Console.WriteLine("Quelle est le modèle");
                                    var model = Console.ReadLine();

                                    Console.WriteLine("Quelle est le kilométrage"); 
                                    var mileage = ReadFloatFromUser();
                                    try
                                    {
                                        WorkShop.AddVehicle(new TwoWheels(brand, model, state, mileage, subtype));
                                        Console.WriteLine("Véhicule ajouté");
                                    }
                                    catch (MyBadStringException mbe)
                                    {
                                        Console.WriteLine($"{mbe.Message}, {mbe.GetType()}");
                                        Console.WriteLine("Retour au menu");
                                    }
                                    catch (MyNegativeParamException mne)
                                    {
                                        Console.WriteLine($"{mne.Message}, {mne.GetType()}");
                                        Console.WriteLine("Retour au menu");
                                    }
                                    catch (InvalidEnumArgumentException iee)
                                    {
                                        Console.WriteLine($"{iee.Message}, {iee.GetType()}");
                                        Console.WriteLine("Retour au menu");
                                    }
                                    catch (MyCapacityException mce) 
                                    {
                                        Console.WriteLine($"{mce.Message}, {mce.GetType()}");
                                        Console.WriteLine("Retour au menu");
                                    }
                                }
                                return;

                            case 2:
                                {
                                    if (WorkShop.IsAtFourWheelMax)
                                    {
                                        Console.WriteLine("Le garage est au maximum de sa capacité pour ce type de véhicule");
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Quelle est le type exact du véhicule?");
                                        Console.WriteLine("Types disponibles : (Choississez un nombre valide)");
                                        int j = 0;
                                        foreach (FourWheelsSubType elem in Enum.GetValues(typeof(TwoWheelsSubType)))
                                        {
                                            Console.WriteLine($"Emplacement {j} - {elem.GetString()}");
                                            ++j;
                                        }

                                        int input = ReadIntFromUser();
                                        FourWheelsSubType subtype = (FourWheelsSubType)input; 

                                        PrintStates();
                                        input = ReadIntFromUser(); 
                                        VehicleState state = (VehicleState)input;

                                        Console.WriteLine("Quelle est la marque");
                                        var brand = Console.ReadLine();

                                        Console.WriteLine("Quelle est le modèle");
                                        var model = Console.ReadLine();

                                        Console.WriteLine("Quelle est le kilométrage"); 
                                        var mileage = ReadFloatFromUser();

                                        try
                                        {
                                            WorkShop.AddVehicle(new FourWheels(brand, model, state, mileage, subtype));
                                            Console.WriteLine("Véhicule ajouté");
                                        }
                                        catch (MyBadStringException mbe)
                                        {
                                            Console.WriteLine($"{mbe.Message}, {mbe.GetType()}");
                                            Console.WriteLine("Retour au menu");
                                        }
                                        catch (MyNegativeParamException mne)
                                        {
                                            Console.WriteLine($"{mne.Message}, {mne.GetType()}");
                                            Console.WriteLine("Retour au menu");
                                        }
                                        catch (InvalidEnumArgumentException iee)
                                        {
                                            Console.WriteLine($"{iee.Message}, {iee.GetType()}");
                                            Console.WriteLine("Retour au menu");
                                        }
                                        catch (MyCapacityException mce)
                                        {
                                            Console.WriteLine($"{mce.Message}, {mce.GetType()}");
                                            Console.WriteLine("Retour au menu");
                                        }
                                    }
                                }

                                return;
                        }
                    }
                    Console.WriteLine("Valeur entrée invalide, Réessayer.");
                }
            }
            else
            {
                Console.WriteLine("Le garage est plein!!!");
            }
        }

        private void CallSuppress()
        {
            
            if (WorkShop.Vehicles.Any()) 
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
            if (WorkShop.Vehicles.Any()) 
            {
                Console.WriteLine("Quel véhicule modifier?");
                PrintGarage();
                var index = ReadIntFromUser();

                PrintStates();
                var input = ReadIntFromUser(); 
                VehicleState state = (VehicleState)input;
                try
                {
                    WorkShop.SetVehicleState(index,state);
                    Console.WriteLine($"Véhicule modifié");
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

        private void PrintStates()
        {
            Console.WriteLine("Etats disponibles : (Choississez un nombre valide)");
            int i = 0;
            foreach (VehicleState elem in Enum.GetValues(typeof(VehicleState))) 
            {
                Console.WriteLine($"{i} - {elem.GetString()}");
                ++i;
            }
        }

        private void PrintGarage()
        {
            if (WorkShop.Vehicles.Any())
            {                
                Console.WriteLine("Véhicules Disponibles");
                var vehicles = WorkShop.Vehicles.ToList();
                for (int i = 0; i < vehicles.Count(); i++)
                {
                    Console.WriteLine($"Emplacement {i} : {vehicles[i]}");
                }
            }
            else
            {
                Console.WriteLine("Il n'y a aucun véhicules dans le garage");
                Console.WriteLine("Retour au menu.");
            }
        }

        private int ReadIntFromUser()
        {
            Console.WriteLine("Choisissez un int : ");

            int index;
            if (int.TryParse(Console.ReadLine(), out index))
            {
                return index;
            }
            else
            {
                Console.WriteLine("La valeur entrée n'est pas un int. Réessayez.");
                return ReadIntFromUser();
            }
        }

        private float ReadFloatFromUser()
        {
            Console.WriteLine("Choisissez un float : ");

            float f;
            if (float.TryParse(Console.ReadLine(), out f))
            {
                return f;
            }
            else
            {
                Console.WriteLine("La valeur entrée n'est pas un float. Réessayez.");
                return ReadFloatFromUser();
            }
        }
    }

}

    


