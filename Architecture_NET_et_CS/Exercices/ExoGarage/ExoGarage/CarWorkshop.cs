using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Idée : pattern Factory -> Le CarWorkShop créré aussi les véhicule à la volée
/// </summary>
namespace ExoGarage
{
    internal class CarWorkshop
    {
         
        private readonly List<Vehicle> _vehicles; // remarque, Une array (de taille fixe) serait peut être mieux...
        // remarque le champ est readonly mais la list est quand même modifiable!


        public CarWorkshop()
        {
            _vehicles = new List<Vehicle>(); // le type List, une fois instancié, ne peut peut pas être null, seulement Empty ce qui ne gène pas ici
        }

        //public CarWorkshop(List<Vehicle> vehicles) // Constructeur pour chargement via fichier
        //{
        //    // Il faut tester le type null ici
        //    _vehicles = vehicles; // le type List ne peut peut pas être null, seulement Empty
        //    // Ici la validation dans le cas d'un chargement via fichier.
        //}


        public void AddVehicle(Vehicle vehicle)
        {
            if (IsAtMaxCapacity)
            {
                //throw new FullCapacityException($"");
            }
            if ((vehicle.GetType() is FourWheels) && IsAtFourWheelMax)
            {
                //throw new FourWheelCapacityExcepetion($"");
            }
            _vehicles.Add(vehicle);
        }

        // try 
            /// Ajoute un vehicule au Garage si celui en à la capacité
            //if (!IsAtMaxCapacity)
            //{   // test de contenance par type
            //    if(vehicle.GetType() is FourWheels)
            //    {
            //        // excepetion ici
            //    }
            //}
            //else
            //{
            //       // Lever une exception?
            //}
        // catch 
      

        public void RemoveVehicle(int index)
        {
            /// Supprime un véhicule à la position index dans la liste de véhicules
            try
            {
                _vehicles.RemoveAt(index); // peut lever une erreur de type problème d'indexation
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
        }

        /// <summary>
        /// Change l'état du véhicule en position index dans la liste de véhicule
        /// </summary>
        /// <param name="index">int</param>
        /// <param name="state">VehicleState</param>
        public void SetVehicleState(int index, VehicleState state)
        {
            _vehicles[index].State = state;
        }

        /// <summary>
        /// Le garage est il plein
        /// </summary>
        /// <returns>bool</returns>
        public bool IsAtMaxCapacity
        {
            /// Le garage est t'il plein
            get { return _vehicles.Count == Rules.WORKSHOP_MAX_CAPACITY; }

        }

        /// <summary>
        /// Le garage est il au maximum de sa capacité en 4 rous?
        /// </summary>
        /// <returns>bool</returns>
        public bool IsAtFourWheelMax
        {
            get { return CheckFourWheelsNumber() == Rules.FOUR_WHEELS_MAX_CAPACITY; }
        }

        /// <summary>
        /// Renvoie le nombre de Véhicules à 4 Roues
        /// </summary>
        /// <returns>int</returns>
        private int CheckFourWheelsNumber()
        {
            int count = 0;
            foreach (Vehicle vehicle in _vehicles)
            {
                if (vehicle.GetType() is FourWheels)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Property pour récupérer la liste de véhicule sous forme IEnumerable
        /// </summary>
        public IEnumerable<Vehicle> Vehicles // à ne pas faire : ne jamais renvoyer des list dans un getter
        {
            get { return _vehicles; }
        }

    }
}
