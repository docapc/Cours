using CompleteDemo.Models;
using System.Collections.Generic;

namespace CompleteDemo.Persistance
{
    public interface IUserManager
    {
        IEnumerable<User> GetAllUser();
    }
}
