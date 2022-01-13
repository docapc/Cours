using AutoFixture;
using CompleteDemo.Models;
using System.Collections.Generic;

namespace CompleteDemo.Persistance
{
    public class UserManager : IUserManager
    {
        private readonly Fixture _fixture = new Fixture();

        public IEnumerable<User> GetAllUser()
        {
            return _fixture.CreateMany<User>(20);
        }
    }
}