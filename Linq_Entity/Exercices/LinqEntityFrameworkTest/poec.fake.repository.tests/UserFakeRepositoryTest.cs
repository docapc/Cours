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
            //Arrange : cr�ation du jeu de donn�
            short id = 1;

            //Action : Action � tester
            UserSqlDto? userSqlDto = Repo.GetSingle(id);

            //Assert : Assertion a passer pour r�ussir le test
            Assert.NotNull(userSqlDto);
            Assert.Equal(userSqlDto.UserId, id);
        }
    }
}