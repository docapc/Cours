using CompleteDemo.Entities;
using CompleteDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompleteDemo.Persistance
{
    public class UserRepository : IUserRepository
    {
        private DbContext SqlContext { get; }

        public UserRepository(DbContext sqlContext)  // Passer un DbContext pour éviter le couplage avec notre objet SqlDbContext créé dans le repo
        {
            SqlContext = sqlContext;
        }

        public UserEntity GetSingle(short id)
        {
            return SqlContext.Set<UserEntity>().SingleOrDefault(user => user.UserId == id);
        }

        public IList<UserEntity> GetBestUsers()
        {
            throw new NotImplementedException();
        }

        public TimeSpan GetOlderAge()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAllUser()
        {
            return SqlContext.Set<UserEntity>().ToList();
        }
    }
}
