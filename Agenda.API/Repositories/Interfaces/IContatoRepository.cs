using Agenda.API.Entities;

namespace Agenda.API.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        Task<List<Contato>> GetAllAsync();

        Task<Contato> GetByIdAsync(int id);

        Task<Contato> AddAsync(Contato entity);

        Task<Contato> UpdateAsync(Contato entity);

        Task<Contato> DeleteAsync(Contato entity);
    }
}
