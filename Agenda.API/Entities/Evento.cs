namespace Agenda.API.Entities
{
    public class Evento
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public DateTime Data { get; private set; }

        public Evento(string nome, string descricao, DateTime data)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Data = data;
        }

        public void Update(string descricao, DateTime data)
        {
            this.Descricao = descricao;
            this.Data = data;
        }
    }
}
