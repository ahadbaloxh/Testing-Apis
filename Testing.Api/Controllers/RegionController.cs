using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testing.Api.Data;

namespace Testing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly TestingDBContext dbContext;

        public RegionController(TestingDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Region
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();

            return Ok(regions);
        }
    }
}