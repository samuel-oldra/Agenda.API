using Agenda.API.Entities;
using Agenda.API.Models;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services.Interfaces;
using AutoMapper;

namespace Agenda.API.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IMapper mapper;

        private readonly IContatoRepository repository;

        public ContatoService(IMapper mapper, IContatoRepository contatoRepository)
        {
            this.mapper = mapper;

            this.repository = contatoRepository;
        }

        public async Task<List<ContatoViewModel>> GetAllAsync()
        {
            var contatos = await this.repository.GetAllAsync();

            var contatosViewModel = new List<ContatoViewModel>();

            foreach (var contato in contatos)
                contatosViewModel.Add(mapper.Map<ContatoViewModel>(contato));

            return contatosViewModel;
        }

        public async Task<ContatoViewModel> GetByIdAsync(int id)
        {
            var contato = await this.repository.GetByIdAsync(id);

            if (contato == null)
                return null;

            return mapper.Map<ContatoViewModel>(contato);
        }

        public async Task<ContatoViewModel> AddAsync(ContatoPostInputModel model)
        {
            var contato = mapper.Map<Contato>(model);

            await this.repository.AddAsync(contato);

            return mapper.Map<ContatoViewModel>(contato);
        }

        public async Task<ContatoViewModel> UpdateAsync(int id, ContatoPutInputModel model)
        {
            var contato = await this.repository.GetByIdAsync(id);

            if (contato == null)
                return null;

            contato.Update(model.Email, model.Telefone, model.DataNascimento);

            await this.repository.UpdateAsync(contato);

            return mapper.Map<ContatoViewModel>(contato);
        }

        public async Task<ContatoViewModel> DeleteAsync(int id)
        {
            var contato = await this.repository.GetByIdAsync(id);

            if (contato == null)
                return null;

            await this.repository.DeleteAsync(contato);

            return mapper.Map<ContatoViewModel>(contato);
        }
    }
}
