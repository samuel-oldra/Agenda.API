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

        List<Contato> GetAll();

        Contato GetById(int id);

        void Add(Contato entity);

        void Update(Contato entity);

        void Delete(Contato entity);

        #region SOMENTE ESTUDO

        Task<int> CountAsync();

        Task<int> CountAsync(string nome);

        Task<bool> AnyAsync();

        Task<bool> AnyAsync(string nome);

        Task<bool> AllAsync(string nome);

        Task<Contato> FirstOrDefaultAsync();

        Task<Contato> FirstOrDefaultAsync(string nome);

        Task<Contato> LastOrDefaultAsync();

        Task<Contato> LastOrDefaultAsync(string nome);

        Task<Contato> ElementAtOrDefaultAsync(int index);

        Task<List<Contato>> WhereAsync(string nome);

        Task<List<Contato>> TakeStartAsync(int qtd);

        Task<List<Contato>> TakeEndAsync(int qtd);

        Task<List<Contato>> TakeRangeAsync(int start, int end);

        Task<List<Contato>> Skip(int qtd);

        #endregion
    }
}
