using poec.sql.dtos;

namespace poec.sql.repository
{
    public interface IUserRepository
    {
        public UserSqlDto? Add(UserSqlDto user);


        public UserSqlDto? GetSingle(short id);

        public IList<UserSqlDto> GetBestUsers();

        public TimeSpan GetOlderAge();
    }
}