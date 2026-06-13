using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testing.Api.Models.Domains;

namespace Testing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        // GET: api/Region
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland Region",
                    Code = "AKL",
                    RegionImageUrl = "https://images.unsplash.com/photo-1619027217465-ef4cb4f7c040?q=80&w=870&auto=format&fit=crop"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington Region",
                    Code = "WLG",
                    RegionImageUrl = "https://plus.unsplash.com/premium_photo-1676218969642-9873c264d7a7?q=80&w=436&auto=format&fit=crop"
                }
            };

            return Ok(regions);
        }
    }
}