using Agenda.API.Entities;
using Agenda.API.Repositories.Interfaces;

namespace Agenda.API.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        public async Task<List<Evento>> GetAllAsync()
        {
            return null;
        }

        public async Task<Evento> GetByIdAsync(int id)
        {
            return null;
        }

        public async Task<Evento> AddAsync(Evento entity)
        {
            return null;
        }

        public async Task<Evento> UpdateAsync(Evento entity)
        {
            return null;
        }

        public async Task<Evento> DeleteAsync(Evento entity)
        {
            return null;
        }
    }
}
