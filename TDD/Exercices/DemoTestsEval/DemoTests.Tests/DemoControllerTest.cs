using AutoFixture;
using DemoTests.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DemoTests.Tests
{
    [TestClass]
    public class DemoControllerTest
    {

        private DemoDbContext _context;
        private DemoController _controller;
        private readonly IFixture _fixture;
        public int Count { get; set; }

        public DemoControllerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Demo.db");
            _context = new DemoDbContext(optionsBuilder.Options);
            _controller = new DemoController(_context);
            _fixture = new Fixture();
            Count = 5;
        }

        [TestInitialize]
        public void Init()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var entities = _fixture.CreateMany<DemoEntity>(Count);
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task TestDemoGetAll_Ok200_IEnumerable_DemoEntity()
        {
            //Arrange

            //Action
            var resultObject = await _controller.Get();
            //Assert 
            resultObject.Should().NotBeNull();
        
            var okResult = resultObject as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
        
            var entities = okResult?.Value as IEnumerable<DemoEntity>;
            entities.Should().NotBeNull();
            entities?.Count().Should().Be(Count);           
        }

        [TestMethod]
        public async Task TestDemoGet_Ok200_DemoEntity()
        {
            //Arrange
            var id = 1;
            //Action
            var resultObject = await _controller.Get(id);
            //Assert 
            resultObject.Should().NotBeNull();
        
            var okResult = resultObject as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);

            //var entity = okResult.Value as DemoEntity;
            //entity.Should().NotBeNull();
            //entity.Id.Should().Be(id);
        }

        [TestMethod]
        public async Task TestDemoPost_Create201_DemoEntity()
        {
            //Arrange
            var value = "testPost";
            //Action
            var createdObject = await _controller.Post(value);
            //Assert 
            createdObject.Should().NotBeNull();
        
            var createdResult = createdObject as CreatedAtActionResult;
            createdResult.Should().NotBeNull();
            createdResult.StatusCode.Should().Be((int)HttpStatusCode.Created);

            var entity = createdResult?.Value as DemoEntity;
            entity.Should().NotBeNull();
            entity.Content.Should().BeEquivalentTo(value);
            entity.Id.Should().NotBe(0);
        }

        [TestMethod]
        [Ignore]
        public async Task TestDemoPut_Ok200()
        {
            //Arrange
            var value = "testPut";
            var id = 4;
            //Action
            var resultObject = await _controller.Put(id,value);
            //Assert 
            resultObject.Should().NotBeNull();

            var okResult = resultObject as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);

            //var entity = _context.Set<DemoEntity>().Find(id);
            //entity.Should().NotBeNull();
            //entity.Content.Should().BeEquivalentTo(value);
            //entity.Id.Should().Be(id);
        }

        [TestMethod]
        [Ignore]
        public async Task TestDemoDelete_Ok200()
        {
            //Arrange

            //Action
            var resultObject = await _controller.Delete(1);
            //Assert 
            resultObject.Should().NotBeNull();
            
            var okResult = resultObject as OkResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
            
        }

    }
}