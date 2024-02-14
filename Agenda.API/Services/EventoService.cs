using Agenda.API.Models;
using Agenda.API.Services.Interfaces;

namespace Agenda.API.Services
{
    public class EventoService : IEventoService
    {
        public async Task<List<EventoViewModel>> GetAllAsync()
        {
            var eventosViewModel = new List<EventoViewModel>();

            eventosViewModel.AddRange(
                new List<EventoViewModel>
                {
                    new EventoViewModel(
                        1,
                        "Aniversário",
                        "Aniversário do Arthur",
                        new DateTime(2024, 08, 19, 19, 00, 00)
                    ),
                    new EventoViewModel(
                        2,
                        "Formatura",
                        "Formatura do Arthur",
                        new DateTime(2022, 12, 20, 20, 00, 00)
                    )
                }
            );

            return eventosViewModel;
        }

        public async Task<EventoViewModel> GetByIdAsync(int id)
        {
            return new EventoViewModel(
                id,
                "Aniversário",
                "Aniversário do Arthur",
                new DateTime(2024, 08, 19, 19, 00, 00)
            );
        }

        public async Task<EventoViewModel> AddAsync(EventoPostInputModel model)
        {
            return new EventoViewModel(1, model.Nome, model.Descricao, model.Data);
        }

        public async Task<EventoViewModel> UpdateAsync(int id, EventoPutInputModel model)
        {
            return new EventoViewModel(id, "Aniversário", model.Descricao, model.Data);
        }

        public async Task<EventoViewModel> DeleteAsync(int id)
        {
            return new EventoViewModel(
                id,
                "Aniversário",
                "Aniversário do Arthur",
                new DateTime(2024, 08, 19, 19, 00, 00)
            );
        }
    }
}
