using Agenda.API.Data;
using Agenda.API.Entities;
using Agenda.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly DataContext context;

        public EventoRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Evento>> GetAllAsync()
        {
            return await context.Eventos.ToListAsync();
        }

        public async Task<Evento> GetByIdAsync(int id)
        {
            return await context.Eventos.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Evento entity)
        {
            context.Eventos.AddAsync(entity);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evento entity)
        {
            context.Eventos.Update(entity);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Evento entity)
        {
            context.Eventos.Remove(entity);

            await context.SaveChangesAsync();
        }

        public List<Evento> GetAll()
        {
            return context.Eventos.ToList();
        }

        public Evento GetById(int id)
        {
            return context.Eventos.SingleOrDefault(c => c.Id == id);
        }

        public void Add(Evento entity)
        {
            context.Eventos.Add(entity);

            context.SaveChanges();
        }

        public void Update(Evento entity)
        {
            context.Eventos.Update(entity);

            context.SaveChanges();
        }

        public void Delete(Evento entity)
        {
            context.Eventos.Remove(entity);

            context.SaveChanges();
        }
    }
}
