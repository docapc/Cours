using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal abstract class Vehicle
    {
        // Attributs
        private readonly int _id;
        private State _state;
        private readonly Brand _brand;
        private readonly Model _model;
        private float _mileage;

        // Constructeur
        public Vehicle()
        {

        }

        // Getter/Setter

        // Méthodes

        public override string ToString() // virtual au lieu d'override ici???
        {
            /// Permet d'afficher les caractéristique d'un véhicule
            return base.ToString();)
        }

    }
}
