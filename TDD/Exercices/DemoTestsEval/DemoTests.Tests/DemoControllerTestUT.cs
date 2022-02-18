using AutoFixture;
using DemoTests.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTests.Tests
{
    public class DemoControllerTestUT
    {
        private Mock<DemoDbContext> _context;
        private DemoController _controller;
        private IFixture _fixture;
        private IEnumerable<DemoEntity> StubEntities { get; set; }
        private DemoEntity StubEntity { get; set; }

        public DemoControllerTestUT()
        {
            _fixture = new Fixture();
            Init();                        
        }

        [TestInitialize]
        public void Init()
        {
            _context = new Mock<DemoDbContext>();
            _controller = new DemoController(_context.Object);
            StubEntities = _fixture.CreateMany<DemoEntity>(5);
            StubEntity = _fixture.Create<DemoEntity>();
        }

        
        [TestCategory("UT")]
        [TestMethod]
        public void TestDemoGetAll_Ok200()
        {
            // Arrange
            //_context.Setup(c => c.Set<DemoEntity>().ToList()).Returns(StubEntities); -> compliqué sa

            // Action

            // Assert 
        }

    }
}
