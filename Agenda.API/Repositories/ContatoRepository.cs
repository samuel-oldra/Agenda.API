using Agenda.API.Entities;
using Agenda.API.Repositories.Interfaces;

namespace Agenda.API.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        public async Task<List<Contato>> GetAllAsync()
        {
            return null;
        }

        public async Task<Contato> GetByIdAsync(int id)
        {
            return null;
        }

        public async Task<Contato> AddAsync(Contato entity)
        {
            return null;
        }

        public async Task<Contato> UpdateAsync(Contato entity)
        {
            return null;
        }

        public async Task<Contato> DeleteAsync(Contato entity)
        {
            return null;
        }
    }
}
