using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("User")]
    public class TestEntity
    {
        [Key]
        public short UserId { get; set; }

        public string UserName { get; set; }

        public string Login { get; set; }

        public DateTime Birthday { get; set; }

        public TestEntity(short userId, string userName, string login, DateTime birthday)
        {
            UserId = userId;
            UserName = userName;
            Login = login;
            Birthday = birthday;
        }
    }    
}