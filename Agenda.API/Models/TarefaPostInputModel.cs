using System.ComponentModel.DataAnnotations;
using Agenda.API.Entities;

namespace Agenda.API.Models
{
    public class TarefaPostInputModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Esse campo deve conter entre 3 e 100 caracteres")]
        [MaxLength(100, ErrorMessage = "Esse campo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Esse campo deve conter entre 3 e 1000 caracteres")]
        [MaxLength(1000, ErrorMessage = "Esse campo deve conter entre 3 e 1000 caracteres")]
        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, 3, ErrorMessage = "Valor inválido (1-Alta, 2-Média, 3-Baixa)")]
        public TarefaEnum Prioridade { get; set; }
    }
}
