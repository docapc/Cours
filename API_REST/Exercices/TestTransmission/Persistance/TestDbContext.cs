using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class TestDbContext : DbContext
    {
        private string ConnectionString { get; }

        public DbSet<TestEntity> Tests { get; set; } // Normalement propre à ASP donc l'API

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        //public TestDbContext(string connectionString)
        //{
        //    ConnectionString = connectionString;
        //}

        // Devrait être inutile au vu du programme API
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer(ConnectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // sert pour la suite et est de toute facon nécessaire pour utiliser les [Tables], [Key]
            //EntityTypeBuilder<TestEntity> entityTypeBuilder = modelBuilder.Entity<TestEntity>();

            //[Column("Pseudo")] //Si nom de colonne différent
            //entityTypeBuilder.Property(u => u.Login).HasColumnName("Pseudo");

            //si pas de clé
            //entityTypeBuilder.HasNoKey();

            //équivalent à [Table("User")] dans le SqlDto
            //entityTypeBuilder.ToTable("User");
            //équivalent à [Key] dans le SqlDto
            //userCatalog.HasKey(u => u.UserId);
        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return base.Set<TEntity>();
        }
    }
}