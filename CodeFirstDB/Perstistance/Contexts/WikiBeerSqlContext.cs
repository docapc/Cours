using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contexts
{
    public class WikiBeerSqlContext : DbContext
    {
        // Tables
        public DbSet<BeerEntity> Beers { get; set; }
        public DbSet<BreweryEntity> Brewerys { get; set; }
        public DbSet<BeerColorEntity> BeerColors { get; set; }
        public DbSet<BeerStyleEntity> BeerStyles { get; set; }
        public DbSet<CountryEntity> Countrys { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<HopEntity> Hops { get; set; }
        public DbSet<AdditiveEntity> Additives { get; set; }
        public DbSet<CerealEntity> Cereals { get; set; }

        // Gestion
        private string ConnectionString { get; }

        //public WikiBeerSqlContext()  
        //{
        //}

        /// <summary>
        /// Nécessaire au bon fonctionnement avec l'API (au moins pour la migration)
        /// </summary>
        /// <param name="options"></param>
        //public WikiBeerSqlContext(DbContextOptions<WikiBeerSqlContext> options) : base(options)
        //{
        //}
        public WikiBeerSqlContext(DbContextOptions<WikiBeerSqlContext> options) : base(options)
        {
        }

        public WikiBeerSqlContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

		/// TODO Ici il faut tester si UseSqlServer à déja été appelé et donner ou non la chaine de connection.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=WikiBeer"); // pour la migration dans persitance
            //optionsBuilder.UseSqlServer(ConnectionString); // pour injection de dépendance
            //optionsBuilder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly("API")); // pour injection de dépendance
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Beers
            EntityTypeBuilder<BeerEntity> beerTypeBuilder = modelBuilder.Entity<BeerEntity>();
            beerTypeBuilder.HasMany(b => b.Ingredients)
                           .WithMany(i => i.Beers)
                           .UsingEntity(bi => bi.ToTable("BeerIngredient")); // permet de faire la table entity de manière automatique
            beerTypeBuilder.Navigation(b => b.Ingredients).AutoInclude(); //Chargement automatique de la propriété de dépendance

            //Si pas d'auto-include alors on doit charger en 2 fois
            //BeerEntity beer = GetById();
            //beer.Ingredients = GetIngredients(beer.BeerId);

            //Ingredients
            //EntityTypeBuilder<IngredientEntity> ingredientTypeBuilder = modelBuilder.Entity<IngredientEntity>();
            //ingredientTypeBuilder.HasMany(i => i.Beers)
            //                     .WithMany(b => b.Ingredients)
            //                     .UsingEntity(bi => bi.ToTable("BeersIngredients"));
            //ingredientTypeBuilder.Navigation(i => i.Beers).AutoInclude();
            EntityTypeBuilder<IngredientEntity> ingredientTypeBuilder = modelBuilder.Entity<IngredientEntity>();
            ingredientTypeBuilder.Property("Discriminator").HasMaxLength(50);

            EntityTypeBuilder<HopEntity> hopTypeBuilder = modelBuilder.Entity<HopEntity>();
            hopTypeBuilder.HasDiscriminator<string>(typeof(HopEntity).Name);

            // BeersIngredients --> plus besoin car on charge directement la liste d'ingrédients dans la bière (et inversement) sans passer par la table d'association
            //EntityTypeBuilder<BeerIngredientEntity> beerIngredientTypeBuilder = modelBuilder.Entity<BeerIngredientEntity>();
            //beerIngredientTypeBuilder.HasKey(bi => new { bi.BeerId, bi.IngredientId });
            //beerIngredientTypeBuilder.HasOne(bi => bi.IngredientId).WithOne();
            //beerIngredientTypeBuilder.Navigation(beer => beer.Ingredients).AutoInclude();
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
