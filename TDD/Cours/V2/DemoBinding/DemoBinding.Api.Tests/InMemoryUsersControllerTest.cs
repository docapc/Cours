using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoFixture;
using AutoMapper;
using DemoBinding.Dtos;
using DemoBinding.Entities;
using DemoBinding.Persistance;
using DemonBinding.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoBinding.Api.Tests
{
    [TestClass]
    public class InMemoryUsersControllerTest
    {
        private UsersController UsersController { get; set; }

        private IGenericRepository<UserEntity> UserRepository { get; set; }

        private IMapper Mapper { get; set; }

        private ILogger<UsersController> Logger { get; set; } = new NullLogger<UsersController>(); 

        private Fixture Fixture { get; set; } = new Fixture();

        private IEnumerable<UserEntity> CleanUserBdd { get; set; }

        private DemoDbContext InMemoryDbContext { get; set; }

        public InMemoryUsersControllerTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(UsersController)));
            Mapper = new Mapper(configuration);
            CleanUserBdd = Fixture.CreateMany<UserEntity>(10);
        }

        [TestInitialize]
        public void InitTest()
        {
            UsersController = new UsersController(UserRepository, Mapper,Logger);
            //var option = new DbContextOptionsBuilder()
            //    .UseInMemoryDatabase("myDataBase").Options;
            //InMemoryDbContext = new DemoDbContext(option);
            //InMemoryDbContext.Database.Migrate(); // peut poser des problèmes à cause de la compatibilité entre SqlServer et SqLite
            //InMemoryDbContext.Database.EnsureCreated(); // on refait la base de donné -> plus de problèmles de compatibilité
                                                          // mais attention aux différences de comportement.

            UserRepository = new DbGenericRepository<UserEntity>(InMemoryDbContext);
            InMemoryDbContext.AddRange(CleanUserBdd);
            InMemoryDbContext.SaveChanges();
        }

        [TestMethod]
        public void TestGetAllUsers_Ok()
        {
            //Arrange

            //Act
            var result = UsersController.Get();

            //Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull("if null response != 200"); // on peut donner du texte
            var entities = okResult?.Value as IEnumerable<UserDto>;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(10);
            // il existe aussi BeEquivalentTo qui fait de la comparaison champ à champ. (AreEqual compare les références aux
            // objet à moins d'avoir override la méthode Equals)
        }


        [TestMethod]
        public void TestGetAllUsers_NullRepository()
        {
            //Arrange
            UsersController = new UsersController(null, Mapper, Logger); 


            //Act
            var result = UsersController.Get();

            //Assert
            var statusResult = result as StatusCodeResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError); 
        }
    }
}