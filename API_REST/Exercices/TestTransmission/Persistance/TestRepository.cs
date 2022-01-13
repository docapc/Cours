using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class TestRepository : ITestRepository
    {
        private DbContext Context { get; } // Il vaut mieux utiliser un DbContext plûtot qu'un SqlDbContext
                                              // pour généraliser le Repository (et pouvoir changer de type de context)

        public TestRepository(DbContext context)
        {
            Context = context;
        }

        public TestEntity? Add(TestEntity user) 
        {
            TestEntity entity = Context.Add(user).Entity; // Entity permet de récupérer l'entité passé par cette entrée
            Context.SaveChanges(); // Permet de valider la transaction [qu'on appelle commit](tant que l'on ne fait pas le save change, le DbContext n'applique
                                      // pas les modification à la BDD) -> Principe de transaction (possible aussi en SQL pure).
                                      // En cas d'erreur le DbContext fait un roll back depuis le dernier SaveChanges 
            return entity; // entity est un objet tracké par le DbContext.
        }

        public IEnumerable<TestEntity> GetAllUser()
        {
            return Context.Set<TestEntity>().ToList();
        }


        public TestEntity? GetSingle(short id)
        {
            return Context.Set<TestEntity>()
                             .SingleOrDefault(user => user.UserId == id);
        }

    }
}
