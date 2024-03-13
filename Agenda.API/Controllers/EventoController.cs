using System;
using Agenda.API.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        // GET: api/eventos
        /// <summary>
        /// Listagem de Eventos
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        // POST: api/eventos
        /// <summary>
        /// Cadastro do Evento
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///   "nome": "Aniversário",
        ///   "descricao": "Aniversário do Arthur",
        ///   "data": "2024-08-19T19:00:00.000Z"
        /// }
        /// </remarks>
        /// <param name="model">Dados do Evento</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(EventoPostInputModel model)
        {
            Log.Information("Endpoint - POST: api/eventos");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var eventoViewModel = new EventoViewModel(1, model.Nome, model.Descricao, model.Data);

            return CreatedAtAction(
                nameof(GetById),
                new { id = eventoViewModel.Id },
                eventoViewModel
            );
        }

        // GET: api/eventos/{id}
        /// <summary>
        /// Detalhes do Evento
        /// </summary>
        /// <param name="id">ID do Evento</param>
        /// <returns>Mostra um Evento</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        // PUT: api/eventos/{id}
        /// <summary>
        /// Atualiza um Evento
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///   "descricao": "Aniversário do Arthur",
        ///   "data": "2024-08-19T20:00:00.000Z"
        /// }
        /// </remarks>
        /// <param name="id">ID do Evento</param>
        /// <param name="model">Dados do Evento</param>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, EventoPutInputModel model)
        {
            Log.Information($"Endpoint - PUT: api/eventos/{id}");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        // DELETE: api/eventos/{id}
        /// <summary>
        /// Deleta um Evento
        /// </summary>
        /// <param name="id">ID do Evento</param>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Log.Information($"Endpoint - DELETE: api/eventos/{id}");

            return NoContent();
        }
    }
}
