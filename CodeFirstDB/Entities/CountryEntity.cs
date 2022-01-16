using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Country")]
    public class CountryEntity
    {
        [Key]
        public Guid CountryId { get; set; }

        public string Name { get; set; }

        public CountryEntity()
        {
        }

    }
}
