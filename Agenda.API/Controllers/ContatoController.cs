using Agenda.API.Models;
using Agenda.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService service;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="contatoService"></param>
        public ContatoController(IContatoService contatoService)
        {
            this.service = contatoService;
        }

        // GET: api/contatos
        /// <summary>
        /// Listagem de Contatos
        /// </summary>
        /// <returns>Lista de Contatos</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContatoViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("Endpoint - GET: api/contatos");

            var contatos = await service.GetAllAsync();

            if (contatos == null)
                return NotFound("Nenhum contato encontrado");

            Log.Information($"{contatos.Count()} contatos recuperados");

            return Ok(contatos);
        }

        // POST: api/contatos
        /// <summary>
        /// Cadastro do Contato
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///   "nome": "Samuel",
        ///   "email": "samuel@teste.io",
        ///   "telefone": "(54) 99988.7766",
        ///   "dataNascimento": "1984-12-07T05:00:00.000Z"
        /// }
        /// </remarks>
        /// <param name="model">Dados do Contato</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContatoViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(ContatoPostInputModel model)
        {
            Log.Information("Endpoint - POST: api/contatos");

            var contato = await service.AddAsync(model);

            return CreatedAtAction(nameof(GetById), new { id = contato.Id }, contato);
        }

        // GET: api/contatos/{id}
        /// <summary>
        /// Detalhes do Contato
        /// </summary>
        /// <param name="id">ID do Contato</param>
        /// <returns>Mostra um Contato</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContatoViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Information($"Endpoint - GET: api/contatos/{id}");

            var contato = await service.GetByIdAsync(id);

            if (contato == null)
                return NotFound("Contato não encontrado");

            return Ok(contato);
        }

        // PUT: api/contatos/{id}
        /// <summary>
        /// Atualiza um Contato
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///   "email": "samuel@teste.io",
        ///   "telefone": "(54) 99955.4433",
        ///   "dataNascimento": "1984-12-07T05:00:00.000Z"
        /// }
        /// </remarks>
        /// <param name="id">ID do Contato</param>
        /// <param name="model">Dados do Contato</param>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, ContatoPutInputModel model)
        {
            Log.Information($"Endpoint - PUT: api/contatos/{id}");

            var contato = await service.UpdateAsync(id, model);

            if (contato == null)
                return NotFound("Contato não encontrado");

            return NoContent();
        }

        // DELETE: api/contatos/{id}
        /// <summary>
        /// Deleta um Contato
        /// </summary>
        /// <param name="id">ID do Contato</param>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Log.Information($"Endpoint - DELETE: api/contatos/{id}");

            var contato = await service.DeleteAsync(id);

            if (contato == null)
                return NotFound("Contato não encontrado");

            return NoContent();
        }
    }
}