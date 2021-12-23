using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal static class FourWheelsSTExtension
    {
        public static string GetString(this FourWheelsSubType subtype) 
        {
            switch (subtype)
            {
                case FourWheelsSubType.car: return "Voiture";
                case FourWheelsSubType.smallcar: return "Pot De yahourt";
                case FourWheelsSubType.kart: return "Kart";
                default: return "Indéfinie";
            }
        }
    }
}
