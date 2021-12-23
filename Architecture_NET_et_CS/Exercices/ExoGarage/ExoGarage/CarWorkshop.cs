using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace ExoGarage
{
    internal class CarWorkshop
    {
         
        private readonly List<Vehicle> _vehicles;

        /// <summary>
        /// Constructeur de garage vide
        /// </summary>
        public CarWorkshop()
        {
            _vehicles = new List<Vehicle>();
        }

        /// <summary>
        /// Ajoute un véhicule au garage
        /// </summary>
        /// <param name="vehicle"></param>
        /// <exception cref="MyCapacityException"></exception>
        public void AddVehicle(Vehicle vehicle)
        {
  
            if (IsAtMaxCapacity)
            {
                throw new MyCapacityException($"De AddVehicle : Garage à capacité maximum");
            }
            //if ((vehicle.GetType() is FourWheels) && IsAtFourWheelMax)
            if ((vehicle is FourWheels) && IsAtFourWheelMax)
            {
                throw new MyCapacityException($"De AddVehicle : Garage à capacité maximum (en {Rules.DEFAULT_4W_NWHEELS} roues)");
            }
            _vehicles.Add(vehicle);
        }

        /// <summary>
        /// Supprime un véhicule à la position index dans la liste de véhicules
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemoveVehicle(int index)
        {
            /// 
            try
            {
                _vehicles.RemoveAt(index); // peut lever une erreur de type problème d'indexation
            }
            catch (ArgumentOutOfRangeException ae)
            {
                throw new ArgumentOutOfRangeException($"Echec de l'indexation lors de la suppression du vehicule (mauvais index passé en entré?) {ae.GetType}"); // on repasse l
            }
        }

        /// <summary>
        /// Change l'état du véhicule en position index dans la liste de véhicule. Ici pour ne jamais renvoyer de ref 
        /// vers un véhicule du garage dans le niveau supérieur (Menu)
        /// </summary>
        /// <param name="index">int</param>
        /// <param name="state">VehicleState</param>
        public void SetVehicleState(int index, VehicleState state)
        {
            if (IsAtMaxCapacity)
            {
                throw new MyCapacityException($"De AddVehicle : Garage à capacité maximum");
            }
            _vehicles[index].State = state;
        }

        /// <summary>
        /// Le garage est il plein?
        /// </summary>
        /// <returns>bool</returns>
        public bool IsAtMaxCapacity
        {
            /// Le garage est t'il plein
            get { return _vehicles.Count >= Rules.WORKSHOP_MAX_CAPACITY; }

        }

        /// <summary>
        /// Le garage est il au maximum de sa capacité en 4 rous?
        /// </summary>
        /// <returns>bool</returns>
        public bool IsAtFourWheelMax
        {
            get { return CheckFourWheelsNumber() >= Rules.FOUR_WHEELS_MAX_CAPACITY; }
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
                //if (vehicle.GetType() == typeof(FourWheels))
                if (vehicle is FourWheels)
                    {
                    ++count;
                }
            }
            return count;
        }

        /// <summary>
        /// Property pour récupérer la liste de véhicule sous forme IEnumerable
        /// </summary>
        public IEnumerable<Vehicle> Vehicles 
        {
            get { return _vehicles; }
        }

    }
}
