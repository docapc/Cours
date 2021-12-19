using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesCSharp
{
    public static class DemoConst
    {
        public const string CHAT = "CHAT"; // const au compile time
        public const string CHIEN = "CHIEN";

        private static readonly Calcul cal; // const au runtime

        static DemoConst() // pour initialiser en static
        {
            cal = new Calcul();
        }
    }
}
