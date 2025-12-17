using Microsoft.AspNetCore.Mvc;
using PartnerEventsApi.Models;
using PartnerEventsApi.Data;

namespace PartnerEventsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnerEventsController : ControllerBase
    {
        private readonly PartnerEventsDbContext _context;

        // Constructor injection
        public PartnerEventsController(PartnerEventsDbContext context)
        {
            _context = context;
        }

        // POST api/PartnerEvents
        [HttpPost]
        public IActionResult CreateEvent([FromBody] PartnerEvent newEvent)
        {
            _context.PartnerEvents.Add(newEvent); // Stage INSERT
            _context.SaveChanges();                // Execute INSERT in SQL

            return Ok(newEvent); // 200 OK with saved object
        }

        // GET api/PartnerEvents
        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _context.PartnerEvents.ToList(); // SELECT * FROM PartnerEvents
            return Ok(events);
        }
    }
}
