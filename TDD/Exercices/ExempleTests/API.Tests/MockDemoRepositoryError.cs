using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Tests
{
    public class MockDemoRepositoryError : MockDemoRepository
    {
        public override async Task<IEnumerable<DemoEntity>> GetAll()
        {
            throw new Exception("Exception du Mock GetAll");
        }
    }
}
