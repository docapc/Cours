using Microsoft.EntityFrameworkCore;

namespace ProjectApp.Model
{
    public class ProjectAPIContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ProjectAPIContext(DbContextOptions<ProjectAPIContext> options) : base(options)
        {
        }

        public DbSet<Project> Project { get; set; }
    }
}
