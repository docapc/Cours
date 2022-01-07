using Ipme.ExoComposite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.ExoComposite.Main
{
    internal class ConsoleApp
    {
        internal void Run()
        {

            // Construction manuelle
            var inventory = new Composite("Inventory"); // inventaire générale
            
            var weapon_bag = new WeaponBag("Armory"); // partie armes (avec notion de poid)

            var fire_arms = new WeaponBag("Fire arms");// sous partie armes à feu
            fire_arms.AddComponent(new Weapon("Gun", 12));
            fire_arms.AddComponent(new Weapon("Machine gun", 45));

            var cold_steel = new WeaponBag("Cold steel"); // sous partie armes blanches
            cold_steel.AddComponent(new Weapon("Knife", 5));

            weapon_bag.AddComponent(cold_steel);
            weapon_bag.AddComponent(fire_arms);

            var consumable_bag = new ConsumableBag("Consumables"); // partie consommable (sans notion de poid)
            consumable_bag.AddComponent(new Consumable("Grenade"));
            
            inventory.AddComponent(weapon_bag);
            inventory.AddComponent(consumable_bag);


            // Vérification
            var all_leafs = new List<IComponent>();
            inventory.LoadLeafs(all_leafs);

            foreach (var leaf in all_leafs)
            {
                Console.WriteLine($"{leaf.Name}");
            }

            Console.WriteLine(weapon_bag.Weight); // la notion de poid n'existe que dans ce sac la

        }
    }
}
