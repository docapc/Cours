using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAndList.Models
{
    internal class UserList<TUser> // TUser est un alias de la classe que l'on prendra en entré
        where TUser : class, new() // TUser sera une classe (class), que l'on pourra instancier sans paramètre [new ()] (à creuser sa)
                                   // si l'on ne donne pas ces conditions on pourra accepter n'importe quelle objet
    {
        public TUser GetUser()
        {
            return new TUser();
        }
    }
}
