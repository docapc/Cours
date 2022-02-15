// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;

namespace DemoBinding.Api.Perf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ForEachBenchMark>();
            
            //using var httpClient = new HttpClient();

            //var step = Step.Create("fetchUsers", async context =>
            //{
            //    var response = await httpClient.GetAsync("https://localhost:7167/api/Users/Async");

            //    return response.IsSuccessStatusCode
            //        ? Response.Ok()
            //        : Response.Fail();
            //});

            //var scenario = ScenarioBuilder
            //    .CreateScenario("UsersAll", step)
            //    .WithWarmUpDuration(TimeSpan.FromSeconds(5))
            //    .WithLoadSimulations(
            //        Simulation.RampConstant( 1000, during: TimeSpan.FromSeconds(50))
            //    );

            //NBomberRunner
            //    .RegisterScenarios(scenario)
            //    .Run();
        }
    }
}
