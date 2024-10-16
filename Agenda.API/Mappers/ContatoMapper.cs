using Agenda.API.Entities;
using Agenda.API.Models;
using AutoMapper;

namespace Agenda.API.Mappers
{
    public class ContatoMapper : Profile
    {
        public ContatoMapper()
        {
            CreateMap<Contato, ContatoViewModel>();

            CreateMap<ContatoPostInputModel, Contato>();
        }
    }
}