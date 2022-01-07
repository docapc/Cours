using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Model
{
    public class WeaponBag : Composite, IWeighable
    {
        //public int Weight { get; private set; }
        public int Weight // en lecture seul car sans set ou init
        {
            get
            {
                int total_weight = 0;
                foreach (var weighable_items in _components)
                {
                    if (weighable_items is IWeighable) // uniquement si l'élément est IWeighable
                        total_weight = total_weight + ((IWeighable)weighable_items).Weight;
                }
                return total_weight;
            }
        }
        public WeaponBag(string name):  base(name)
        {
            //Weight = 0;
        }

        public override void AddComponent(IComponent component)
        {
            if (component is IWeighable)
            {
                var weighable_component = (IWeighable)component;
                AddWeighable(weighable_component);
            }
            else
            {
                base.AddComponent(component); // pour ajouter un composite ou une leaf sans poid
            }
        }

        private void AddWeighable(IWeighable weighable_component)
        {
            if (IsAddable(weighable_component.Weight))
            {
                base.AddComponent(weighable_component);
                //Weight += weighable_component.Weight;
            }
            else
            {
                Console.WriteLine($" {weighable_component.Name} is to heavy to be added.");
            }
        }

        private bool IsAddable(int weight)
        {
            return Weight+weight <= Rules.MAX_WEAPONBAG_TOTALWEIGHT;
        }

    }
}
