using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers
{
    //[Authorize] // Permet de donner des User = "User1", ou bien Roles = ""
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private IMapper _mapper;
        private TestDbContext _context; // on ne peut pas passer par l'interface à cause de la définitions des property dans le contexte

        public TestController(ILogger<TestController> logger, IMapper mapper, TestDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        //public TestController(IMapper mapper, TestDbContext context)
        //{
         
        //    _mapper = mapper;
        //    _context = context;
        //}

        /// <summary>
        /// retourne bien un TestDto dans le body malgrès le ActionResult
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blabla"></param>
        /// <returns></returns>
        [HttpGet("detail/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TestDto))] //type retournée en cas de réussite
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TestDto> Get(short id, string blabla = "blabla")
        {
            if (id == 0)
            {
                return NotFound();
            }

            //var p = new Project()
            //{
            //    Id = id,
            //    Surname = "test",
            //    Description = "desc"
            //};

            var p = _context.Tests.Find(id);

            var mapProj = _mapper.Map<TestDto>(p);

            return Ok(mapProj);
        }

        [HttpGet("{id}")]
        public TestDto Get(short id)
        //public TestDto Get(int id)
        {
            var testEntity = _context.Tests.Find(id);
            //var testEntity = _context.Tests.First();
            //var testEntity = _context.Set<TestEntity>().Find(id); // fonctionne également
            var testDto = _mapper.Map<TestDto>(testEntity);
            return testDto;
        }



    }
    
}
