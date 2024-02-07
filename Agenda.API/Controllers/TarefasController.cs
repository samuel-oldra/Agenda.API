using System;
using Agenda.API.Entities;
using Agenda.API.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("Endpoint - GET: api/tarefas");

            var tarefasViewModel = new List<TarefaViewModel>();
            tarefasViewModel.AddRange(
                new List<TarefaViewModel>
                {
                    new TarefaViewModel(
                        1,
                        "Enviar e-mail",
                        "Enviar e-mail de cobrança",
                        new DateTime(2024, 03, 16, 00, 00, 00),
                        new DateTime(2024, 03, 20, 23, 59, 59),
                        TarefaEnum.Alta
                    ),
                    new TarefaViewModel(
                        2,
                        "Criar documento",
                        "Criar documento do relatório",
                        new DateTime(2024, 03, 15, 00, 00, 00),
                        new DateTime(2024, 03, 15, 23, 59, 59),
                        TarefaEnum.Media
                    )
                }
            );

            Log.Information($"{tarefasViewModel.Count()} tarefas recuperadas");

            return Ok(tarefasViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TarefaPostInputModel model)
        {
            Log.Information("Endpoint - POST: api/tarefas");

            var tarefaViewModel = new TarefaViewModel(
                1,
                model.Nome,
                model.Descricao,
                model.DataInicio,
                model.DataTermino,
                model.Prioridade
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
            Log.Information($"Endpoint - GET: api/tarefas/{id}");

            var tarefaViewModel = new TarefaViewModel(
                1,
                "Enviar e-mail",
                "Enviar e-mail de cobrança",
                new DateTime(2024, 03, 16, 00, 00, 00),
                new DateTime(2024, 03, 20, 23, 59, 59),
                TarefaEnum.Alta
            );

            return Ok(tarefaViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TarefaPutInputModel model)
        {
            Log.Information($"Endpoint - PUT: api/tarefas/{id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Log.Information($"Endpoint - DELETE: api/tarefas/{id}");

            return NoContent();
        }
    }
}
