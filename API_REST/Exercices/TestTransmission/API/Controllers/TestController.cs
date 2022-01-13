using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private IMapper _mapper;
        private TestDbContext _context; // on ne peut pas passer par l'interface à cause de la définitions des property dans le contexte

        //public TestController(ILogger<TestController> logger, IMapper mapper, TestDbContext context)
        //{
        //    _logger = logger;
        //    _mapper = mapper;
        //    _context = context;
        //}

        public TestController(IMapper mapper, TestDbContext context)
        {
         
            _mapper = mapper;
            _context = context;
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDto))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<ProjectDto> Get(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    //var p = new Project()
        //    //{
        //    //    Id = id,
        //    //    Surname = "test",
        //    //    Description = "desc"
        //    //};

        //    var p = _context.Project.Find(id);

        //    var mapProj = _mapper.Map<ProjectDto>(p);

        //    return Ok(mapProj);
        //}

        [HttpGet("{id}")]
        public TestDto Get(short id)
        //public TestDto Get(int id)
        {
//            var testEntity = _context.Tests.Find(id);
            var testEntity = _context.Set<TestEntity>().Find((short)id);
            var testDto = _mapper.Map<TestDto>(testEntity);
            return testDto;
        }



    }
    
}
