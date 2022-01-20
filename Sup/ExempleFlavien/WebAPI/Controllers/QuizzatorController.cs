using EF_CodeFirst;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzatorController : ControllerBase
    {
        public QuizContext dbContext = new QuizContext();
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<ThemeEx> Get()
        {
            var query = from b in dbContext.ThemeEx
                        orderby b.Id
                        select b;
            return query;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ThemeEx Get(Guid id)
        {
            var query = from b in dbContext.ThemeEx
                        where b.Id == id
                        select b;

            return query.SingleOrDefault(T => T.Id == id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
            var query = from b in dbContext.ThemeEx
                        where b.Id == id
                        select b;
            ThemeEx monTheme = query.SingleOrDefault(T => T.Id == id);


        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var query = from b in dbContext.ThemeEx
                        where b.Id == id
                        select b;
            dbContext.ThemeEx.Remove(query.SingleOrDefault(T => T.Id == id));
            dbContext.SaveChanges();
        }
    }
}
