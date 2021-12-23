using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ExoGarage
{
    internal class FourWheels : Vehicle
    {
        private FourWheelsSubType SubType { get; }
        /// <summary>
        /// Constructeur Fille
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="state"></param>
        /// <param name="mileage"></param>
        /// <param name="subtype"></param>
        /// <exception cref="InvalidEnumArgumentException"
        public FourWheels(string brand = Rules.DEFAULT_BRAND, string model = Rules.DEFAULT_MODEL, 
            VehicleState state = Rules.DEFAULT_STATE, float mileage = Rules.DEFAULT_MILEAGE, 
            FourWheelsSubType subtype = Rules.DEFAULT_4W_SUBTYPE)
            : base(brand, model, state, mileage) 
        {

            WheelsNumber = Rules.DEFAULT_4W_NWHEELS;
            if (Enum.IsDefined(typeof(FourWheelsSubType), subtype))
            {
                SubType = subtype;
            }
            else
            {
                throw new InvalidEnumArgumentException("Du constructeur de FourWheels : l'état passé n'est pas dans liste autorisée" +
                    " voir VehicleSate pour les types authorisés.");
            }
        }

        public override string ToString()
        {
            return $"{SubType.GetString()} : {base.ToString()}";
        }

    }

 
}
