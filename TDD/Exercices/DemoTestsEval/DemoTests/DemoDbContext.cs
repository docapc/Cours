using Microsoft.EntityFrameworkCore;

namespace DemoTests
{
    public class DemoDbContext : DbContext
    {
        public DbSet<DemoEntity> DemoEntities { get; set; }

        public DemoDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
