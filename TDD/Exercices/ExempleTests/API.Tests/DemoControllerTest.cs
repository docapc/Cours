using API.Controllers;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Tests
{
    [TestClass]
    public class DemoControllerTest
    {
        private readonly DemoController _demoController;
        private readonly Fixture _fixture;
        private readonly DemoDbContext _context;
        private readonly IDemoRepository _repository;
        private readonly int _count;

        public DemoControllerTest()
        {
            _count = 15;
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Demo.db");
            _context = new DemoDbContext(optionsBuilder.Options);
            _repository = new DemoRepository(_context);
            _demoController = new DemoController(_repository);
        }

        [TestInitialize]
        public void InitData()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var entities = _fixture.CreateMany<DemoEntity>(15);
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task TestDemoGetAll()
        {
            //Arrange 

            //Action
            var demoEntitiesAction = await _demoController.Get();

            // Assert : version mstest
            //Assert.IsNotNull(demoEntitiesAction);
            //var okResult = demoEntitiesAction as OkObjectResult;
            //Assert.IsNotNull(okResult);
            //var entities = okResult.Value as IEnumerable<DemoEntity>;
            //Assert.AreEqual(entities.Count(), _count);

            // Assert : version fluent assertion
            demoEntitiesAction.Should().NotBeNull();
            var okResult = demoEntitiesAction as OkObjectResult;
            okResult.Should().NotBeNull();
            var entities = okResult?.Value as IEnumerable<DemoEntity>;
            entities?.Count().Should().Be(_count);
        }
    }
}