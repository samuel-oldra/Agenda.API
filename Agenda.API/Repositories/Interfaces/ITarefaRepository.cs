using Agenda.API.Entities;

namespace Agenda.API.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetAllAsync();

        Task<Tarefa?> GetByIdAsync(int id);

        Task AddAsync(Tarefa entity);

        Task UpdateAsync(Tarefa entity);

        Task DeleteAsync(Tarefa entity);

        List<Tarefa> GetAll();

        Tarefa? GetById(int id);

        void Add(Tarefa entity);

        void Update(Tarefa entity);

        void Delete(Tarefa entity);
    }
}