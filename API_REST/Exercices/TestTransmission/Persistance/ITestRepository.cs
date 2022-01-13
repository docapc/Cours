using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Pour l'accès direct à la BDD
/// </summary>
namespace Persistance
{
    internal interface ITestRepository
    {
        IEnumerable<TestEntity> GetAllUser();

        TestEntity GetSingle(short id);
    }
}
