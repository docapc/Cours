using CompleteDemo.Dtos;
using CompleteDemo.Persistance;
using System.Collections.Generic;
using System.ServiceModel;

namespace CompleteDemo.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IUserService
    {

        [OperationContract]
        IEnumerable<UserDto> GetUsers();

        // TODO: ajoutez vos opérations de service ici
    }
}
