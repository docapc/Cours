using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal class CarWorkshop
    {
        // Attributs
        private List<Vehicle> _vehicles;

        // Constructeur
        public CarWorkshop()
        {
        }

        // Getter/Setter

        // Méthodes
        public void Add(Vehicle vehicle)
        {
        // try 
            /// Ajoute un vehicule au Garage si celui en à la capacité
            if (_vehicles.Count > Rules.WORKSHOP_MAX_CAPACITY)
            {
                _vehicles.Add(vehicle);
            }
            else
            {
                   // Lever une exception?
            }
        // catch 
        }

        public void Del(int index)
        {
            /// Supprime un véhicule à la position index dans la liste de véhicules
        //try 
            // même chose qu'au dessus à mettre dans un try catch au final???
            _vehicles.RemoveAt(index);
        //catch 
        }

        public string 

    }
}
