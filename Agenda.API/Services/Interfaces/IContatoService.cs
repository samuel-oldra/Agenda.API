using Agenda.API.Models;

namespace Agenda.API.Services.Interfaces
{
    public interface IContatoService
    {
        Task<List<ContatoViewModel>> GetAllAsync();

        Task<ContatoViewModel> GetByIdAsync(int id);

        Task<ContatoViewModel> AddAsync(ContatoPostInputModel model);

        Task<ContatoViewModel> UpdateAsync(int id, ContatoPutInputModel model);

        Task<ContatoViewModel> DeleteAsync(int id);
    }
}
