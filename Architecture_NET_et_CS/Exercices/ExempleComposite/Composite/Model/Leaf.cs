using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Model
{
    public class Leaf : IComponent
    {

        public string Name { get; private set; } // fait partie du pattern : attribut demandé par le contrat

        public Leaf(string name)
        {
            Name = name;
        }

        public void LoadLeafs(List<IComponent> leafs) // fait partie du pattern : méthode demandée par le contrat
        {
            leafs.Add(this);
        }

    }
}
