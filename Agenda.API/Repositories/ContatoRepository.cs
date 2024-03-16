using Agenda.API.Data;
using Agenda.API.Entities;
using Agenda.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly DataContext context;

        public ContatoRepository(DataContext dataContext)
        {
            this.context = dataContext;
        }

        public async Task<List<Contato>> GetAllAsync()
        {
            return await context.Contatos.ToListAsync();
        }

        public async Task<Contato> GetByIdAsync(int id)
        {
            return await context.Contatos.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Contato entity)
        {
            context.Contatos.Add(entity);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contato entity)
        {
            context.Contatos.Update(entity);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Contato entity)
        {
            context.Contatos.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
