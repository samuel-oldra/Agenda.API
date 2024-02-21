using System.ComponentModel.DataAnnotations;
using Agenda.API.Entities;
using FluentValidation;

namespace Agenda.API.Models
{
    public class TarefaPutInputModel
    {
        [Required(ErrorMessage = "DA. Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "DA. Esse campo deve conter entre 3 e 1000 caracteres")]
        [MaxLength(1000, ErrorMessage = "DA. Esse campo deve conter entre 3 e 1000 caracteres")]
        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        [Range(1, 3, ErrorMessage = "DA. Valor inválido (1-Alta, 2-Média, 3-Baixa)")]
        public TarefaEnum Prioridade { get; set; }
    }

    public class TarefaPutInputModelValidator : AbstractValidator<TarefaPutInputModel>
    {
        public TarefaPutInputModelValidator()
        {
            RuleFor(c => c.Descricao).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.DataInicio).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.DataTermino).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.Prioridade).NotEmpty().WithMessage("FV. Esse campo é obrigatório");

            RuleFor(c => c.Descricao)
                .Length(3, 1000)
                .WithMessage("FV. Esse campo deve conter entre 3 e 1000 caracteres");

            RuleFor(c => c.Prioridade)
                .IsInEnum()
                .WithMessage("FV. Valor inválido (1-Alta, 2-Média, 3-Baixa)");
        }
    }
}
