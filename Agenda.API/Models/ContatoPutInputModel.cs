using System.ComponentModel.DataAnnotations;
using Agenda.API.Utils;
using FluentValidation;

namespace Agenda.API.Models
{
    public class ContatoPutInputModel
    {
        [Required(ErrorMessage = "DA. Esse campo é obrigatório")]
        [MinLength(10, ErrorMessage = "DA. Esse campo deve conter entre 10 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "DA. Esse campo deve conter entre 10 e 100 caracteres")]
        [RegularExpression(ExpressoesRegulares.EMAIL, ErrorMessage = "DA. E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "DA. Esse campo é obrigatório")]
        [MinLength(8, ErrorMessage = "DA. Esse campo deve conter entre 8 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "DA. Esse campo deve conter entre 8 e 50 caracteres")]
        [RegularExpression(ExpressoesRegulares.TELEFONE, ErrorMessage = "DA. Telefone inválido")]
        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }
    }

    public class ContatoPutInputModelValidator : AbstractValidator<ContatoPutInputModel>
    {
        public ContatoPutInputModelValidator()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.Telefone).NotEmpty().WithMessage("FV. Esse campo é obrigatório");
            RuleFor(c => c.DataNascimento).NotEmpty().WithMessage("FV. Esse campo é obrigatório");

            RuleFor(c => c.Email)
                .Length(10, 100)
                .WithMessage("FV. Esse campo deve conter entre 10 e 100 caracteres");
            RuleFor(c => c.Telefone)
                .Length(8, 50)
                .WithMessage("FV. Esse campo deve conter entre 8 e 50 caracteres");

            RuleFor(c => c.Email)
                .Matches(ExpressoesRegulares.EMAIL)
                .WithMessage("FV. E-mail inválido");
            RuleFor(c => c.Telefone)
                .Matches(ExpressoesRegulares.TELEFONE)
                .WithMessage("FV. Telefone inválido");

            RuleFor(c => c.Email).EmailAddress().WithMessage("FV. E-mail inválido (FV)");
        }
    }
}
