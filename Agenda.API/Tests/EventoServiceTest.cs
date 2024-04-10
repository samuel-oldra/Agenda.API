using Agenda.API.Data;
using Agenda.API.Mappers;
using Agenda.API.Models;
using Agenda.API.Repositories;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services;
using Agenda.API.Services.Interfaces;
using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Agenda.API.Tests
{
    public class EventoServiceTest
    {
        private readonly IEventoRepository eventoRepository;

        private readonly IEventoService eventoService;

        public EventoServiceTest()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EventoMapper());
            });

            var mapper = mapperConfiguration.CreateMapper();

            DbContextOptions<DataContext> dataContextOptions =
                new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("dados").Options;

            DataContext dataContext = new DataContext(dataContextOptions);

            eventoRepository = new EventoRepository(dataContext);

            eventoService = new EventoService(mapper, eventoRepository);
        }

        [Fact]
        public async void GetAllAsync()
        {
            // Arrange
            var eventoPostInputModel1 = new Fixture().Create<EventoPostInputModel>();
            var eventoPostInputModel2 = new Fixture().Create<EventoPostInputModel>();
            var eventoPostInputModel3 = new Fixture().Create<EventoPostInputModel>();
            var eventoPostInputModel4 = new Fixture().Create<EventoPostInputModel>();
            var eventoPostInputModel5 = new Fixture().Create<EventoPostInputModel>();

            // Act
            var deletedAll = await eventoService.DeleteAllAsync();
            var addedEvento1 = await eventoService.AddAsync(eventoPostInputModel1);
            var addedEvento2 = await eventoService.AddAsync(eventoPostInputModel2);
            var addedEvento3 = await eventoService.AddAsync(eventoPostInputModel3);
            var addedEvento4 = await eventoService.AddAsync(eventoPostInputModel4);
            var addedEvento5 = await eventoService.AddAsync(eventoPostInputModel5);
            var eventos = await eventoService.GetAllAsync();

            // Assert
            Assert.True(deletedAll);
            Assert.NotNull(eventos);
            Assert.True(eventos.Count() == 5);

            deletedAll.ShouldBe(true);
            eventos.ShouldNotBeNull();
            eventos.Count().ShouldBe(5);
        }

        [Fact]
        public async void GetByIdAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var addedEvento = await eventoService.AddAsync(eventoPostInputModel);
            var evento = await eventoService.GetByIdAsync(addedEvento.Id);

            // Assert
            Assert.NotNull(evento);
            Assert.True(evento.Id > 0);
            Assert.Equal(evento.Nome, eventoPostInputModel.Nome);
            Assert.Equal(evento.Descricao, eventoPostInputModel.Descricao);
            Assert.Equal(evento.Data, eventoPostInputModel.Data);

            evento.ShouldNotBeNull();
            evento.Id.ShouldNotBe(0);
            evento.Nome.ShouldBe(eventoPostInputModel.Nome);
            evento.Descricao.ShouldBe(eventoPostInputModel.Descricao);
            evento.Data.ShouldBe(eventoPostInputModel.Data);
        }

        [Fact]
        public async void AddAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var evento = await eventoService.AddAsync(eventoPostInputModel);

            // Assert
            Assert.NotNull(evento);
            Assert.True(evento.Id > 0);
            Assert.Equal(evento.Nome, eventoPostInputModel.Nome);
            Assert.Equal(evento.Descricao, eventoPostInputModel.Descricao);
            Assert.Equal(evento.Data, eventoPostInputModel.Data);

            evento.ShouldNotBeNull();
            evento.Id.ShouldNotBe(0);
            evento.Nome.ShouldBe(eventoPostInputModel.Nome);
            evento.Descricao.ShouldBe(eventoPostInputModel.Descricao);
            evento.Data.ShouldBe(eventoPostInputModel.Data);
        }

        [Fact]
        public async void UpdateAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();
            var eventoPutInputModel = new Fixture().Create<EventoPutInputModel>();

            // Act
            var addedEvento = await eventoService.AddAsync(eventoPostInputModel);
            var evento = await eventoService.UpdateAsync(addedEvento.Id, eventoPutInputModel);

            // Assert
            Assert.NotNull(evento);
            Assert.True(evento.Id > 0);
            Assert.Equal(evento.Nome, eventoPostInputModel.Nome);
            Assert.Equal(evento.Descricao, eventoPutInputModel.Descricao);
            Assert.Equal(evento.Data, eventoPutInputModel.Data);

            evento.ShouldNotBeNull();
            evento.Id.ShouldNotBe(0);
            evento.Nome.ShouldBe(eventoPostInputModel.Nome);
            evento.Descricao.ShouldBe(eventoPutInputModel.Descricao);
            evento.Data.ShouldBe(eventoPutInputModel.Data);
        }

        [Fact]
        public async void DeleteAsync()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var addedEvento = await eventoService.AddAsync(eventoPostInputModel);
            var deletedEvento = await eventoService.DeleteAsync(addedEvento.Id);
            var evento = await eventoService.GetByIdAsync(deletedEvento.Id);

            // Assert
            Assert.NotNull(addedEvento);
            Assert.True(addedEvento.Id > 0);
            Assert.NotNull(deletedEvento);
            Assert.True(deletedEvento.Id > 0);
            Assert.Null(evento);

            addedEvento.ShouldNotBeNull();
            addedEvento.Id.ShouldNotBe(0);
            deletedEvento.ShouldNotBeNull();
            deletedEvento.Id.ShouldNotBe(0);
            evento.ShouldBeNull();
        }

        [Fact]
        public void GetAll()
        {
            // Arrange
            var eventoPostInputModel1 = new Fixture().Create<EventoPostInputModel>();
            var eventoPostInputModel2 = new Fixture().Create<EventoPostInputModel>();
            var eventoPostInputModel3 = new Fixture().Create<EventoPostInputModel>();
            var eventoPostInputModel4 = new Fixture().Create<EventoPostInputModel>();
            var eventoPostInputModel5 = new Fixture().Create<EventoPostInputModel>();

            // Act
            var deletedAll = eventoService.DeleteAll();
            var addedEvento1 = eventoService.Add(eventoPostInputModel1);
            var addedEvento2 = eventoService.Add(eventoPostInputModel2);
            var addedEvento3 = eventoService.Add(eventoPostInputModel3);
            var addedEvento4 = eventoService.Add(eventoPostInputModel4);
            var addedEvento5 = eventoService.Add(eventoPostInputModel5);
            var eventos = eventoService.GetAll();

            // Assert
            Assert.True(deletedAll);
            Assert.NotNull(eventos);
            Assert.True(eventos.Count() == 5);

            deletedAll.ShouldBe(true);
            eventos.ShouldNotBeNull();
            eventos.Count().ShouldBe(5);
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var addedEvento = eventoService.Add(eventoPostInputModel);
            var evento = eventoService.GetById(addedEvento.Id);

            // Assert
            Assert.NotNull(evento);
            Assert.True(evento.Id > 0);
            Assert.Equal(evento.Nome, eventoPostInputModel.Nome);
            Assert.Equal(evento.Descricao, eventoPostInputModel.Descricao);
            Assert.Equal(evento.Data, eventoPostInputModel.Data);

            evento.ShouldNotBeNull();
            evento.Id.ShouldNotBe(0);
            evento.Nome.ShouldBe(eventoPostInputModel.Nome);
            evento.Descricao.ShouldBe(eventoPostInputModel.Descricao);
            evento.Data.ShouldBe(eventoPostInputModel.Data);
        }

        [Fact]
        public void Add()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var evento = eventoService.Add(eventoPostInputModel);

            // Assert
            Assert.NotNull(evento);
            Assert.True(evento.Id > 0);
            Assert.Equal(evento.Nome, eventoPostInputModel.Nome);
            Assert.Equal(evento.Descricao, eventoPostInputModel.Descricao);
            Assert.Equal(evento.Data, eventoPostInputModel.Data);

            evento.ShouldNotBeNull();
            evento.Id.ShouldNotBe(0);
            evento.Nome.ShouldBe(eventoPostInputModel.Nome);
            evento.Descricao.ShouldBe(eventoPostInputModel.Descricao);
            evento.Data.ShouldBe(eventoPostInputModel.Data);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();
            var eventoPutInputModel = new Fixture().Create<EventoPutInputModel>();

            // Act
            var addedEvento = eventoService.Add(eventoPostInputModel);
            var evento = eventoService.Update(addedEvento.Id, eventoPutInputModel);

            // Assert
            Assert.NotNull(evento);
            Assert.True(evento.Id > 0);
            Assert.Equal(evento.Nome, eventoPostInputModel.Nome);
            Assert.Equal(evento.Descricao, eventoPutInputModel.Descricao);
            Assert.Equal(evento.Data, eventoPutInputModel.Data);

            evento.ShouldNotBeNull();
            evento.Id.ShouldNotBe(0);
            evento.Nome.ShouldBe(eventoPostInputModel.Nome);
            evento.Descricao.ShouldBe(eventoPutInputModel.Descricao);
            evento.Data.ShouldBe(eventoPutInputModel.Data);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var eventoPostInputModel = new Fixture().Create<EventoPostInputModel>();

            // Act
            var addedEvento = eventoService.Add(eventoPostInputModel);
            var deletedEvento = eventoService.Delete(addedEvento.Id);
            var evento = eventoService.GetById(deletedEvento.Id);

            // Assert
            Assert.NotNull(addedEvento);
            Assert.True(addedEvento.Id > 0);
            Assert.NotNull(deletedEvento);
            Assert.True(deletedEvento.Id > 0);
            Assert.Null(evento);

            addedEvento.ShouldNotBeNull();
            addedEvento.Id.ShouldNotBe(0);
            deletedEvento.ShouldNotBeNull();
            deletedEvento.Id.ShouldNotBe(0);
            evento.ShouldBeNull();
        }
    }
}
