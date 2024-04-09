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

        Task<bool> DeleteAllAsync();

        List<ContatoViewModel> GetAll();

        ContatoViewModel GetById(int id);

        ContatoViewModel Add(ContatoPostInputModel model);

        ContatoViewModel Update(int id, ContatoPutInputModel model);

        ContatoViewModel Delete(int id);

        bool DeleteAll();
    }
}
