using System;
using Agenda.API.Models;
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
            var tarefasViewModel = new List<TarefaViewModel>();
            tarefasViewModel.AddRange(
                new List<TarefaViewModel>
                {
                    new TarefaViewModel(
                        1,
                        "Enviar e-mail",
                        "Enviar e-mail de cobrança",
                        new DateTime(2024, 03, 16, 00, 00, 00),
                        new DateTime(2024, 03, 20, 23, 59, 59)
                    ),
                    new TarefaViewModel(
                        2,
                        "Criar documento",
                        "Criar documento do relatório",
                        new DateTime(2024, 03, 15, 00, 00, 00),
                        new DateTime(2024, 03, 15, 23, 59, 59)
                    )
                }
            );

            return Ok(tarefasViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TarefaPostInputModel model)
        {
            var tarefaViewModel = new TarefaViewModel(
                1,
                model.Nome,
                model.Descricao,
                model.DataInicio,
                model.DataTermino
            );

            return CreatedAtAction(
                nameof(GetById),
                new { id = tarefaViewModel.Id },
                tarefaViewModel
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarefaViewModel = new TarefaViewModel(
                1,
                "Enviar e-mail",
                "Enviar e-mail de cobrança",
                new DateTime(2024, 03, 16, 00, 00, 00),
                new DateTime(2024, 03, 20, 23, 59, 59)
            );

            return Ok(tarefaViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TarefaPutInputModel model)
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
