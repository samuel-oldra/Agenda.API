namespace Agenda.API.Models
{
    public record ContatoViewModel(
        int Id,
        string Nome,
        string Email,
        string Telefone,
        DateTime DataNascimento
    );
}