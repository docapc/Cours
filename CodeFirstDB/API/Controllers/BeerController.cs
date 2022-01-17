using AutoMapper;
using Contexts;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Perstistance;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IMapper _beerMapper;
        private readonly IBeerRepository _beerManager; // pour ne pas avoir à réecrire les CRUD...
        //private readonly WikiBeerSqlContext _beerContext; // avec sa on doit se retapper les crude en version API

        public BeerController(IBeerRepository beerManager, IMapper beerMapper)
        //public BeerController(WikiBeerSqlContext beerContext, IMapper beerMapper)
        {
            //_beerContext = beerContext;
            _beerManager = beerManager;
            _beerMapper = beerMapper;
        }

        // GET: api/<BeerController>
        [HttpGet]
        public IEnumerable<BeerDto> Get()
        {
            var allBeers = _beerMapper.Map<IEnumerable<BeerDto>>(_beerManager.GetAllBeers());
            return allBeers;
        }

        // GET api/<BeerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BeerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BeerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BeerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
