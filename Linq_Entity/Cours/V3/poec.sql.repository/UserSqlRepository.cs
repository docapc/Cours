using Microsoft.EntityFrameworkCore;
using poec.sql.dtos;
using poec.sql.repository.Dtos;

namespace poec.sql.repository;

public class UserSqlRepository
{
    private SqlDbContext SqlContext { get; }

    public UserSqlRepository(SqlDbContext sqlContext)
    {
        SqlContext = sqlContext;
    }

    #region CRUD

    public UserSqlDto Add(UserSqlDto userSqlDto)
    {
        UserSqlDto entity = SqlContext.Add(userSqlDto).Entity;
        SqlContext.SaveChanges();

        return entity;
    }

    //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/concepts/linq/
    /// <summary>
    /// Récupère le seul élément qui a pour id le paramètre passé
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <returns></returns>
    public UserSqlDto? Get(short id)
    {
        return SqlContext.Set<UserSqlDto>()
                         .SingleOrDefault(user => user.UserId == id);
    }

    public IList<UserSqlDto> GetAll()
    {
        return SqlContext.Set<UserSqlDto>().ToList();
    }

    public IList<UserSqlDto> GetPredicate(Func<UserSqlDto, bool> predicate)
    {
        return SqlContext.Set<UserSqlDto>().Where(predicate).ToList();
    }

    public UserSqlDto? Update(UserSqlDto userSqlDto)
    {
        UserSqlDto? entity = Get(userSqlDto.UserId);
        if (entity == null)
            return null;

        entity.UserName = userSqlDto.UserName;
        entity.Login = userSqlDto.Login;
        entity.Birthday = userSqlDto.Birthday;

        SqlContext.Update(entity);
        SqlContext.SaveChanges();

        return entity;
    }

    public bool Delete(short id)
    {
        UserSqlDto? entity = Get(id);
        if (entity == null)
            return false;

        SqlContext.Set<UserSqlDto>().Remove(entity);

        return SqlContext.SaveChanges() >= 1; //prise en compte de la supression d'adresses (1 user + X adresses)
    }

    #endregion

    public StringWrapperDto? GetLongestName()
    {
        const string query = @"SELECT TOP(1) UserName AS Value
                               FROM [User]
                               ORDER BY LEN(UserName) DESC";

        //SqlContext.Database.ExecuteSqlRaw retourne le nombre de ligne affecté par la requête. On va donc l'utiliser pour un INSERT, UPDATE ou DELETE
        return SqlContext.Set<StringWrapperDto>().FromSqlRaw(query).FirstOrDefault();
    }

    public IList<UserSqlDto> GetBestUsers()
    {
        return GetPredicate(user => user.Birthday.Year == 1990).ToList();

        //return SqlContext.Set<UserSqlDto>().ToList().Where(user => user.Birthday.Year == 1990).ToList(); //=> NE JAMAIS FAIRE
    }

    public TimeSpan GetOlderAge()
    {
        //Max() ne peut s'appliquer que sur IEnumerable et pas IQueryable
        return SqlContext.Set<UserSqlDto>().Select(user => DateTime.Now.Date - user.Birthday).ToList().Max();
    }
}