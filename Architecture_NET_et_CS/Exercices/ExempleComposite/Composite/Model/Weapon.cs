using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Model
{
    public class Weapon : Leaf
    {
        public int Weight { get; private set; }
        public Weapon(string name, int weight) : base(name)
        {
            Weight = weight;
        }
    }
}
