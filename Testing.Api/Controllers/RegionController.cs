using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testing.Api.Data;
using Testing.Api.Models.DTO;

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

            // Map Domain Models to DTOs

            var regionDtos = new List<RegionDto>();

            foreach (var region in regions)
            {
                regionDtos.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }


            // return DTOs
            return Ok(regionDtos);
        }


        // GET: api/Region/{id}
        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }


            // Map entity to DTO
            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };


            return Ok(regionDto);
        }
    }
}