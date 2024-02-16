using Agenda.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }
    }
}
