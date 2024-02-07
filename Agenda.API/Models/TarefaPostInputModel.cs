using System;
using Agenda.API.Entities;

namespace Agenda.API.Models
{
    public record TarefaPostInputModel(
        string Nome,
        string Descricao,
        DateTime DataInicio,
        DateTime DataTermino,
        TarefaEnum Prioridade
    );
}
