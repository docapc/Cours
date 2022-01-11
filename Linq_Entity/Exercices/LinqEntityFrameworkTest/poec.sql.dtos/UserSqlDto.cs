namespace poec.sql.dtos;

public class UserSqlDto
{
    public short UserId { get; set; } // short -> int16 : entier 16 bit signé. smallint en sql
    //https://docs.microsoft.com/fr-fr/sql/t-sql/data-types/int-bigint-smallint-and-tinyint-transact-sql?view=sql-server-ver15
    //https://docs.microsoft.com/en-us/sql/t-sql/data-types/data-type-conversion-database-engine?view=sql-server-ver15
    //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings

    public string UserName { get; set; }

    public string? Login { get; set;} //? indique un type nullable

    public DateTime Birthday { get; set; }// différent de smalldatetime

    public UserSqlDto(short userId, string userName, string? login, DateTime birthday)
    {
        UserId = userId;
        UserName = userName;
        Login = Login;
        Birthday = birthday;
    }
}