using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal enum VehicleState
    {
        New, // Note la première valeure d'une enum sera la valeur par defaut (uint 0)
        Good,
        Average, 
        Bad,
    }
}
