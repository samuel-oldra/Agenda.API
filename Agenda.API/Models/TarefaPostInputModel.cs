using System;

namespace Agenda.API.Models
{
    public record TarefaPostInputModel(
        string Nome,
        string Descricao,
        DateTime DataInicio,
        DateTime DataTermino
    );
}
