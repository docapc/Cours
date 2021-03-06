using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poec.sql.dtos;
using poec.sql.repository.Dtos;

namespace poec.sql.repository;

public class SqlDbContext : DbContext
{
    private string ConnectionString { get; }

    public SqlDbContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StringWrapperDto>().HasNoKey();

        EntityTypeBuilder<UserSqlDto> entityTypeBuilder = modelBuilder.Entity<UserSqlDto>();
        //entityTypeBuilder.HasMany(u => u.Addresses).WithOne(a => a.User); //équivalent à [ForeignKey("UserId")]
        entityTypeBuilder.Navigation(u => u.Addresses).AutoInclude(); //Chargement automatique de la propriété de dépendance

        EntityTypeBuilder<AddressSqlDto> addressEntityBuilder = modelBuilder.Entity<AddressSqlDto>();
        addressEntityBuilder.ToTable("Address").HasKey(a => a.AddressId);
        //addressEntityBuilder.HasOne(a => a.User).WithMany(u => u.Addresses);
        //addressEntityBuilder.Property(a => a.Address).HasColumnName("Address"); //équivalent à [Column("Address")]

        //si pas de clé
        //entityTypeBuilder.HasNoKey();
    }

    public override DbSet<TEntity> Set<TEntity>()
    {
        ChangeTracker.LazyLoadingEnabled = false;
        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        return base.Set<TEntity>();
    }
}