using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    /// <summary>
    /// Définit les règles du garage 
    /// </summary>
    internal static class Rules
    {
        // Logique Garage
        public const int WORKSHOP_MAX_CAPACITY = 5;    // Note : une const est traité comme étant static
        public const int FOUR_WHEELS_MAX_CAPACITY = 2; // les deux mots clefs sont incompatible
        public const string MILEAGE_UNIT = "km";
        // Logique Vehicule
        public const string DEFAULT_BRAND = "Inconnue";
        public const string DEFAULT_MODEL = "Inconnue";
        public const VehicleState DEFAULT_STATE = ExoGarage.VehicleState.New;
        public const float DEFAULT_MILEAGE = 0;
        // Logique Sous Classe de Véhicule
        public const int DEFAULT_2WN = 2;
        public const TwoWheelsSubType DEFAULT_2WN_SUBTYPE = TwoWheelsSubType.none;
        public const int DEFAULT_4WN = 4;
        public const FourWheelsSubType DEFAULT_4WN_SUBTYPE = FourWheelsSubType.none;

        public string StateToString(VehicleState state) // à ne pas mettre ici car empèche l'accès au nom en dehors sans instance de Vehicule
        {
            switch (state)
            {
                case VehicleState.New: return "Neuf";
                case VehicleState.Good: return "Bon";
                case VehicleState.Average: return "Moyen";
                case VehicleState.Bad: return "Mauvais";
                default: return "Indéfini";
            }
        }

    }

}
