using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contatos = new List<string> { "Samuel", "Arthur" };

            return Ok(contatos);
        }
    }
}
