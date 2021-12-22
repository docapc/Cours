using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal class FourWheels : Vehicle
    {
        public FourWheels(FourWheelsSubType subtype = Rules.DEFAULT_4WN_SUBTYPE, string brand = Rules.DEFAULT_BRAND, 
            string model = Rules.DEFAULT_MODEL, VehicleState state = Rules.DEFAULT_STATE, 
            float mileage = Rules.DEFAULT_MILEAGE)
            : base(brand, model, state, mileage) 
        {
            WheelsNumber = Rules.DEFAULT_2WN;
            SubType = subtype;
        }

        protected override string SubTypeToString()
        {
            switch (SubType)
            {
                case FourWheelsSubType.car: return "Voiture";
                case FourWheelsSubType.smallcar: return "Pot de yahourt";
                default: return "Indéfini";
            }
        }
    }
}
