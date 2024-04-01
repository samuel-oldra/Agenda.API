using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Moq;
using Shouldly;
using Xunit;

namespace Agenda.API.Tests
{
    public class PerformanceTest
    {
        [Fact]
        [Benchmark]
        public void ContatoServiceTest_GetAllAsync()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();

            var contatoRepoMock = new Mock<IContatoRepository>();

            var contatoService = new ContatoService(mapperMock.Object, contatoRepoMock.Object);

            // Act
            var contatos = contatoService.GetAllAsync();

            // Assert
            Assert.NotNull(contatos);

            contatos.ShouldNotBeNull();

            contatoRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        [Benchmark]
        public void EventoServiceTest_GetAllAsync()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();

            var eventoRepoMock = new Mock<IEventoRepository>();

            var eventoService = new EventoService(mapperMock.Object, eventoRepoMock.Object);

            // Act
            var eventos = eventoService.GetAllAsync();

            // Assert
            Assert.NotNull(eventos);

            eventos.ShouldNotBeNull();

            eventoRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        [Benchmark]
        public void TarefaServiceTest_GetAllAsync()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();

            var tarefaRepoMock = new Mock<ITarefaRepository>();

            var tarefaService = new TarefaService(mapperMock.Object, tarefaRepoMock.Object);

            // Act
            var tarefas = tarefaService.GetAllAsync();

            // Assert
            Assert.NotNull(tarefas);

            tarefas.ShouldNotBeNull();

            tarefaRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }
    }
}
