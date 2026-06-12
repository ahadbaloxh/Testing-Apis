using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
       public IActionResult GetAllStudents()
        {
            string[] StudentsList = ["Abdul Ahad", "Abdul Razak", "Naheed", "Sania", "Rabia"];

            return Ok(StudentsList);
        }

    }
}
