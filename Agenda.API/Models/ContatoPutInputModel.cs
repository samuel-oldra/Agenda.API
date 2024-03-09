using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.API.Models
{
    public class ContatoPutInputModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Esse campo deve conter entre 3 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "Esse campo deve conter entre 3 e 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Esse campo deve conter entre 3 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "Esse campo deve conter entre 3 e 50 caracteres")]
        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
