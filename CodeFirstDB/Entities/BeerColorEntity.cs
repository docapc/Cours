using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("BeerColor")]
    public class BeerColorEntity
    {
        [Key]
        public Guid ColorID { get; set; }

        public string Name { get; set; }

        public BeerColorEntity()
        {
        }
    }
}
