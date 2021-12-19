using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleStrategy
{
    public class WalkingStrategy : IRouteStrategy
    {
        public string BuildRoute(string A, string B)
        {
            return "De " + A + " à " + B + " à pied";
        }
    }
}
