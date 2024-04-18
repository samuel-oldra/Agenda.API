using Agenda.API.Data;
using Agenda.API.Mappers;
using Agenda.API.Models;
using Agenda.API.Repositories;
using Agenda.API.Services;
using AutoFixture;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Agenda.API.Tests
{
    public class PerformanceTest
    {
        [Fact]
        [Benchmark]
        public void Contatos_Add100_GetAll_Count()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapper());
            });

            var mapper = mapperConfiguration.CreateMapper();

            DbContextOptions<DataContext> dataContextOptions =
                new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase("dados_performance")
                    .Options;

            DataContext dataContext = new DataContext(dataContextOptions);

            var contatoRepository = new ContatoRepository(dataContext);

            var contatoService = new ContatoService(mapper, contatoRepository);

            // Act
            var deletedAll = contatoService.DeleteAll();

            for (int i = 0; i < 100; i++)
            {
                var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();
                var contato = contatoService.Add(contatoPostInputModel);
            }

            var contatos = contatoService.GetAll();

            // Assert
            Assert.True(deletedAll);
            Assert.NotNull(contatos);
            Assert.True(contatos.Count() == 100);

            deletedAll.ShouldBe(true);
            contatos.ShouldNotBeNull();
            contatos.Count().ShouldBe(100);
        }

        [Fact]
        [Benchmark]
        public void Eventos_Add100_GetAll_Count()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EventoMapper());
            });

            var mapper = mapperConfiguration.CreateMapper();

            DbContextOptions<DataContext> dataContextOptions =
                new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase("dados_performance")
                    .Options;

            DataContext dataContext = new DataContext(dataContextOptions);

            var eventoRepository = new EventoRepository(dataContext);

            var eventoService = new EventoService(mapper, eventoRepository);

            // Act
            var deletedAll = eventoService.DeleteAll();

            for (int i = 0; i < 100; i++)
            {
                var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();
                var evento = eventoService.Add(eventoPostInputModel);
            }

            var eventos = eventoService.GetAll();

            // Assert
            Assert.True(deletedAll);
            Assert.NotNull(eventos);
            Assert.True(eventos.Count() == 100);

            deletedAll.ShouldBe(true);
            eventos.ShouldNotBeNull();
            eventos.Count().ShouldBe(100);
        }

        [Fact]
        [Benchmark]
        public void Tarefas_Add100_GetAll_Count()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TarefaMapper());
            });

            var mapper = mapperConfiguration.CreateMapper();

            DbContextOptions<DataContext> dataContextOptions =
                new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase("dados_performance")
                    .Options;

            DataContext dataContext = new DataContext(dataContextOptions);

            var tarefaRepository = new TarefaRepository(dataContext);

            var tarefaService = new TarefaService(mapper, tarefaRepository);

            // Act
            var deletedAll = tarefaService.DeleteAll();

            for (int i = 0; i < 100; i++)
            {
                var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();
                var tarefa = tarefaService.Add(tarefaPostInputModel);
            }

            var tarefas = tarefaService.GetAll();

            // Assert
            Assert.True(deletedAll);
            Assert.NotNull(tarefas);
            Assert.True(tarefas.Count() == 100);

            deletedAll.ShouldBe(true);
            tarefas.ShouldNotBeNull();
            tarefas.Count().ShouldBe(100);
        }
    }
}
