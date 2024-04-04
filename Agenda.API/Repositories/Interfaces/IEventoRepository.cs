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

        List<Evento> GetAll();

        Evento GetById(int id);

        void Add(Evento entity);

        void Update(Evento entity);

        void Delete(Evento entity);
    }
}
