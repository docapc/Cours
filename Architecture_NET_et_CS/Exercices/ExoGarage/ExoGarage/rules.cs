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
        public const int WORKSHOP_MAX_CAPACITY = 5; 
        public const int FOUR_WHEELS_MAX_CAPACITY = 2;

        // Getters  (pas nécessaire si const passé en public : elles sont non modifiable de toutes facon)  
        //public static int MaxCapacity
        //{
        //    get { return _workshop_max_capacity; }
        //}
        //public static int Max4WheelsCapacity
        //{
        //    get { return _4wheels_max_capacity; }
        //}

    }

}
