using AutoFixture;
using AutoMapper;
using System.Linq; 
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DemoBinding.Dtos;
using DemoBinding.Entities;
using DemoBinding.Persistance;
using DemonBinding.API.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DemoBinding.Api.Perf
{
    
    public class ControllerBenchmark
    {
        public UsersController UsersController { get; set; }

        public IGenericRepository<UserEntity> UserRepository { get; set; } 

        public IMapper Mapper { get; set; }

        public ILogger<UsersController> Logger { get; set; } = new NullLogger<UsersController>();

        public IFixture Fixture { get; set; }

        public List<UserDto> Users { get; set; }


        [GlobalSetup]
        public void Setup()
        {
            var dbContext = new DemoDbContext(new DbContextOptionsBuilder()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=demoDb;Trusted_Connection=True;MultipleActiveResultSets=true;")
                .Options); 
            UserRepository = new DbGenericRepository<UserEntity>(dbContext);
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(UsersController)));
            Mapper = new Mapper(configuration);
            UsersController = new UsersController(UserRepository, Mapper, Logger);
            Users = Fixture.CreateMany<UserDto>(100).ToList();
        }


        [Benchmark]
        public void GetSync()
        {

            UsersController.Get();
        }

        [Benchmark]
        public async Task GetAsync()
        {
            await UsersController.GetAsync(); 
        }

    }
}
