using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.Proxy.Model
{
    public class Ordinateur : IOrdinateur
    {
        public void DoSomeSensibleStuff()
        {                
            Console.WriteLine("un truc important et très lourd à faire est fait");
        }
    }
}

