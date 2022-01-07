using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Model
{
    public interface IComponent
    {
        public string Name { get; }
        public void LoadLeafs(List<IComponent> leafs); // passé par référence car List type référence (pas besoin de out ou ref)

        //public IEnumerable<IComponent> GetComponents();
        //public IEnumerable<string> GetAllNames();
        //public IComponent GetComponent();
    }
}
