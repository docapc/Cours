using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DemoBinding.Dtos;
using DemonBinding.API.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DemoBinding.Api.Perf
{
    public class ForEachBenchMark
    {

        public ILogger<UsersController> Logger { get; set; } = new NullLogger<UsersController>();

        public IFixture Fixture { get; set; } = new Fixture(); 

        public List<UserDto> Users { get; set; }


        [GlobalSetup]
        public void Setup()
        {
            Users = Fixture.CreateMany<UserDto>(100000).ToList();
        }

        [Benchmark]
        public void ForEachSimple()
        {
            foreach (var userDto in Users)
            {
                Logger.LogInformation(userDto.Name);
            }
        }

        [Benchmark]
        public void ForEachLinq()
        {
            Users.ForEach(user => Logger.LogInformation(user.Name));
        }

        [Benchmark]
        public void ForEachLinqParallel()
        {
            Parallel.ForEach(Users, user =>
            {
                Logger.LogInformation(user.Name);
            });
        }
    }
}
