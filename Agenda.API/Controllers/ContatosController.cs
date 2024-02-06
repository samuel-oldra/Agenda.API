using Agenda.API.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("Endpoint - GET: api/contatos");

            var contatosViewModel = new List<ContatoViewModel>();
            contatosViewModel.AddRange(
                new List<ContatoViewModel>
                {
                    new ContatoViewModel(1, "Samuel", "samuel@teste.io", "(54) 99988.7766"),
                    new ContatoViewModel(2, "Arthur", "arthur@teste.io", "(54) 99955.4433")
                }
            );

            Log.Information($"{contatosViewModel.Count()} contatos recuperados");

            return Ok(contatosViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContatoPostInputModel model)
        {
            Log.Information("Endpoint - POST: api/contatos");

            var contatoViewModel = new ContatoViewModel(1, model.Nome, model.Email, model.Telefone);

            return CreatedAtAction(
                nameof(GetById),
                new { id = contatoViewModel.Id },
                contatoViewModel
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Information($"Endpoint - GET: api/contatos/{id}");

            var contatoViewModel = new ContatoViewModel(
                1,
                "Samuel",
                "samuel@teste.io",
                "(54) 99988.7766"
            );

            return Ok(contatoViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ContatoPutInputModel model)
        {
            Log.Information($"Endpoint - PUT: api/contatos/{id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Log.Information($"Endpoint - DELETE: api/contatos/{id}");

            return NoContent();
        }
    }
}
