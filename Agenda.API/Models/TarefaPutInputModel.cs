using System;
using Agenda.API.Entities;

namespace Agenda.API.Models
{
    public record TarefaPutInputModel(
        string Descricao,
        DateTime DataInicio,
        DateTime DataTermino,
        TarefaEnum Prioridade
    );
}
