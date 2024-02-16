using Agenda.API.Entities;
using Agenda.API.Models;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services.Interfaces;

namespace Agenda.API.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository repository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            this.repository = tarefaRepository;
        }

        public async Task<List<TarefaViewModel>> GetAllAsync()
        {
            var tarefas = await this.repository.GetAllAsync();

            var tarefasViewModel = new List<TarefaViewModel>();

            foreach (var tarefa in tarefas)
            {
                tarefasViewModel.Add(
                    new TarefaViewModel(
                        tarefa.Id,
                        tarefa.Nome,
                        tarefa.Descricao,
                        tarefa.DataInicio,
                        tarefa.DataTermino,
                        tarefa.Prioridade
                    )
                );
            }

            return tarefasViewModel;
        }

        public async Task<TarefaViewModel> GetByIdAsync(int id)
        {
            var tarefa = await this.repository.GetByIdAsync(id);

            if (tarefa == null)
                return null;

            return new TarefaViewModel(
                tarefa.Id,
                tarefa.Nome,
                tarefa.Descricao,
                tarefa.DataInicio,
                tarefa.DataTermino,
                tarefa.Prioridade
            );
        }

        public async Task<TarefaViewModel> AddAsync(TarefaPostInputModel model)
        {
            var tarefa = new Tarefa(
                model.Nome,
                model.Descricao,
                model.DataInicio,
                model.DataTermino,
                model.Prioridade
            );

            await this.repository.AddAsync(tarefa);

            return new TarefaViewModel(
                tarefa.Id,
                tarefa.Nome,
                tarefa.Descricao,
                tarefa.DataInicio,
                tarefa.DataTermino,
                tarefa.Prioridade
            );
        }

        public async Task<TarefaViewModel> UpdateAsync(int id, TarefaPutInputModel model)
        {
            var tarefa = await this.repository.GetByIdAsync(id);

            if (tarefa == null)
                return null;

            tarefa.Update(model.Descricao, model.DataInicio, model.DataTermino, model.Prioridade);

            await this.repository.UpdateAsync(tarefa);

            return new TarefaViewModel(
                tarefa.Id,
                tarefa.Nome,
                tarefa.Descricao,
                tarefa.DataInicio,
                tarefa.DataTermino,
                tarefa.Prioridade
            );
        }

        public async Task<TarefaViewModel> DeleteAsync(int id)
        {
            var tarefa = await this.repository.GetByIdAsync(id);

            if (tarefa == null)
                return null;

            await this.repository.DeleteAsync(tarefa);

            return new TarefaViewModel(
                tarefa.Id,
                tarefa.Nome,
                tarefa.Descricao,
                tarefa.DataInicio,
                tarefa.DataTermino,
                tarefa.Prioridade
            );
        }
    }
}
