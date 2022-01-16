using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Brewery")]
    public class BreweryEntity
    {
        [Key]
        //Primary Key
        public Guid BreweryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CountryEntity Country { get; set; }

        public BreweryEntity()
        {
        }
    }
}
