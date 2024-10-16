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

        public async Task<List<EventoViewModel>?> GetAllAsync()
        {
            var eventos = await this.repository.GetAllAsync();

            if (eventos == null)
                return null;

            var eventosViewModel = new List<EventoViewModel>();

            foreach (var evento in eventos)
                eventosViewModel.Add(mapper.Map<EventoViewModel>(evento));

            return eventosViewModel;
        }

        public async Task<EventoViewModel?> GetByIdAsync(int id)
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

        public async Task<EventoViewModel?> UpdateAsync(int id, EventoPutInputModel model)
        {
            var evento = await this.repository.GetByIdAsync(id);

            if (evento == null)
                return null;

            evento.Update(model.Descricao, model.Data);

            await this.repository.UpdateAsync(evento);

            return mapper.Map<EventoViewModel>(evento);
        }

        public async Task<EventoViewModel?> DeleteAsync(int id)
        {
            var evento = await this.repository.GetByIdAsync(id);

            if (evento == null)
                return null;

            await this.repository.DeleteAsync(evento);

            return mapper.Map<EventoViewModel>(evento);
        }

        public async Task<bool> DeleteAllAsync()
        {
            var eventos = await this.repository.GetAllAsync();

            foreach (var evento in eventos)
                await this.repository.DeleteAsync(evento);

            return true;
        }

        public List<EventoViewModel>? GetAll()
        {
            var eventos = this.repository.GetAll();

            if (eventos == null)
                return null;

            var eventosViewModel = new List<EventoViewModel>();

            foreach (var evento in eventos)
                eventosViewModel.Add(mapper.Map<EventoViewModel>(evento));

            return eventosViewModel;
        }

        public EventoViewModel? GetById(int id)
        {
            var evento = this.repository.GetById(id);

            if (evento == null)
                return null;

            return mapper.Map<EventoViewModel>(evento);
        }

        public EventoViewModel Add(EventoPostInputModel model)
        {
            var evento = mapper.Map<Evento>(model);

            this.repository.Add(evento);

            return mapper.Map<EventoViewModel>(evento);
        }

        public EventoViewModel? Update(int id, EventoPutInputModel model)
        {
            var evento = this.repository.GetById(id);

            if (evento == null)
                return null;

            evento.Update(model.Descricao, model.Data);

            this.repository.Update(evento);

            return mapper.Map<EventoViewModel>(evento);
        }

        public EventoViewModel? Delete(int id)
        {
            var evento = this.repository.GetById(id);

            if (evento == null)
                return null;

            this.repository.Delete(evento);

            return mapper.Map<EventoViewModel>(evento);
        }

        public bool DeleteAll()
        {
            var eventos = this.repository.GetAll();

            foreach (var evento in eventos)
                this.repository.Delete(evento);

            return true;
        }
    }
}