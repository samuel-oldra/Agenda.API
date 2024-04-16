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
    public class EventoServiceMockTest
    {
        private readonly Mock<IEventoRepository> eventoRepoMock;

        private readonly IEventoService eventoService;

        public EventoServiceMockTest()
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
        public async void GetByIdAsync()
        {
            // Arrange
            var id = new Fixture().Create<int>();

            // Act
            var evento = await eventoService.GetByIdAsync(id);

            // Assert
            eventoRepoMock.Verify(rep => rep.GetByIdAsync(It.IsAny<int>()), Times.Once);
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

            eventoRepoMock.Verify(rep => rep.AddAsync(It.IsAny<Evento>()), Times.Once);
        }

        [Fact]
        public async void UpdateAsync()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var eventoPutInputModel = new Fixture().Create<EventoPutInputModel>();

            // Act
            var updatedEvento = await eventoService.UpdateAsync(id, eventoPutInputModel);

            // Assert
            eventoRepoMock.Verify(rep => rep.GetByIdAsync(It.IsAny<int>()), Times.Once);
            eventoRepoMock.Verify(rep => rep.UpdateAsync(It.IsAny<Evento>()), Times.AtMostOnce());
        }

        [Fact]
        public async void DeleteAsync()
        {
            // Arrange
            var id = new Fixture().Create<int>();

            // Act
            var deletedEvento = await eventoService.DeleteAsync(id);

            // Assert
            eventoRepoMock.Verify(rep => rep.GetByIdAsync(It.IsAny<int>()), Times.Once);
            eventoRepoMock.Verify(rep => rep.DeleteAsync(It.IsAny<Evento>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            var id = new Fixture().Create<int>();

            // Act
            var evento = eventoService.GetById(id);

            // Assert
            eventoRepoMock.Verify(rep => rep.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Add()
        {
            // Arrange
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

            eventoRepoMock.Verify(rep => rep.Add(It.IsAny<Evento>()), Times.Once);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var eventoPutInputModel = new Fixture().Create<EventoPutInputModel>();

            // Act
            var updatedEvento = eventoService.Update(id, eventoPutInputModel);

            // Assert
            eventoRepoMock.Verify(rep => rep.GetById(It.IsAny<int>()), Times.Once);
            eventoRepoMock.Verify(rep => rep.Update(It.IsAny<Evento>()), Times.AtMostOnce());
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var id = new Fixture().Create<int>();

            // Act
            var deletedEvento = eventoService.Delete(id);

            // Assert
            eventoRepoMock.Verify(rep => rep.GetById(It.IsAny<int>()), Times.Once);
            eventoRepoMock.Verify(rep => rep.Delete(It.IsAny<Evento>()), Times.AtMostOnce());
        }
    }
}
