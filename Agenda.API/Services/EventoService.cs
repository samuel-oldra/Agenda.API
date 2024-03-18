using Agenda.API.Entities;
using Agenda.API.Models;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services.Interfaces;
using AutoMapper;

namespace Agenda.API.Services
{
    public class EventoService : IEventoService
    {
        private readonly IMapper mapper;

        private readonly IEventoRepository repository;

        public EventoService(IMapper mapper, IEventoRepository eventoRepository)
        {
            this.mapper = mapper;

            this.repository = eventoRepository;
        }

        public async Task<List<EventoViewModel>> GetAllAsync()
        {
            var eventos = await this.repository.GetAllAsync();

            var eventosViewModel = new List<EventoViewModel>();

            foreach (var evento in eventos)
                eventosViewModel.Add(mapper.Map<EventoViewModel>(evento));

            return eventosViewModel;
        }

        public async Task<EventoViewModel> GetByIdAsync(int id)
        {
            var evento = await this.repository.GetByIdAsync(id);

            if (evento == null)
                return null;

            return mapper.Map<EventoViewModel>(evento);
        }

        public async Task<EventoViewModel> AddAsync(EventoPostInputModel model)
        {
            var evento = mapper.Map<Evento>(model);

            await this.repository.AddAsync(evento);

            return mapper.Map<EventoViewModel>(evento);
        }

        public async Task<EventoViewModel> UpdateAsync(int id, EventoPutInputModel model)
        {
            var evento = await this.repository.GetByIdAsync(id);

            if (evento == null)
                return null;

            evento.Update(model.Descricao, model.Data);

            await this.repository.UpdateAsync(evento);

            return mapper.Map<EventoViewModel>(evento);
        }

        public async Task<EventoViewModel> DeleteAsync(int id)
        {
            var evento = await this.repository.GetByIdAsync(id);

            if (evento == null)
                return null;

            await this.repository.DeleteAsync(evento);

            return mapper.Map<EventoViewModel>(evento);
        }
    }
}
