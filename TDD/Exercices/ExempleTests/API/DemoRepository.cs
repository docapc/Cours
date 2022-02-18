using Microsoft.EntityFrameworkCore;

namespace API
{
    public class DemoRepository : IDemoRepository
    {
        public DbContext Context { get; }
        public DemoRepository(DbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<DemoEntity>> GetAll()
        {
            return await Context.Set<DemoEntity>().ToListAsync();
        }

        public async Task<DemoEntity> GetById(int id)
        {
            return await Context.Set<DemoEntity>().FindAsync(id);
        }

        public async Task<DemoEntity> Add(DemoEntity entity)
        {
            await Context.Set<DemoEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(DemoEntity entity)
        {
            Context.Set<DemoEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var demo = new DemoEntity() { Id = id};
            Context.Set<DemoEntity>().Remove(demo);
            await Context.SaveChangesAsync();
        }

    }
}
