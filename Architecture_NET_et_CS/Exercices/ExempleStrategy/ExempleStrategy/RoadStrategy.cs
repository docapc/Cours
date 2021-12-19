using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleStrategy 
{
    public class RoadStrategy : IRouteStrategy // Héritage de l'interface : "signature du contrat"
    {
        public string BuildRoute(string A, string B)
        {
            return "De " + A + " à " + B + " en voiture";
        }
    }
}
