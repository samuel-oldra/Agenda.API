using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var eventos = new List<string> { "Aniversário", "Formatura" };

            return Ok(eventos);
        }
    }
}
