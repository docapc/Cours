using CompleteDemo.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompleteDemo.Persistance
{
    public interface IUserRepository
    {

        UserEntity GetSingle(short id);

        IList<UserEntity> GetBestUsers();
        TimeSpan GetOlderAge();

    }
}
