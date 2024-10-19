using Agenda.API.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Agenda.API.Models
{
    public class TarefaPostInputModel
    {
        [Required(ErrorMessage = "DA. Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "DA. Esse campo deve conter entre 3 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "DA. Esse campo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "DA. Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "DA. Esse campo deve conter entre 3 e 1000 caracteres")]
        [MaxLength(1000, ErrorMessage = "DA. Esse campo deve conter entre 3 e 1000 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        [Range(1, 3, ErrorMessage = "DA. Valor inválido (1-Alta, 2-Média, 3-Baixa)")]
        public TarefaEnum Prioridade { get; set; }
    }

    public class TarefaPostInputModelValidator : AbstractValidator<TarefaPostInputModel>
    {
        public TarefaPostInputModelValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.Descricao).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.DataInicio).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.DataTermino).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.Prioridade).NotEmpty().WithMessage("FV. Esse campo é obrigatório");

            RuleFor(c => c.Nome)
                .Length(3, 100)
                .WithMessage("FV. Esse campo deve conter entre 3 e 100 caracteres");
            RuleFor(c => c.Descricao)
                .Length(3, 1000)
                .WithMessage("FV. Esse campo deve conter entre 3 e 1000 caracteres");

            RuleFor(c => c.Prioridade)
                .IsInEnum()
                .WithMessage("FV. Valor inválido (1-Alta, 2-Média, 3-Baixa)");
        }
    }
}