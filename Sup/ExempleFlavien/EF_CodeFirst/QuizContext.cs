using Microsoft.EntityFrameworkCore;

using Model;

namespace EF_CodeFirst
{
    public class QuizContext : DbContext
    {
        public DbSet<ThemeEx> ThemeEx { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Reponse> Reponses { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<UserQuizz> UserQuizz { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test; Trusted_Connection=True",
                builder => builder.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThemeEx>(eb =>
            {
                eb.HasKey(t => t.Id)
                  .HasName("PrimaryKey_ThemeId");
                
                eb.Property(t => t.Id)
                  .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Question>(eb =>
            {
                eb.HasKey(q => q.Id)
                  .HasName("PrimaryKey_QuestionId");
                eb.Property(q => q.Id)
                  .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Reponse>(eb =>
            {
                eb.HasKey(r => r.Id)
                  .HasName("PrimaryKey_ReponseId");
                eb.Property(q => q.Id)
                  .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Links>(eb =>
            {
                eb.HasKey(l => l.Id)
                  .HasName("PrimaryKey_LinksId");
                eb.Property(q => q.Id)
                  .ValueGeneratedOnAdd();

            });
            modelBuilder.Entity<UserQuizz>(eb =>
            {
                eb.HasKey(u => u.Id)
                  .HasName("PrimaryKey_UserQuizzId");
                eb.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            });

            modelBuilder.Entity<ThemeEx>()
                        .HasMany(t => t.Questions);
            modelBuilder.Entity<ThemeEx>()
                        .HasMany(t => t.UserQuizz)
                        .WithMany(u => u.ThemeEx);
            modelBuilder.Entity<Question>()
                        .HasMany(q => q.Reponses);
            modelBuilder.Entity<Question>()
                        .HasMany(q => q.UserQuizz)
                        .WithMany(u => u.Question);
            modelBuilder.Entity<Reponse>()
                        .HasMany(r => r.UserQuizz)
                        .WithMany(u => u.Reponse);
            modelBuilder.Entity<Links>()
                        .HasMany(l => l.UserQuizz)
                        .WithMany(u => u.Links);

            modelBuilder.Entity<Links>()
                        .HasOne(r => r.Reponse)
                        .WithMany(l => l.Links)
                        .HasConstraintName("Link_In_Response");
            modelBuilder.Entity<Reponse>()
                         .HasOne(q => q.Question)
                         .WithMany(r => r.Reponses)
                         .HasConstraintName("Reponses_In_Question");
            modelBuilder.Entity<Question>()
                         .HasOne(t => t.ThemeEx)
                         .WithMany(q => q.Questions)
                         .HasConstraintName("Question_In_Theme");
        }

    }
}