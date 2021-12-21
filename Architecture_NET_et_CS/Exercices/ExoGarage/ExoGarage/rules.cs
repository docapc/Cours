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
        // Attributs
        private const int WORKSHOP_MAX_CAPACITY = 5;    // Note : une const est traité comme étant static
        private const int FOUR_WHEELS_MAX_CAPACITY = 2; // les deux mots clefs sont incompatible
        private const string MILEAGE_UNIT = "km";
        // Getters  (pas nécessaire si const passé en public : mais ne respecterai pas l'encapsulation)  
        public static int MaxCapacity
        {
            get { return WORKSHOP_MAX_CAPACITY; }
        }
        public static int MaxFourWheelsCapacity
        {
            get { return FOUR_WHEELS_MAX_CAPACITY; }
        }
        public static string MileageUnit
        {
            get { return MILEAGE_UNIT; }
        }

    }

}
