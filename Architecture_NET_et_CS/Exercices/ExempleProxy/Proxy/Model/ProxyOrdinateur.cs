using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipme.Proxy.Model
{
    public class ProxyOrdinateur : IOrdinateur
    {
        private static List<User> _users = new List<User>(); // cache des utilisateurs ayant utilisé un proxy
        public static IEnumerable<User> Users
        {
            get { return _users; }
        }

        private User _user;

        private Ordinateur _ordinateur;

        public ProxyOrdinateur(User user)
        {
            _user = new User(user); // copie au lieu de passage par référence
            _users.Add(_user);
            _ordinateur = new Ordinateur(); 
        }


        public void DoSomeSensibleStuff()
        {
            
            //var actual_user = GetActualUser();
            
            if (CheckAccessRight())
            {
                Console.Write($"{_user.Name} : Accès accordé -> "); // On fait plus que du controle : on dérive vers le Decorator?
                 _ordinateur.DoSomeSensibleStuff();
            }
            else
            {
                Console.WriteLine($"{_user.Name} : Vous n'avez pas les droits d'accès (niveau {_user.LvlAccess} insuffisant)");
            }
        }

        private bool CheckAccessRight()
        {
            return _user.LvlAccess > 10;
        }

        //private User GetActualUser()
        //{
        //    return _users[_users.Count() - 1];
        //}

        //private bool CheckAccessRight()
        //{
        //    Console.WriteLine("mot de passe?");
        //    var response = Console.ReadLine();  
        //    return response == "mdp";
        //}


        ////private static List<string> _users_names = new List<string>(); // cache des utilisateurs
        ////private static List<User> _users = new List<User>();
        ////private User _user;

        //private Ordinateur _ordinateur;

        ////public ProxyOrdinateur(User user)
        //public ProxyOrdinateur()
        //{
        //    //_user = user;
        //    //_users.Add(user);
        //    //_user = new User(user);
        //    //_users.Add(_user);
        //    _ordinateur = new Ordinateur();
        //}


        //public void DoSomeSensibleStuff()
        //{
        //    //_users_names.Add();
        //    if (CheckAccessRight())
        //    {
        //        //_ordinateur = new Ordinateur(); // instanciation différée
        //        _ordinateur.DoSomeSensibleStuff();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Vous n'avez pas les droits d'accès");
        //    }
        //}

        ////private bool CheckAccessRight()
        ////{
        ////    return _user.LvlAccess > 10;
        ////}

        //private bool CheckAccessRight()
        //{
        //    Console.WriteLine("mot de passe?");
        //    var response = Console.ReadLine();
        //    return response == "mdp";
        //}

    }
}
