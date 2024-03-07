using System;

namespace Agenda.API.Models
{
    public record ContatoPutInputModel(string Email, string Telefone, DateTime DataNascimento);
}
