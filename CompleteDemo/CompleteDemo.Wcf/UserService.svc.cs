using CompleteDemo.Dtos;
using CompleteDemo.Entities;
using CompleteDemo.Persistance;
using CompleteDemo.Wcf.Factories;
using System.Collections.Generic;
using System.Linq;

namespace CompleteDemo.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService()
        {
            var dbContext = new SqlDbContext(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = PoecEntity; Integrated Security = True");
            dbContext.Database.EnsureCreated();
            _userRepository = new UserRepository(dbContext);
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _userRepository.GetAllUser().ToDto();
        }
    }
}
