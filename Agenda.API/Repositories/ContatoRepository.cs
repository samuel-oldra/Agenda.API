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

        public async Task<Contato?> GetByIdAsync(int id)
        {
            return await context.Contatos.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Contato entity)
        {
            await context.Contatos.AddAsync(entity);

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

        public List<Contato> GetAll()
        {
            return context.Contatos.ToList();
        }

        public Contato? GetById(int id)
        {
            return context.Contatos.SingleOrDefault(c => c.Id == id);
        }

        public void Add(Contato entity)
        {
            context.Contatos.Add(entity);

            context.SaveChanges();
        }

        public void Update(Contato entity)
        {
            context.Contatos.Update(entity);

            context.SaveChanges();
        }

        public void Delete(Contato entity)
        {
            context.Contatos.Remove(entity);

            context.SaveChanges();
        }

        #region SOMENTE ESTUDO

        public async Task<int> CountAsync()
        {
            return await context.Contatos.CountAsync();
        }

        public async Task<int> CountAsync(string nome)
        {
            return await context.Contatos.CountAsync(c => c.Nome == nome);
        }

        public async Task<bool> AnyAsync()
        {
            return await context.Contatos.AnyAsync();
        }

        public async Task<bool> AnyAsync(string nome)
        {
            return await context.Contatos.AnyAsync(c => c.Nome == nome);
        }

        /// <summary>
        /// Verifica se todos os itens correspondem à condição
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public async Task<bool> AllAsync(string nome)
        {
            return await context.Contatos.AllAsync(c => c.Nome == nome);
        }

        public async Task<Contato?> FirstOrDefaultAsync()
        {
            return await context.Contatos.FirstOrDefaultAsync();
        }

        public async Task<Contato?> FirstOrDefaultAsync(string nome)
        {
            return await context.Contatos.FirstOrDefaultAsync(c => c.Nome == nome);
        }

        public async Task<Contato?> LastOrDefaultAsync()
        {
            return await context.Contatos.LastOrDefaultAsync();
        }

        public async Task<Contato?> LastOrDefaultAsync(string nome)
        {
            return await context.Contatos.LastOrDefaultAsync(c => c.Nome == nome);
        }

        /// <summary>
        /// Busca o elemento pelo index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<Contato> ElementAtOrDefaultAsync(int index)
        {
            return await context.Contatos.ElementAtOrDefaultAsync(index);
        }

        public async Task<List<Contato>> WhereAsync(string nome)
        {
            return await context.Contatos.Where(c => c.Nome == nome).ToListAsync();
        }

        /// <summary>
        /// Pega os n primeiros elementos da lista
        /// </summary>
        /// <param name="qtd"></param>
        /// <returns></returns>
        public async Task<List<Contato>> TakeStartAsync(int qtd)
        {
            return await context.Contatos.Take(qtd).ToListAsync();
        }

        /// <summary>
        /// Pega os n últimos elementos da lista
        /// </summary>
        /// <param name="qtd"></param>
        /// <returns></returns>
        public async Task<List<Contato>> TakeEndAsync(int qtd)
        {
            return await context.Contatos.Take(..qtd).ToListAsync();
        }

        /// <summary>
        /// Pega os elementos da lista dentro de um intervalo
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public async Task<List<Contato>> TakeRangeAsync(int start, int end)
        {
            return await context.Contatos.Take(start..end).ToListAsync();
        }

        /// <summary>
        /// Retorna os elementos da lista pulando os n primeiros
        /// </summary>
        /// <param name="qtd"></param>
        /// <returns></returns>
        public async Task<List<Contato>> Skip(int qtd)
        {
            return await context.Contatos.Skip(qtd).ToListAsync();
        }

        #endregion SOMENTE ESTUDO
    }
}