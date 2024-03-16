using System.ComponentModel.DataAnnotations;

namespace Agenda.API.Models
{
    public class EventoPutInputModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Esse campo deve conter entre 3 e 1000 caracteres")]
        [MaxLength(1000, ErrorMessage = "Esse campo deve conter entre 3 e 1000 caracteres")]
        public string Descricao { get; set; }

        public DateTime Data { get; set; }
    }
}
