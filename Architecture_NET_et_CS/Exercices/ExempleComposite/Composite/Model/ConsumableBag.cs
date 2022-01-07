using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Model
{
    internal class ConsumableBag : Composite
    {
        public ConsumableBag(string name) : base(name)
        {            
        }

        public override void AddComponent(IComponent component)
        {
            var consumable = (Consumable)component;
            if (!IsFull())
            {
                base.AddComponent(component);
            }
        }

        private bool IsFull()
        {
            return _components.Count() <= Rules.MAX_WEAPONBAG_WEIGHT;
        }
    }
}
