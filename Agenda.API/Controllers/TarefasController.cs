using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarefas = new List<string> { "Enviar e-mail", "Criar documento" };

            return Ok(tarefas);
        }
    }
}
