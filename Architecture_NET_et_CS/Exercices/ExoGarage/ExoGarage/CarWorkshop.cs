using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///  Remarque : utiliser une Factory?
/// </summary>
namespace ExoGarage
{
    internal class CarWorkshop
    {
        // Attributs
        private List<Vehicle> _vehicles; // remarque, Une array (de taille fixe) serait peut être mieux...

        // Constructeur
        public CarWorkshop()
        {
            _vehicles = new List<Vehicle>(); // le type List ne peut peut pas être null, seulement Empty ce qui ne gène pas ici
        }
        public CarWorkshop(List<Vehicle> vehicles)
        {
            // Il faut tester le type null ici
            _vehicles = vehicles; // le type List ne peut peut pas être null, seulement Empty
            // Ici la validation dans le cas d'un chargement via fichier.
        }


        // Méthodes public
        public void AddVehicle(Vehicle vehicle)
        {
        // try 
            /// Ajoute un vehicule au Garage si celui en à la capacité
            if (_vehicles.Count > Rules.MaxCapacity)
            {   // Il faut aussi ajouter des test sur la capacité de contenance par type!
                _vehicles.Add(vehicle);
            }
            else
            {
                   // Lever une exception?
            }
        // catch 
        }

        // Méthodes public
        public void RemoveVehicle(int index)
        {
            /// Supprime un véhicule à la position index dans la liste de véhicules
        //try 
            // même chose qu'au dessus à mettre dans un try catch au final???
            _vehicles.RemoveAt(index);
        //catch 
        }

        public void SetVehicleState(int index, VehicleState state)
        {
            /// Description : Change l'état du véhicule en position index dans la list
            /// Syntax : SetVehicleState(int index, VehicleState state)
            _vehicles[index].State = state;
        }

        // Méthodes private

        // Getter/Setter
        public List<Vehicle> Vehicles
        {
            /// Renvoie la list de véhicules pour lecture uniquement
            get { return _vehicles; }
        }

    }
}
