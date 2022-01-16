using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("BeerStyle")]
    public class BeerStyleEntity
    {
        [Key]
        public Guid StyleId { get; set; }

        public string Name { get; set; }

        public BeerStyleEntity()
        {
        }

    }
}
