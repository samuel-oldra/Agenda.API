using System;

namespace Agenda.API.Models
{
    public record TarefaPutInputModel(string Descricao, DateTime DataInicio, DateTime DataTermino);
}
