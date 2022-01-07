using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Model
{
    public class WeaponBag : Composite
    {
        public int ActualWeight { get; private set; }
        public WeaponBag(string name):  base(name)
        {
            ActualWeight = 0;
        }

        public override void AddComponent(IComponent component)
        {
            if (component is Weapon)
            {
                var weapon = (Weapon)component;
                AddWeapon(weapon);
            }
            else
            {
                base.AddComponent(component); // pour ajouter un composite
            }
        }

        private void AddWeapon(Weapon weapon)
        {
            if (IsAddable(weapon.Weight))
            {
                base.AddComponent(weapon);
                ActualWeight += weapon.Weight;
            }
        }

        private bool IsAddable(int weight)
        {
            return ActualWeight<= (Rules.MAX_WEAPONBAG_WEIGHT+weight);
        }

    }
}
