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
            context.Eventos.Add(entity);

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
    }
}
