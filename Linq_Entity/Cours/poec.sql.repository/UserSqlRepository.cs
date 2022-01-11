using poec.sql.dtos;

namespace poec.sql.repository;

public class UserSqlRepository
{
    private SqlDbContext SqlContext { get; }

    public UserSqlRepository(SqlDbContext sqlContext)
    {
        SqlContext = sqlContext;
    }

    public UserSqlDto? Add(UserSqlDto user) // on récupère
    {
        UserSqlDto entity = SqlContext.Add(user).Entity; // Entity permet de récupérer l'entité passé par cette entrée
        SqlContext.SaveChanges(); // Permet de valider la transaction [qu'on appelle commit](tant que l'on ne fait pas le save change, le DbContext n'applique
                                  // pas les modification à la BDD) -> Principe de transaction (possible aussi en SQL pure).
                                  // En cas d'erreur le DbContext fait un roll back depuis le dernier SaveChanges 
        return entity; // entity est un objet tracké par le DbContext.
            
    }



    //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/concepts/linq/
    /// <summary>
    /// Récupère le seul élément qui a pour id le paramètre passé
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <returns></returns>
    public UserSqlDto? GetSingle(short id)
    {
        return SqlContext.Set<UserSqlDto>()
                         .SingleOrDefault(user => user.UserId == id);
    }

    public IList<UserSqlDto> GetBestUsers()
    {
        throw new NotImplementedException();
    }

    public TimeSpan GetOlderAge()
    {
        throw new NotImplementedException();
        //var aa = SqlContext.Set<UserSqlDto>().Where();
        //var aa = SqlContext.Set().Where()
    }



}



