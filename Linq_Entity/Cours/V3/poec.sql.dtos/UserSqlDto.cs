using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poec.sql.dtos;

[Table("User")]
//[KeyLess] //équivalent à entityTypeBuilder.HasNoKey();, nécessite de référencer EFCore 5.0+
public class UserSqlDto
{
    [Key]
    public short UserId { get; set; }
    //https://docs.microsoft.com/fr-fr/sql/t-sql/data-types/int-bigint-smallint-and-tinyint-transact-sql?view=sql-server-ver15
    //https://docs.microsoft.com/en-us/sql/t-sql/data-types/data-type-conversion-database-engine?view=sql-server-ver15
    //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings

    [StringLength(50)] //Permet de limiter la longueur du champ varchar
    public string UserName { get; set; }

    //[Column("Pseudo")] //Si nom de colonne différent
    [MaxLength(50)] //Permet de limiter la longueur du champ varchar
    public string? Login { get; set; }
    
    public DateTime Birthday { get; set; }

    [ForeignKey("UserId")] //Nom de la propriété de la clé étrangère 
    public ICollection<AddressSqlDto> Addresses { get; set; }//https://docs.microsoft.com/fr-fr/ef/core/modeling/relationships?tabs=fluent-api-simple-key%2Csimple-key%2Cfluent-api

    /// <summary>
    /// Constructeur par défaut utilisé par EF Core uniquement
    /// </summary>
    private UserSqlDto()
    {
    }

    public UserSqlDto(short userId, string userName, string? login, DateTime birthday, List<AddressSqlDto> addresses)
    {
        Addresses = addresses;
        UserId = userId;
        UserName = userName;
        Login = login;
        Birthday = birthday;
    }
}