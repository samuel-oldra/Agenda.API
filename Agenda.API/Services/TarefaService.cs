using Agenda.API.Entities;
using Agenda.API.Models;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services.Interfaces;
using AutoMapper;

namespace Agenda.API.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IMapper mapper;

        private readonly ITarefaRepository repository;

        public TarefaService(IMapper mapper, ITarefaRepository tarefaRepository)
        {
            this.mapper = mapper;

            this.repository = tarefaRepository;
        }

        public async Task<List<TarefaViewModel>> GetAllAsync()
        {
            var tarefas = await this.repository.GetAllAsync();

            var tarefasViewModel = new List<TarefaViewModel>();

            foreach (var tarefa in tarefas)
                tarefasViewModel.Add(mapper.Map<TarefaViewModel>(tarefa));

            return tarefasViewModel;
        }

        public async Task<TarefaViewModel> GetByIdAsync(int id)
        {
            var tarefa = await this.repository.GetByIdAsync(id);

            if (tarefa == null)
                return null;

            return mapper.Map<TarefaViewModel>(tarefa);
        }

        public async Task<TarefaViewModel> AddAsync(TarefaPostInputModel model)
        {
            var tarefa = mapper.Map<Tarefa>(model);

            await this.repository.AddAsync(tarefa);

            return mapper.Map<TarefaViewModel>(tarefa);
        }

        public async Task<TarefaViewModel> UpdateAsync(int id, TarefaPutInputModel model)
        {
            var tarefa = await this.repository.GetByIdAsync(id);

            if (tarefa == null)
                return null;

            tarefa.Update(model.Descricao, model.DataInicio, model.DataTermino, model.Prioridade);

            await this.repository.UpdateAsync(tarefa);

            return mapper.Map<TarefaViewModel>(tarefa);
        }

        public async Task<TarefaViewModel> DeleteAsync(int id)
        {
            var tarefa = await this.repository.GetByIdAsync(id);

            if (tarefa == null)
                return null;

            await this.repository.DeleteAsync(tarefa);

            return mapper.Map<TarefaViewModel>(tarefa);
        }

        public List<TarefaViewModel> GetAll()
        {
            var tarefas = this.repository.GetAll();

            var tarefasViewModel = new List<TarefaViewModel>();

            foreach (var tarefa in tarefas)
                tarefasViewModel.Add(mapper.Map<TarefaViewModel>(tarefa));

            return tarefasViewModel;
        }

        public TarefaViewModel GetById(int id)
        {
            var tarefa = this.repository.GetById(id);

            if (tarefa == null)
                return null;

            return mapper.Map<TarefaViewModel>(tarefa);
        }

        public TarefaViewModel Add(TarefaPostInputModel model)
        {
            var tarefa = mapper.Map<Tarefa>(model);

            this.repository.Add(tarefa);

            return mapper.Map<TarefaViewModel>(tarefa);
        }

        public TarefaViewModel Update(int id, TarefaPutInputModel model)
        {
            var tarefa = this.repository.GetById(id);

            if (tarefa == null)
                return null;

            tarefa.Update(model.Descricao, model.DataInicio, model.DataTermino, model.Prioridade);

            this.repository.Update(tarefa);

            return mapper.Map<TarefaViewModel>(tarefa);
        }

        public TarefaViewModel Delete(int id)
        {
            var tarefa = this.repository.GetById(id);

            if (tarefa == null)
                return null;

            this.repository.Delete(tarefa);

            return mapper.Map<TarefaViewModel>(tarefa);
        }
    }
}
