using API.Controllers;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Tests
{
    public class DemoControllerTestUT 
    {
        private DemoController _demoController;
        private IDemoRepository _repository;
        private readonly int _count;

        public DemoControllerTestUT()
        {           
            _count = 15;
            Init();
        }

        [TestInitialize]
        public void Init()
        {
            _repository = new MockDemoRepository();
            _demoController = new DemoController(_repository);
        }

        [TestMethod]
        [TestCategory("UT")]
        public async Task TestDemoGetAll()
        {
            //Arrange 

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
        [ExpectedException(typeof(Exception), "Exception du Mock GetAll")]
        public async Task TestDemoGetAll_WithDatabaseError()
        {
            //Arrange 
            var repo = new MockDemoRepositoryError();
            _demoController = new DemoController(repo);
            // Action
            var demoEntitiesAction = await _demoController.Get();

            // Assert
            // 
        }
    }
}
