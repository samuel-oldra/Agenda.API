using Agenda.API.Entities;

namespace Agenda.API.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        Task<List<Contato>> GetAllAsync();

        Task<Contato> GetByIdAsync(int id);

        Task AddAsync(Contato entity);

        Task UpdateAsync(Contato entity);

        Task DeleteAsync(Contato entity);
    }
}
