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
        private static int _sid = 0;
        protected readonly int _id;
        protected readonly string _brand;
        protected readonly string _model;
        protected VehicleState _state;
        protected float _mileage;
        // Getter/Setter
        protected Enum SubType { get; set; }
        protected int WheelsNumber {get; set;}
        public VehicleState State // foireux sa
        {
            get { return _state; }
            set { _state = value; }
        }
        private int Id // private pour l'instant
        {
            get { return _id; }
        }
        
        public Vehicle(string brand, string model, VehicleState state, float mileage)
        {
            _id = ++_sid; // le id sert au stats du garage, pas à l'indexation dans la list
            _brand = brand;
            _model = model;
            State = state;
            _mileage = mileage;
        }

        // Méthodes public
        public override string ToString() // virtual au lieu d'override ici??? voir abstract -> empècherai la définition parentes communes
        {
            /// Permet d'afficher les caractéristiques d'un véhicule
            return $"{WheelsNumber} roues ({SubTypeToString()}), Marque : {_brand}, Modèle : {_model}, Etat : {StateToString()}, ({_mileage} {Rules.MILEAGE_UNIT}), Id du Garage = {_id}";
        }

        /// <summary>
        /// Renvoie une string correspondant à l'état du véhicule (pour changer la langue)
        /// </summary>
        /// <returns>string</returns>
        // Méthodes privées
        public string StateToString() // à ne pas mettre ici car empèche l'accès au nom en dehors sans instance de Vehicule
        {
            switch (State)
            {
                case VehicleState.New:      return "Neuf";
                case VehicleState.Good:     return "Bon";
                case VehicleState.Average:  return "Moyen";
                case VehicleState.Bad:      return "Mauvais";
                default:                    return "Indéfini";
            }
        }

        /// <summary>
        /// Renvoie le nom de l'enum Subtype du véhicule.
        /// </summary>
        /// <returns>string</returns>
        protected abstract string SubTypeToString();

    }
}
