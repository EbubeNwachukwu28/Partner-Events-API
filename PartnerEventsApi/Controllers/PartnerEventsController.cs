
using Microsoft.AspNetCore.Mvc; // Gives access to ASP.NET Core MVC features like ControllerBase, HttpPost, HttpGet, and responses.
using PartnerEventsApi.Models; // Imports the PartnerEvent model from the Models namespace to use in the controller.

namespace PartnerEventsApi.Controllers // Defines the namespace(folders) for the controller, organizing it within the PartnerEventsApi project.
{
    [ApiController] // This tells ASP.Net: This class handles the API routes, Auto-validates JSON, Automatically binds JSON to C# objects, Returns useful error messages.
    [Route("api/controller")] // This how to reach this controller via URL. "controller" becomes the controller's name without the word "Controller". // PartnerEventsController -> api/PartnerEvents
    public class PartnerEventsController : ControllerBase // This means your class is an API controller and inherits functionality from ControllerBase: like OK(), BadRequest(), Created(), JSON handling.
    {
        private static List<PartnerEvent> _events = new List<PartnerEvent>(); // This line creates: A static list(shared across all requests), Stores objects of type PartnerEvent, This acts as an temporary in memory database
        // POST api/PartnerEvents
        [HttpPost] // This method handles HTTP POST requests(meaning creating new data)
        public IActionResult CreateEvent([FromBody] PartnerEvent newEvent) // CreatesEvent = method name, IActionResult = returns HTTP responses, [FromBody] = tells ASP to read the JSON body of the request, PartnerEvent newEvent = automatically filled with JSON sent by client
        {
            _events.Add(newEvent); // Stores the incoming event in memory.
            return Ok(newEvent); // Returns HTTP 200 with rhe created event as JSON.
        }
        // GET api/PartnerEvents
        [HttpGet] // This method responds to HTTP GET requests(meaning retrieving data). A Get request means: "Give me a current list of events."
        public IActionResult GetEvents()
        {
            return Ok(_events); // Returns an array of all events stored in memory.

        }
    }
}
