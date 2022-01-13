using CompleteDemo.Entity;
using System.Linq;

namespace CompleteDemo.Persistance
{
    public class UserSqlRepository : IUserRepository
    {
        private DbContext SqlContext { get; }

        public UserSqlRepository(DbContext sqlContext)  // Passer un DbContext pour éviter le couplage avec notre objet SqlDbContext créé dans le repo
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

    }
}