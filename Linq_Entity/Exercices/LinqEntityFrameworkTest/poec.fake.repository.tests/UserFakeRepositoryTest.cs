using poec.sql.dtos;
using Xunit;

namespace poec.fake.repository.tests
{
    public class UserFakeRepositoryTest
    {
        private UserFakeRepository Repo { get; } = new UserFakeRepository();

        [Fact]
        public void GetTest()
        {
            //Arrange : création du jeu de donné
            short id = 1;

            //Action : Action à tester
            UserSqlDto? userSqlDto = Repo.GetSingle(id);

            //Assert : Assertion a passer pour réussir le test
            Assert.NotNull(userSqlDto);
            Assert.Equal(userSqlDto.UserId, id);
        }
    }
}