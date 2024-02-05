using System;

namespace Agenda.API.Models
{
    public record EventoPostInputModel(string Nome, string Descricao, DateTime Data);
}
