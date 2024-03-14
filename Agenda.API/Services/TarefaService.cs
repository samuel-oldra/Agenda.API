using Agenda.API.Entities;
using Agenda.API.Models;
using Agenda.API.Services.Interfaces;

namespace Agenda.API.Services
{
    public class TarefaService : ITarefaService
    {
        public async Task<List<TarefaViewModel>> GetAllAsync()
        {
            var tarefasViewModel = new List<TarefaViewModel>();

            tarefasViewModel.AddRange(
                new List<TarefaViewModel>
                {
                    new TarefaViewModel(
                        1,
                        "Enviar e-mail",
                        "Enviar e-mail de cobrança",
                        new DateTime(2024, 03, 16, 00, 00, 00),
                        new DateTime(2024, 03, 20, 23, 59, 59),
                        TarefaEnum.Alta
                    ),
                    new TarefaViewModel(
                        2,
                        "Criar documento",
                        "Criar documento do relatório",
                        new DateTime(2024, 03, 15, 00, 00, 00),
                        new DateTime(2024, 03, 15, 23, 59, 59),
                        TarefaEnum.Media
                    )
                }
            );

            return tarefasViewModel;
        }

        public async Task<TarefaViewModel> GetByIdAsync(int id)
        {
            return new TarefaViewModel(
                id,
                "Enviar e-mail",
                "Enviar e-mail de cobrança",
                new DateTime(2024, 03, 16, 00, 00, 00),
                new DateTime(2024, 03, 20, 23, 59, 59),
                TarefaEnum.Alta
            );
        }

        public async Task<TarefaViewModel> AddAsync(TarefaPostInputModel model)
        {
            return new TarefaViewModel(
                1,
                model.Nome,
                model.Descricao,
                model.DataInicio,
                model.DataTermino,
                model.Prioridade
            );
        }

        public async Task<TarefaViewModel> UpdateAsync(int id, TarefaPutInputModel model)
        {
            return new TarefaViewModel(
                id,
                "Enviar e-mail",
                model.Descricao,
                model.DataInicio,
                model.DataTermino,
                model.Prioridade
            );
        }

        public async Task<TarefaViewModel> DeleteAsync(int id)
        {
            return new TarefaViewModel(
                id,
                "Enviar e-mail",
                "Enviar e-mail de cobrança",
                new DateTime(2024, 03, 16, 00, 00, 00),
                new DateTime(2024, 03, 20, 23, 59, 59),
                TarefaEnum.Alta
            );
        }
    }
}
