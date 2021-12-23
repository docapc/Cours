using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal static class TwoWheelsSTExtension
    {
        public static string GetString(this TwoWheelsSubType subtype)
        {
            switch (subtype)
            {
                case TwoWheelsSubType.motorbike: return "Moto";
                case TwoWheelsSubType.bike: return "Vélo";
                case TwoWheelsSubType.scooter: return "Trottinette";
                default: return "Indéfini";
            }
        }
    }
}

