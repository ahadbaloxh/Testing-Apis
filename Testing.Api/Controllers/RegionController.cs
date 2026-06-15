using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testing.Api.Data;
using Testing.Api.Models.Domains;
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


            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };


            return Ok(regionDto);
        }



        // POST: api/Region
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map DTO to Domain Model

            var region = new Region()
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };


            // Save to database

            dbContext.Regions.Add(region);
            dbContext.SaveChanges();


            // Convert Domain Model back to DTO

            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };


            return CreatedAtAction(nameof(GetById),
                new { id = regionDto.Id },
                regionDto);
        }
    }
}