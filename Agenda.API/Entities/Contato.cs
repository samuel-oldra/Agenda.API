namespace Agenda.API.Entities
{
    public class Contato
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public Contato(string nome, string email, string telefone, DateTime dataNascimento)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.DataNascimento = dataNascimento;
        }

        public void Update(string email, string telefone, DateTime dataNascimento)
        {
            this.Email = email;
            this.Telefone = telefone;
            this.DataNascimento = dataNascimento;
        }
    }
}
