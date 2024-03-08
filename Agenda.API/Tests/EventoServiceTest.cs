using Agenda.API.Entities;
using Agenda.API.Mappers;
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
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EventoMapper());
            });
            var mapperObject = mapperConfiguration.CreateMapper();

            eventoRepoMock = new Mock<IEventoRepository>();

            eventoService = new EventoService(mapperObject, eventoRepoMock.Object);
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
        public async void AddAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var addedEvento = await eventoService.AddAsync(eventoPostInputModel);

            // Assert
            Assert.NotNull(addedEvento);
            Assert.Equal(addedEvento.Nome, eventoPostInputModel.Nome);
            Assert.Equal(addedEvento.Descricao, eventoPostInputModel.Descricao);
            Assert.Equal(addedEvento.Data, eventoPostInputModel.Data);

            addedEvento.ShouldNotBeNull();
            addedEvento.Nome.ShouldBe(eventoPostInputModel.Nome);
            addedEvento.Descricao.ShouldBe(eventoPostInputModel.Descricao);
            addedEvento.Data.ShouldBe(eventoPostInputModel.Data);

            eventoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Evento>()), Times.Once);
        }

        [Fact]
        public void UpdateAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();
            var eventoPutInputModel = new Fixture().Create<EventoPutInputModel>();

            // Act
            var addedEvento = eventoService.AddAsync(eventoPostInputModel);
            var updatedEvento = eventoService.UpdateAsync(addedEvento.Id, eventoPutInputModel);

            // Assert
            Assert.NotNull(addedEvento);
            Assert.NotNull(updatedEvento);

            addedEvento.ShouldNotBeNull();
            updatedEvento.ShouldNotBeNull();

            eventoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Evento>()), Times.Once);
            eventoRepoMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
            eventoRepoMock.Verify(repo => repo.UpdateAsync(It.IsAny<Evento>()), Times.AtMostOnce);
        }

        [Fact]
        public void DeleteAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var addedEvento = eventoService.AddAsync(eventoPostInputModel);
            var deletedEvento = eventoService.DeleteAsync(addedEvento.Id);

            // Assert
            Assert.NotNull(addedEvento);
            Assert.NotNull(deletedEvento);

            addedEvento.ShouldNotBeNull();
            deletedEvento.ShouldNotBeNull();

            eventoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Evento>()), Times.Once);
            eventoRepoMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
            eventoRepoMock.Verify(repo => repo.DeleteAsync(It.IsAny<Evento>()), Times.AtMostOnce);
        }
    }
}
