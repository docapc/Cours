using poec.sql.dtos;
using Xunit;

namespace poec.sql.repository.tests;

public class SqlRepositoryTest
{
    private SqlDbContext SqlDbContext { get; }
    private UserSqlRepository UserSqlRepository { get; }

    public SqlRepositoryTest()
    {
        // ici la connection string Data Source = adresse serveur sql (. = machine local mais ne fonctionne pas toujours (le cas ici))
        // Initial Catalog = bdd de connexion par defaut
        // Integrated Security = True -> r�gle de s�curit� utilisateur windows
        SqlDbContext = new SqlDbContext(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PoecEntity;Integrated Security=True"); // On peut pr�ciser User et Password � la suite au besoin
        // @ avant la string pour utiliser les caract�re r�serv� [comme \]. Sinon il faut doubler l'antislash
        UserSqlRepository = new UserSqlRepository(SqlDbContext);
    }

    [Fact]
    public void GetTest()
    {
        //Arrange
        const short id = 1;

        //Action
        UserSqlDto? userSqlDto = UserSqlRepository.GetSingle(id);

        //Assert
        Assert.NotNull(userSqlDto);
        Assert.Equal(userSqlDto?.UserId, id); //(?. r�cup�re une valeur que si il n'est pas nulle)
        //Assert.Equal(userSqlDto.UserId, id); 
    }

}



