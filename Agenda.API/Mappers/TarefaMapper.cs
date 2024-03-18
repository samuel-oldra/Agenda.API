using Agenda.API.Entities;
using Agenda.API.Models;
using AutoMapper;

namespace Agenda.API.Mappers
{
    public class TarefaMapper : Profile
    {
        public TarefaMapper()
        {
            CreateMap<Tarefa, TarefaViewModel>();

            CreateMap<TarefaPostInputModel, Tarefa>();
        }
    }
}
