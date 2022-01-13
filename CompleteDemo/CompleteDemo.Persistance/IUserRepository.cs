using CompleteDemo.Entities;
using CompleteDemo.Models;
using System;
using System.Collections.Generic;

namespace CompleteDemo.Persistance
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> GetAllUser();


        UserEntity GetSingle(short id);

        IList<UserEntity> GetBestUsers();
        TimeSpan GetOlderAge();
    }
}
