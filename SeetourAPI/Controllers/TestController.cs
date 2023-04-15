using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly SeetourContext _context;

        public TestController(SeetourContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult index()
        {
            _context.Tours.Load();

            return Ok();
        }
    }
}
