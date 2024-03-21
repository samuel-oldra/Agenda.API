using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Agenda.API.Models
{
    public class EventoPutInputModel
    {
        [Required(ErrorMessage = "DA. Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "DA. Esse campo deve conter entre 3 e 1000 caracteres")]
        [MaxLength(1000, ErrorMessage = "DA. Esse campo deve conter entre 3 e 1000 caracteres")]
        public string Descricao { get; set; }

        public DateTime Data { get; set; }
    }

    public class EventoPutInputModelValidator : AbstractValidator<EventoPutInputModel>
    {
        public EventoPutInputModelValidator()
        {
            RuleFor(c => c.Descricao).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.Data).NotEmpty().WithMessage("FV. Esse campo é obrigatório");

            RuleFor(c => c.Descricao)
                .Length(3, 1000)
                .WithMessage("FV. Esse campo deve conter entre 3 e 1000 caracteres");
        }
    }
}
