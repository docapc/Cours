using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal class TwoWheels : Vehicle
    {
        //protected override TwoWheelsSubType SubType { get; set; }
        public TwoWheels(TwoWheelsSubType subtype = Rules.DEFAULT_2WN_SUBTYPE, string brand = Rules.DEFAULT_BRAND,
            string model = Rules.DEFAULT_MODEL, VehicleState state = Rules.DEFAULT_STATE,
            float mileage = Rules.DEFAULT_MILEAGE)
            :base(brand, model, state, mileage)
        {
            WheelsNumber = Rules.DEFAULT_4WN;
            SubType = subtype;            
        }

        protected override string SubTypeToString()
        {
            switch(SubType)
            {
                case TwoWheelsSubType.motorbike: return "Moto";
                case TwoWheelsSubType.bike: return "Vélo";
                case TwoWheelsSubType.scooter: return "Trotinette";
                default: return "Indéfini";
            }    
        }

    }
}
