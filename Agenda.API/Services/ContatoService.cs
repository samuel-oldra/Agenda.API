using Agenda.API.Models;
using Agenda.API.Services.Interfaces;

namespace Agenda.API.Services
{
    public class ContatoService : IContatoService
    {
        public async Task<List<ContatoViewModel>> GetAllAsync()
        {
            var contatosViewModel = new List<ContatoViewModel>();

            contatosViewModel.AddRange(
                new List<ContatoViewModel>
                {
                    new ContatoViewModel(
                        1,
                        "Samuel",
                        "samuel@teste.io",
                        "(54) 99988.7766",
                        new DateTime(1984, 12, 07, 00, 00, 00)
                    ),
                    new ContatoViewModel(
                        2,
                        "Arthur",
                        "arthur@teste.io",
                        "(54) 99955.4433",
                        new DateTime(2016, 08, 19, 00, 00, 00)
                    )
                }
            );

            return contatosViewModel;
        }

        public async Task<ContatoViewModel> GetByIdAsync(int id)
        {
            return new ContatoViewModel(
                id,
                "Samuel",
                "samuel@teste.io",
                "(54) 99988.7766",
                new DateTime(1984, 12, 07, 00, 00, 00)
            );
        }

        public async Task<ContatoViewModel> AddAsync(ContatoPostInputModel model)
        {
            return new ContatoViewModel(
                1,
                model.Nome,
                model.Email,
                model.Telefone,
                model.DataNascimento
            );
        }

        public async Task<ContatoViewModel> UpdateAsync(int id, ContatoPutInputModel model)
        {
            return new ContatoViewModel(
                id,
                "Samuel",
                model.Email,
                model.Telefone,
                model.DataNascimento
            );
        }

        public async Task<ContatoViewModel> DeleteAsync(int id)
        {
            return new ContatoViewModel(
                id,
                "Samuel",
                "samuel@teste.io",
                "(54) 99988.7766",
                new DateTime(1984, 12, 07, 00, 00, 00)
            );
        }
    }
}
