namespace API
{
    public interface IDemoRepository
    {
        Task<IEnumerable<DemoEntity>> GetAll();
        Task<DemoEntity> GetById(int id);
        Task<DemoEntity> Add(DemoEntity demoEntity);
        Task Update(DemoEntity demoEntity);
        Task Delete(int id);
    };
}
