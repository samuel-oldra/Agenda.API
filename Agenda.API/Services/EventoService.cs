using Agenda.API.Entities;
using Agenda.API.Models;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services.Interfaces;

namespace Agenda.API.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository repository;

        public EventoService(IEventoRepository eventoRepository)
        {
            this.repository = eventoRepository;
        }

        public async Task<List<EventoViewModel>> GetAllAsync()
        {
            var eventos = await this.repository.GetAllAsync();

            var eventosViewModel = new List<EventoViewModel>();

            foreach (var evento in eventos)
            {
                eventosViewModel.Add(
                    new EventoViewModel(evento.Id, evento.Nome, evento.Descricao, evento.Data)
                );
            }

            return eventosViewModel;
        }

        public async Task<EventoViewModel> GetByIdAsync(int id)
        {
            var evento = await this.repository.GetByIdAsync(id);

            if (evento == null)
                return null;

            return new EventoViewModel(evento.Id, evento.Nome, evento.Descricao, evento.Data);
        }

        public async Task<EventoViewModel> AddAsync(EventoPostInputModel model)
        {
            var evento = new Evento(model.Nome, model.Descricao, model.Data);

            await this.repository.AddAsync(evento);

            return new EventoViewModel(evento.Id, evento.Nome, evento.Descricao, evento.Data);
        }

        public async Task<EventoViewModel> UpdateAsync(int id, EventoPutInputModel model)
        {
            var evento = await this.repository.GetByIdAsync(id);

            if (evento == null)
                return null;

            evento.Update(model.Descricao, model.Data);

            await this.repository.UpdateAsync(evento);

            return new EventoViewModel(evento.Id, evento.Nome, evento.Descricao, evento.Data);
        }

        public async Task<EventoViewModel> DeleteAsync(int id)
        {
            var evento = await this.repository.GetByIdAsync(id);

            if (evento == null)
                return null;

            await this.repository.DeleteAsync(evento);

            return new EventoViewModel(evento.Id, evento.Nome, evento.Descricao, evento.Data);
        }
    }
}
