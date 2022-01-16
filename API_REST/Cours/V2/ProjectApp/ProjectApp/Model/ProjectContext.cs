using Microsoft.EntityFrameworkCore;
using ProjectApp.Model;

namespace ProjectApp
{
    public class ProjectContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Project> Project { get; set; }

    }
}
