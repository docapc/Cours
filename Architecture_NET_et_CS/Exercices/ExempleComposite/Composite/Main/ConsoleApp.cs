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
            var inventory = new Composite("Inventory");
            var weaponbag = new Composite("Armory");
            weaponbag.AddComponent(new Weapon("couteau", 12));

            inventory.AddComponent(weaponbag);


            var all_leafs = new List<IComponent>();
            inventory.LoadLeafs(all_leafs);

            foreach (var leaf in all_leafs)
            {
                Console.WriteLine($"{leaf.Name}");
            }

        }
    }
}
