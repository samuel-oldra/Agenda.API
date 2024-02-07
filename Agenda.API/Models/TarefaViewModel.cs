using System;
using Agenda.API.Entities;

namespace Agenda.API.Models
{
    public record TarefaViewModel(
        int Id,
        string Nome,
        string Descricao,
        DateTime DataInicio,
        DateTime DataTermino,
        TarefaEnum Prioridade
    );
}
