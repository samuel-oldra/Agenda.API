using Agenda.API.Entities;

namespace Agenda.API.Repositories.Interfaces
{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllAsync();

        Task<Evento> GetByIdAsync(int id);

        Task AddAsync(Evento entity);

        Task UpdateAsync(Evento entity);

        Task DeleteAsync(Evento entity);
    }
}
