using Agenda.API.Entities;
using Agenda.API.Mappers;
using Agenda.API.Models;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services;
using AutoFixture;
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
        public void ContatoServiceTest_Add()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapper());
            });
            var mapperObject = mapperConfiguration.CreateMapper();

            var contatoRepoMock = new Mock<IContatoRepository>();

            var contatoService = new ContatoService(mapperObject, contatoRepoMock.Object);

            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var addedContato = contatoService.Add(contatoPostInputModel);

            // Assert
            Assert.NotNull(addedContato);
            Assert.Equal(addedContato.Nome, contatoPostInputModel.Nome);
            Assert.Equal(addedContato.Email, contatoPostInputModel.Email);
            Assert.Equal(addedContato.Telefone, contatoPostInputModel.Telefone);
            Assert.Equal(addedContato.DataNascimento, contatoPostInputModel.DataNascimento);

            addedContato.ShouldNotBeNull();
            addedContato.Nome.ShouldBe(contatoPostInputModel.Nome);
            addedContato.Email.ShouldBe(contatoPostInputModel.Email);
            addedContato.Telefone.ShouldBe(contatoPostInputModel.Telefone);
            addedContato.DataNascimento.ShouldBe(contatoPostInputModel.DataNascimento);

            contatoRepoMock.Verify(repo => repo.Add(It.IsAny<Contato>()), Times.Once);
        }

        [Fact]
        [Benchmark]
        public void EventoServiceTest_Add()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EventoMapper());
            });
            var mapperObject = mapperConfiguration.CreateMapper();

            var eventoRepoMock = new Mock<IEventoRepository>();

            var eventoService = new EventoService(mapperObject, eventoRepoMock.Object);

            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var addedEvento = eventoService.Add(eventoPostInputModel);

            // Assert
            Assert.NotNull(addedEvento);
            Assert.Equal(addedEvento.Nome, eventoPostInputModel.Nome);
            Assert.Equal(addedEvento.Descricao, eventoPostInputModel.Descricao);
            Assert.Equal(addedEvento.Data, eventoPostInputModel.Data);

            addedEvento.ShouldNotBeNull();
            addedEvento.Nome.ShouldBe(eventoPostInputModel.Nome);
            addedEvento.Descricao.ShouldBe(eventoPostInputModel.Descricao);
            addedEvento.Data.ShouldBe(eventoPostInputModel.Data);

            eventoRepoMock.Verify(repo => repo.Add(It.IsAny<Evento>()), Times.Once);
        }

        [Fact]
        [Benchmark]
        public void TarefaServiceTest_Add()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TarefaMapper());
            });
            var mapperObject = mapperConfiguration.CreateMapper();

            var tarefaRepoMock = new Mock<ITarefaRepository>();

            var tarefaService = new TarefaService(mapperObject, tarefaRepoMock.Object);

            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var addedTarefa = tarefaService.Add(tarefaPostInputModel);

            // Assert
            Assert.NotNull(addedTarefa);
            Assert.Equal(addedTarefa.Nome, tarefaPostInputModel.Nome);
            Assert.Equal(addedTarefa.Descricao, tarefaPostInputModel.Descricao);
            Assert.Equal(addedTarefa.DataInicio, tarefaPostInputModel.DataInicio);
            Assert.Equal(addedTarefa.DataTermino, tarefaPostInputModel.DataTermino);
            Assert.Equal(addedTarefa.Prioridade, tarefaPostInputModel.Prioridade);

            addedTarefa.ShouldNotBeNull();
            addedTarefa.Nome.ShouldBe(tarefaPostInputModel.Nome);
            addedTarefa.Descricao.ShouldBe(tarefaPostInputModel.Descricao);
            addedTarefa.DataInicio.ShouldBe(tarefaPostInputModel.DataInicio);
            addedTarefa.DataTermino.ShouldBe(tarefaPostInputModel.DataTermino);
            addedTarefa.Prioridade.ShouldBe(tarefaPostInputModel.Prioridade);

            tarefaRepoMock.Verify(repo => repo.Add(It.IsAny<Tarefa>()), Times.Once);
        }
    }
}
