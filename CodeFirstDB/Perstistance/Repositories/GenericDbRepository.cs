using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perstistance.Repositories
{
    public class GenericDbRepository<T> : IGenericDbRepository<T> where T : class, IEntity, new()
    {
        public DbContext Context { get; } // public pour pouvoir être appelé dans un controller (et satisfaire à l'interface)

        public GenericDbRepository(DbContext context)
        {
            Context = context;
        }

        public T Create(T entityToCreate)
        {
            T entity = Context.Add(entityToCreate).Entity;
            Context.SaveChanges(); // Enregistre les changements en base
            return entity;
        }

        public IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T? GetById(Guid id)
        {
            return Context.Set<T>().SingleOrDefault(entity => entity.Id == id);
        }

        public bool DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }  
    }
}
