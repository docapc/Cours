using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesCSharp
{
    public enum MonEnum
    {
        Chat, 
        Chien,
        Cochon
    }

    // On peut rajouter des valeurs pour faire des comparaison
    public enum MonEnum2 
    {
        Chat = 1,
        Chien = 100,
        Cochon = 5
    }
}
