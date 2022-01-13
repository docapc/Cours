using CompleteDemo.Dtos;
using CompleteDemo.Persistance;
using CompleteDemo.Wcf.Factories;
using System.Collections.Generic;

namespace CompleteDemo.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class UserService : IUserService
    {
        public IUserManager UserManager => new UserManager();

        public IEnumerable<UserDto> GetUsers()
        {
            return UserManager.GetAllUser().ToDto(); 
        }
    }
}
