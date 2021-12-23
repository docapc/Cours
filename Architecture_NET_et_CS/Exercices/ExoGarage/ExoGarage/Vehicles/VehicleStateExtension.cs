using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal static class VehicleStateExtension
    {
        public static string GetString(this VehicleState state)
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
