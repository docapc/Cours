using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerStyleController : ControllerBase
    {
        // GET: api/<BeerStyleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BeerStyleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BeerStyleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BeerStyleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BeerStyleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
