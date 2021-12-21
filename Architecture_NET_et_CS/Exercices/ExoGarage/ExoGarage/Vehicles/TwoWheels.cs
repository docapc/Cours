using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal class TwoWheels : Vehicle, ISomeWheels
    {
        public TwoWheels(TwoWheelsSubType subtype, string brand = "", string model = "", VehicleState state = VehicleState.New, float mileage = 0) 
            : base(brand, model, state, mileage)
        {

        }

    }
}
