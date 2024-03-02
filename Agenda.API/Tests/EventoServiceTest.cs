using Agenda.API.Entities;
using Agenda.API.Models;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services;
using Agenda.API.Services.Interfaces;
using AutoFixture;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace Agenda.API.Tests
{
    public class EventoServiceTest
    {
        private readonly Mock<IEventoRepository> eventoRepoMock;

        private readonly IEventoService eventoService;

        public EventoServiceTest()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();

            eventoRepoMock = new Mock<IEventoRepository>();

            eventoService = new EventoService(mapperMock.Object, eventoRepoMock.Object);
        }

        [Fact]
        public void GetAllAsync()
        {
            // Act
            var eventos = eventoService.GetAllAsync();

            // Assert
            Assert.NotNull(eventos);

            eventos.ShouldNotBeNull();

            eventoRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public void GetByIdAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

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

        [Fact]
        public void AddAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var addedEvento = eventoService.AddAsync(eventoPostInputModel);

            // Assert
            Assert.NotNull(addedEvento);

            addedEvento.ShouldNotBeNull();

            eventoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Evento>()), Times.Once);
        }
    }
}
