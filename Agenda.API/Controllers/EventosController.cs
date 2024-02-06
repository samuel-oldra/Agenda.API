using System;
using Agenda.API.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("Endpoint - GET: api/eventos");

            var eventosViewModel = new List<EventoViewModel>();
            eventosViewModel.AddRange(
                new List<EventoViewModel>
                {
                    new EventoViewModel(
                        1,
                        "Aniversário",
                        "Aniversário do Arthur",
                        new DateTime(2024, 08, 19, 19, 00, 00)
                    ),
                    new EventoViewModel(
                        2,
                        "Formatura",
                        "Formatura do Arthur",
                        new DateTime(2022, 12, 20, 20, 00, 00)
                    )
                }
            );

            Log.Information($"{eventosViewModel.Count()} eventos recuperados");

            return Ok(eventosViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoPostInputModel model)
        {
            Log.Information("Endpoint - POST: api/eventos");

            var eventoViewModel = new EventoViewModel(1, model.Nome, model.Descricao, model.Data);

            return CreatedAtAction(
                nameof(GetById),
                new { id = eventoViewModel.Id },
                eventoViewModel
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Information($"Endpoint - GET: api/eventos/{id}");

            var eventoViewModel = new EventoViewModel(
                1,
                "Aniversário",
                "Aniversário do Arthur",
                new DateTime(2024, 08, 19, 19, 00, 00)
            );

            return Ok(eventoViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EventoPutInputModel model)
        {
            Log.Information($"Endpoint - PUT: api/eventos/{id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Log.Information($"Endpoint - DELETE: api/eventos/{id}");

            return NoContent();
        }
    }
}
