using API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using AutoFixture;

namespace API.Tests
{
    public class DemoControllerTestUTMoq
    {
        private DemoController _demoController;
        private Mock<IDemoRepository> _repository;
        private readonly int _count;
        private readonly IFixture _fixture;
        public DemoControllerTestUTMoq()
        {
            _fixture = new Fixture();
            _count = 15;
            Init();
        }

        [TestInitialize]
        public void Init()
        {
            _repository = new Mock<IDemoRepository>();
            _demoController = new DemoController(_repository.Object);
        }

        [TestMethod]
        [TestCategory("UT")]
        public async Task TestDemoGetAll()
        {
            //Arrange 
            _repository.Setup(repo => repo.GetAll()).ReturnsAsync(_fixture.CreateMany<DemoEntity>(_count));
            //Action
            var demoEntitiesAction = await _demoController.Get();

            // Assert : version fluent assertion
            demoEntitiesAction.Should().NotBeNull();
            var okResult = demoEntitiesAction as OkObjectResult;
            okResult.Should().NotBeNull();
            var entities = okResult?.Value as IEnumerable<DemoEntity>;
            entities?.Count().Should().Be(_count);
        }

        [TestMethod]
        [TestCategory("UT")]
        
        public async Task TestDemoAdd()
        {
            //Arrange 
            var value = "value";
            _repository.Setup(repo => repo.Add(It.IsAny<DemoEntity>())).Returns(() => Task.FromResult(new DemoEntity() { Content = "value" }));
            // Action
            var demoEntitiesAction = await _demoController.Post("value");

            // Assert
            _repository.Verify(repo => repo.Add(It.IsAny<DemoEntity>()), Times.Once);
            // 
        }

        //[TestMethod]
        //[TestCategory("UT")]
        //[ExpectedException(typeof(Exception), "Exception du Mock GetAll")]
        //public async Task TestDemoGetAll_WithDatabaseError()
        //{
        //    //Arrange 
        //    var repo = new MockDemoRepositoryError();
        //    _demoController = new DemoController(repo);
        //    // Action
        //    var demoEntitiesAction = await _demoController.Get();

        //    // Assert
        //    // 
        //}
    }
}
