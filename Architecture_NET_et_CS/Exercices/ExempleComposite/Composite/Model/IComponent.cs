using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Model
{
    public interface IComponent // fait partie du pattern : Contrat que tt les éléments doivent respecter
    {
        public string Name { get; } // On assume que les Noms ne seront pas recherchés via Name
        public void LoadLeafs(List<IComponent> leafs); // passé par référence car List type référence (pas besoin de out ou ref)

    }
}
