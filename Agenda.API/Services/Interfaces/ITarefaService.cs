using Agenda.API.Models;

namespace Agenda.API.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<List<TarefaViewModel>> GetAllAsync();

        Task<TarefaViewModel> GetByIdAsync(int id);

        Task<TarefaViewModel> AddAsync(TarefaPostInputModel model);

        Task<TarefaViewModel> UpdateAsync(int id, TarefaPutInputModel model);

        Task<TarefaViewModel> DeleteAsync(int id);

        List<TarefaViewModel> GetAll();

        TarefaViewModel GetById(int id);

        TarefaViewModel Add(TarefaPostInputModel model);

        TarefaViewModel Update(int id, TarefaPutInputModel model);

        TarefaViewModel Delete(int id);
    }
}
