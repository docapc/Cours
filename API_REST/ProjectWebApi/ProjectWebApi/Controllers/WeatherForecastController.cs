using Microsoft.AspNetCore.Mvc;

/// <summary>
/// 
/// </summary>
namespace ProjectWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")] // nom de la route
    public class WeatherForecastController : ControllerBase //si pas de [Route] sp�cifique On aura http.../api/WeatherForecast
    {

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Ici on a un logger pour le controller fait par injection de d�pendance. C'est asp Net qui g�re l'injection de
        /// d�pendance ici. TT est g�r� dans un fichiers de configuration. Le logLevel est g�r� dans le appsetting.json.
        /// On peut �galement injecter un repo EF directement ici.
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

        // Il existe aussi un [FromQuerry], [FromHeader] pour sp�cifier l'origine de la donn�ee dans la requ�te
        [HttpPut("detail")]
        public IEnumerable<WeatherForecast> Post( [FromBody] IEnumerable<WeatherForecast> weatherForecast) 
        {
            //return 42; // le contenue de la r�ponse est forc�ment dans le body de cette derni�re.
            return weatherForecast; // le contenue de la r�ponse est forc�ment dans le body de cette derni�re.
        }

    }
}