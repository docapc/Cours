using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage
{
    internal interface ISomeWheels
    {
        // Propriétés (les interface ne fonctionne pas avec les attributs)
        public int WheelsNumber { get; set; } // on ne peut pas set en private dans une interface!
                                              // private Enum SubType; // ne fonctionne pas
        public int SubType { get; set; };
        //Méthodes privées 
        string SubTypeToString(); // le compilateur demande une définition... si l'on donne une visibilité

    }
}
