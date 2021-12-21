using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal enum TwoWheelsSubType 
    {
        Motorbike = 0,
        bike = 1,
        scooter = 2 // sensé être trotinnette mais pas certain de la traduction : le passage en francais va poser un gros problème la dessus (les accents)!
                    // On a besoin d'un enum et d'un switch associée pour renvoyer des string qui correspondent!
    }
}
