using Agenda.API.Data;
using Agenda.API.Entities;
using Agenda.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext context;

        public TarefaRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Tarefa>> GetAllAsync()
        {
            return await context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            return await context.Tarefas.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Tarefa entity)
        {
            await context.Tarefas.AddAsync(entity);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarefa entity)
        {
            context.Tarefas.Update(entity);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tarefa entity)
        {
            context.Tarefas.Remove(entity);

            await context.SaveChangesAsync();
        }

        public List<Tarefa> GetAll()
        {
            return context.Tarefas.ToList();
        }

        public Tarefa GetById(int id)
        {
            return context.Tarefas.SingleOrDefault(c => c.Id == id);
        }

        public void Add(Tarefa entity)
        {
            context.Tarefas.Add(entity);

            context.SaveChanges();
        }

        public void Update(Tarefa entity)
        {
            context.Tarefas.Update(entity);

            context.SaveChanges();
        }

        public void Delete(Tarefa entity)
        {
            context.Tarefas.Remove(entity);

            context.SaveChanges();
        }
    }
}
