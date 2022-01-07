using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Model
{
    public class Leaf : IComponent
    {
        public string Name { get; private set;}

        public Leaf(string name)
        {
            Name = name;
        }

        public void LoadLeafs(List<IComponent> leafs)
        {
            leafs.Add(this);
        }

        //public IEnumerable<IComponent> GetComponents()
        //{
        //    yield return this;
        //}

        //public IComponent GetComponent()
        //{
        //    return this;
        //}
    }
}
