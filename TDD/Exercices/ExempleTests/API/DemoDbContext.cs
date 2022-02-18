using Microsoft.EntityFrameworkCore;

namespace API
{
    public class DemoDbContext : DbContext
    {
        public DbSet<DemoEntity> DemoEntities { get; set; }
        public DemoDbContext(DbContextOptions options) : base(options)
        {
        }



    }
}
