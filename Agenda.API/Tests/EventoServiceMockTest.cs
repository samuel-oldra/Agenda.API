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

            eventoRepoMock.Verify(repo => repo.Add(It.IsAny<Evento>()), Times.Once);
        }
    }
}
