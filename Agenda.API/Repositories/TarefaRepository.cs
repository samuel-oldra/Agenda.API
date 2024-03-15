using Agenda.API.Entities;
using Agenda.API.Repositories.Interfaces;

namespace Agenda.API.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public async Task<List<Tarefa>> GetAllAsync()
        {
            return null;
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            return null;
        }

        public async Task<Tarefa> AddAsync(Tarefa entity)
        {
            return null;
        }

        public async Task<Tarefa> UpdateAsync(Tarefa entity)
        {
            return null;
        }

        public async Task<Tarefa> DeleteAsync(Tarefa entity)
        {
            return null;
        }
    }
}
