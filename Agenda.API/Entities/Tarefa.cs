namespace Agenda.API.Entities
{
    public class Tarefa
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataTermino { get; private set; }

        public TarefaEnum Prioridade { get; private set; }

        public Tarefa(
            string nome,
            string descricao,
            DateTime dataInicio,
            DateTime dataTermino,
            TarefaEnum prioridade
        )
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataInicio = dataInicio;
            this.DataTermino = dataTermino;
            this.Prioridade = prioridade;
        }

        public void Update(
            string descricao,
            DateTime dataInicio,
            DateTime dataTermino,
            TarefaEnum prioridade
        )
        {
            this.Descricao = descricao;
            this.DataInicio = dataInicio;
            this.DataTermino = dataTermino;
            this.Prioridade = prioridade;
        }
    }
}
