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
        /// CarWorkShop Logic 
        public const int WORKSHOP_MAX_CAPACITY = 5;    
        public const int FOUR_WHEELS_MAX_CAPACITY = 2; 
        public const string MILEAGE_UNIT = "km";
        
        /// Vehicle logic
        public const string DEFAULT_BRAND = "Inconnue";
        public const string DEFAULT_MODEL = "Inconnue";
        public const VehicleState DEFAULT_STATE = ExoGarage.VehicleState.New;
        public const float DEFAULT_MILEAGE = 0;
        public const int TWOWHEELS_NWHEELS = 2;
        
        /// SubType logic
        public const FourWheelsSubType DEFAULT_4W_SUBTYPE = FourWheelsSubType.car;
        public const int DEFAULT_4W_NWHEELS = 4;
        public const TwoWheelsSubType DEFAULT_2W_SUBTYPE = TwoWheelsSubType.motorbike;
        public const int DEFAULT_2W_NWHEELS = 2;
    }
}
