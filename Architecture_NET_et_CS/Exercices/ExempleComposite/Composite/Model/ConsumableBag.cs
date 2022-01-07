using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Model
{
    public class ConsumableBag : Composite
    {
        public ConsumableBag(string name) : base(name)
        {            
        }

        public override void AddComponent(IComponent component)
        {
            //var consumable = (Consumable)component;
            if (HasSpaceAvaible())
            {
                base.AddComponent(component);
            }
            else
            {
                Console.WriteLine($"{this.Name} has no more avaible slots. Ipossible to add {component.Name}");
            }
        }

        private bool HasSpaceAvaible()
        {
            return _components.Count() <= Rules.MAX_CONSUMABLEBAG_CAPACITY; // à faire en récursivité pour de potentiel composite dans ce type de composite?
        }
    }
}
