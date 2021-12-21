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
        private static int s_id = 0;
        private readonly int _id;
        //private readonly VehicleBrand _brand; // on peut rester avec des string la dessus pour l'instant
        //private readonly VehicleModel _model; // mais dans l'idée il faudrait au moins des énums pour assurer l'unicité de chaque entrée possible
        private readonly string _brand;
        private readonly string _model;
        private VehicleState _state;
        private float _mileage; 

        // Constructeur(s)
        // note : on ne peut pas utiliser string.Empty : le compilateur se plein d'une valeur non compile time constant!
        public Vehicle(string brand = "", string model = "", VehicleState state = VehicleState.New, float mileage = 0)
        {
            _id = ++s_id; // le id sert au stats du garage, pas à l'indexation dans la list
            _brand = brand;
            _model = model;
            State = state;
            _mileage = mileage;
        }

        // Méthodes public
        public override string ToString() // virtual au lieu d'override ici??? voir abstract -> empècherai la définition parentes communes
        {
            /// Permet d'afficher les caractéristiques d'un véhicule
            return $"{_brand}, model : {_model}, State : {State}, mileage = {_mileage} {Rules.MileageUnit} (garage id = {_id})";
        }

        // Méthodes privées
        private string StateToString()
        {
            /// Renvoie une string correspondant à l'état du véhicule (pour changer la langue)
            switch (State)
            {
                case VehicleState.New:      return "Neuf";
                case VehicleState.Good:     return "Bon";
                case VehicleState.Average:  return "Moyen";
                case VehicleState.Bad:      return "Mauvais";
                default:                    return "Indéfini";
            }
        }

        // Getter/Setter
        public VehicleState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int ID
        {
            get { return _id; }
        }

    }
}
