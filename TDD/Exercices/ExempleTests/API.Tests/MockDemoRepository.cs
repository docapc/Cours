using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Tests
{
    public class MockDemoRepository : IDemoRepository
    {
        private readonly IFixture _fixture = new Fixture();
        public int _count { get; } = 15;

        public Task<DemoEntity> Add(DemoEntity demoEntity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<DemoEntity>> GetAll()
        {
            return await Task.FromResult(_fixture.CreateMany<DemoEntity>(_count));
        }

        public Task<DemoEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(DemoEntity demoEntity)
        {
            throw new NotImplementedException();
        }
    }
}
