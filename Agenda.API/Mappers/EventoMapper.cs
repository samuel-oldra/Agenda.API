using Agenda.API.Entities;
using Agenda.API.Models;
using AutoMapper;

namespace Agenda.API.Mappers
{
    public class EventoMapper : Profile
    {
        public EventoMapper()
        {
            CreateMap<Evento, EventoViewModel>();

            CreateMap<EventoPostInputModel, Evento>();
        }
    }
}