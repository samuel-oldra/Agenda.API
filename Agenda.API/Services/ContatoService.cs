using Agenda.API.Entities;
using Agenda.API.Models;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services.Interfaces;

namespace Agenda.API.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository repository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            this.repository = contatoRepository;
        }

        public async Task<List<ContatoViewModel>> GetAllAsync()
        {
            var contatos = await this.repository.GetAllAsync();

            var contatosViewModel = new List<ContatoViewModel>();

            foreach (var contato in contatos)
            {
                contatosViewModel.Add(
                    new ContatoViewModel(
                        contato.Id,
                        contato.Nome,
                        contato.Email,
                        contato.Telefone,
                        contato.DataNascimento
                    )
                );
            }

            return contatosViewModel;
        }

        public async Task<ContatoViewModel> GetByIdAsync(int id)
        {
            var contato = await this.repository.GetByIdAsync(id);

            if (contato == null)
                return null;

            return new ContatoViewModel(
                contato.Id,
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.DataNascimento
            );
        }

        public async Task<ContatoViewModel> AddAsync(ContatoPostInputModel model)
        {
            var contato = new Contato(
                model.Nome,
                model.Email,
                model.Telefone,
                model.DataNascimento
            );

            await this.repository.AddAsync(contato);

            return new ContatoViewModel(
                contato.Id,
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.DataNascimento
            );
        }

        public async Task<ContatoViewModel> UpdateAsync(int id, ContatoPutInputModel model)
        {
            var contato = await this.repository.GetByIdAsync(id);

            if (contato == null)
                return null;

            contato.Update(model.Email, model.Telefone, model.DataNascimento);

            await this.repository.UpdateAsync(contato);

            return new ContatoViewModel(
                contato.Id,
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.DataNascimento
            );
        }

        public async Task<ContatoViewModel> DeleteAsync(int id)
        {
            var contato = await this.repository.GetByIdAsync(id);

            if (contato == null)
                return null;

            await this.repository.DeleteAsync(contato);

            return new ContatoViewModel(
                contato.Id,
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.DataNascimento
            );
        }
    }
}
