using Agenda.API.Models;

namespace Agenda.API.Services.Interfaces
{
    public interface IEventoService
    {
        Task<List<EventoViewModel>> GetAllAsync();

        Task<EventoViewModel> GetByIdAsync(int id);

        Task<EventoViewModel> AddAsync(EventoPostInputModel model);

        Task<EventoViewModel> UpdateAsync(int id, EventoPutInputModel model);

        Task<EventoViewModel> DeleteAsync(int id);
    }
}
