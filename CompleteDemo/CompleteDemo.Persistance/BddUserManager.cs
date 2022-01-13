using CompleteDemo.Entities;
using CompleteDemo.Models;
using System;
using System.Collections.Generic;

namespace CompleteDemo.Persistance
{
    public class BddUserManager : IUserRepository
    {
        public IEnumerable<UserEntity> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public IList<UserEntity> GetBestUsers()
        {
            throw new NotImplementedException();
        }

        public TimeSpan GetOlderAge()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetSingle(short id)
        {
            throw new NotImplementedException();
        }
    }
}
