using Agenda.API.Entities;
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
    public class EventoServiceTest
    {
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
        public void EventoServiceTest_GetByIdAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            var mapperMock = new Mock<IMapper>();
            var eventoRepoMock = new Mock<IEventoRepository>();

            var eventoService = new EventoService(mapperMock.Object, eventoRepoMock.Object);

            // Act
            var addedEvento = eventoService.AddAsync(eventoPostInputModel);
            var evento = eventoService.GetByIdAsync(addedEvento.Id);

            // Assert
            Assert.NotNull(addedEvento);
            Assert.NotNull(evento);

            addedEvento.ShouldNotBeNull();
            evento.ShouldNotBeNull();

            eventoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Evento>()), Times.Once);
            eventoRepoMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
