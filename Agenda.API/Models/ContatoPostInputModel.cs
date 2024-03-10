using System;
using System.ComponentModel.DataAnnotations;
using Agenda.API.Utils;

namespace Agenda.API.Models
{
    public class ContatoPostInputModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Esse campo deve conter entre 3 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "Esse campo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MinLength(10, ErrorMessage = "Esse campo deve conter entre 10 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "Esse campo deve conter entre 10 e 100 caracteres")]
        [RegularExpression(ExpressoesRegulares.EMAIL, ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MinLength(8, ErrorMessage = "Esse campo deve conter entre 8 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "Esse campo deve conter entre 8 e 50 caracteres")]
        [RegularExpression(ExpressoesRegulares.TELEFONE, ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}