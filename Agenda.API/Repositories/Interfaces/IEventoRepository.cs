using Agenda.API.Entities;

namespace Agenda.API.Repositories.Interfaces
{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllAsync();

        Task<Evento> GetByIdAsync(int id);

        Task<Evento> AddAsync(Evento entity);

        Task<Evento> UpdateAsync(Evento entity);

        Task<Evento> DeleteAsync(Evento entity);
    }
}
