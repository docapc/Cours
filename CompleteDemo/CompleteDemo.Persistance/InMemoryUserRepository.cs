using AutoFixture;
using CompleteDemo.Entities;
using CompleteDemo.Models;
using System;
using System.Collections.Generic;

namespace CompleteDemo.Persistance
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly Fixture _fixture = new Fixture();

        public IEnumerable<UserEntity> GetAllUser()
        {
            return _fixture.CreateMany<UserEntity>(20);
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