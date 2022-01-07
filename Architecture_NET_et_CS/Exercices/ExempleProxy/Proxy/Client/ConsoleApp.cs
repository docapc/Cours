using Ipme.Proxy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.Proxy.Main
{
    internal class ConsoleApp
    {
        public void Run()
        {
            //var user = new User("User lambda", 4);
            //var proxy_pc = new ProxyOrdinateur();
            //var pc = new Ordinateur();
            //user.UseOrdinateur(pc); // pas de demande de mdp
            //user.UseOrdinateur(proxy_pc); // demande de mdp

            //var user_lambda = new User("User lambda", 2);
            //var super_lambda = new User("Super User", 12);
            //var proxy_pc = new ProxyOrdinateur();
            //user_lambda.UseOrdinateur(new ProxyOrdinateur());
            //super_lambda.UseOrdinateur(new ProxyOrdinateur());
            //user_lambda.UseOrdinateur(new ProxyOrdinateur(user_lambda)); // va se faire jeter
            //super_lambda.UseOrdinateur(new ProxyOrdinateur(super_lambda)); // va passer

            var user_lambda = new User("User lambda", 2);
            var user_super = new User("Super User", 12);

            var proxy1 = new ProxyOrdinateur(user_lambda);
            var proxy2 = new ProxyOrdinateur(user_super);
            proxy1.DoSomeSensibleStuff();
            proxy2.DoSomeSensibleStuff();
            proxy1.DoSomeSensibleStuff(); // ne rajoutera pas une deuxième fois le nom dans la liste du cache
            foreach (var user in ProxyOrdinateur.Users)
            {
                Console.WriteLine($"Accès tenté par {user.Name}, niveau d'accréditation {user.LvlAccess}");
            }

        }
    }
}
