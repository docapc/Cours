using Microsoft.EntityFrameworkCore;
using ProjectWebApi.Dtos;

namespace ProjectWebApi.Model
{
    public class YourAPiContext : DbContext
    {
        public YourAPiContext(DbContextOptions<YourAPiContext> options): base(options)
        {
            // Ici pour initialiser les options
        }
        public DbSet<Project> Projects { get; set; }
    }
}
