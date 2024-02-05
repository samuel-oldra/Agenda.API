using Agenda.API.Models;
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
            var contatosViewModel = new List<ContatoViewModel>();
            contatosViewModel.AddRange(
                new List<ContatoViewModel>
                {
                    new ContatoViewModel(1, "Samuel", "samuel@teste.io", "(54) 99988.7766"),
                    new ContatoViewModel(2, "Arthur", "arthur@teste.io", "(54) 99955.4433")
                }
            );

            return Ok(contatosViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContatoPostInputModel model)
        {
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
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}
