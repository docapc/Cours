using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal enum VehicleState
    {
        New = 0, // Note la première valeure d'une enum sera la valeur par defaut (uint 0)
        Good = 1,
        Average = 2, 
        Bad = 3,

        End = 4
    }
}
