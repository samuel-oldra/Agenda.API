using Agenda.API.Entities;

namespace Agenda.API.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetAllAsync();

        Task<Tarefa> GetByIdAsync(int id);

        Task<Tarefa> AddAsync(Tarefa entity);

        Task<Tarefa> UpdateAsync(Tarefa entity);

        Task<Tarefa> DeleteAsync(Tarefa entity);
    }
}
