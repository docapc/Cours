using Microsoft.AspNetCore.Mvc;

/// <summary>
/// 
/// </summary>
namespace ProjectWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")] // nom de la route
    public class WeatherForecastController : ControllerBase //si pas de [Route] spécifique On aura http.../api/WeatherForecast
    {

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Ici on a un logger pour le controller fait par injection de dépendance. C'est asp Net qui gère l'injection de
        /// dépendance ici. TT est géré dans un fichiers de configuration. Le logLevel est géré dans le appsetting.json.
        /// On peut également injecter un repo EF directement ici.
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPut("{page_id}")]
        public void Post(int page_id, [FromBody] WeatherForecast weatherForecast)
        {

        }

        // Il existe aussi un [FromQuerry], [FromHeader] pour spécifier l'origine de la donnéee dans la requête
        [HttpPut("detail")]
        public IEnumerable<WeatherForecast> Post( [FromBody] IEnumerable<WeatherForecast> weatherForecast) 
        {
            //return 42; // le contenue de la réponse est forcément dans le body de cette dernière.
            return weatherForecast; // le contenue de la réponse est forcément dans le body de cette dernière.
        }

    }
}