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
    public class TarefaServiceTest
    {
        private readonly ITarefaRepository tarefaRepository;

        private readonly ITarefaService tarefaService;

        public TarefaServiceTest()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TarefaMapper());
            });

            var mapper = mapperConfiguration.CreateMapper();

            DbContextOptions<DataContext> dataContextOptions =
                new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("dados").Options;

            DataContext dataContext = new DataContext(dataContextOptions);

            tarefaRepository = new TarefaRepository(dataContext);

            tarefaService = new TarefaService(mapper, tarefaRepository);
        }

        [Fact]
        public async void GetAllAsync()
        {
            // Arrange
            var tarefaPostInputModel1 = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPostInputModel2 = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPostInputModel3 = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPostInputModel4 = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPostInputModel5 = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var deletedAll = await tarefaService.DeleteAllAsync();
            var addedTarefa1 = await tarefaService.AddAsync(tarefaPostInputModel1);
            var addedTarefa2 = await tarefaService.AddAsync(tarefaPostInputModel2);
            var addedTarefa3 = await tarefaService.AddAsync(tarefaPostInputModel3);
            var addedTarefa4 = await tarefaService.AddAsync(tarefaPostInputModel4);
            var addedTarefa5 = await tarefaService.AddAsync(tarefaPostInputModel5);
            var tarefas = await tarefaService.GetAllAsync();

            // Assert
            Assert.True(deletedAll);
            Assert.NotNull(tarefas);
            Assert.True(tarefas.Count() == 5);

            deletedAll.ShouldBe(true);
            tarefas.ShouldNotBeNull();
            tarefas.Count().ShouldBe(5);
        }

        [Fact]
        public async void GetByIdAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var addedTarefa = await tarefaService.AddAsync(tarefaPostInputModel);
            var tarefa = await tarefaService.GetByIdAsync(addedTarefa.Id);

            // Assert
            Assert.NotNull(tarefa);
            Assert.Equal(tarefa.Id, addedTarefa.Id);
            Assert.Equal(tarefa.Nome, tarefaPostInputModel.Nome);
            Assert.Equal(tarefa.Descricao, tarefaPostInputModel.Descricao);
            Assert.Equal(tarefa.DataInicio, tarefaPostInputModel.DataInicio);
            Assert.Equal(tarefa.DataTermino, tarefaPostInputModel.DataTermino);
            Assert.Equal(tarefa.Prioridade, tarefaPostInputModel.Prioridade);

            tarefa.ShouldNotBeNull();
            tarefa.Id.ShouldBe(addedTarefa.Id);
            tarefa.Nome.ShouldBe(tarefaPostInputModel.Nome);
            tarefa.Descricao.ShouldBe(tarefaPostInputModel.Descricao);
            tarefa.DataInicio.ShouldBe(tarefaPostInputModel.DataInicio);
            tarefa.DataTermino.ShouldBe(tarefaPostInputModel.DataTermino);
            tarefa.Prioridade.ShouldBe(tarefaPostInputModel.Prioridade);
        }

        [Fact]
        public async void AddAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var tarefa = await tarefaService.AddAsync(tarefaPostInputModel);

            // Assert
            Assert.NotNull(tarefa);
            Assert.True(tarefa.Id > 0);
            Assert.Equal(tarefa.Nome, tarefaPostInputModel.Nome);
            Assert.Equal(tarefa.Descricao, tarefaPostInputModel.Descricao);
            Assert.Equal(tarefa.DataInicio, tarefaPostInputModel.DataInicio);
            Assert.Equal(tarefa.DataTermino, tarefaPostInputModel.DataTermino);
            Assert.Equal(tarefa.Prioridade, tarefaPostInputModel.Prioridade);

            tarefa.ShouldNotBeNull();
            tarefa.Id.ShouldNotBe(0);
            tarefa.Nome.ShouldBe(tarefaPostInputModel.Nome);
            tarefa.Descricao.ShouldBe(tarefaPostInputModel.Descricao);
            tarefa.DataInicio.ShouldBe(tarefaPostInputModel.DataInicio);
            tarefa.DataTermino.ShouldBe(tarefaPostInputModel.DataTermino);
            tarefa.Prioridade.ShouldBe(tarefaPostInputModel.Prioridade);
        }

        [Fact]
        public async void UpdateAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPutInputModel = new Fixture().Create<TarefaPutInputModel>();

            // Act
            var addedTarefa = await tarefaService.AddAsync(tarefaPostInputModel);
            var tarefa = await tarefaService.UpdateAsync(addedTarefa.Id, tarefaPutInputModel);

            // Assert
            Assert.NotNull(tarefa);
            Assert.Equal(tarefa.Id, addedTarefa.Id);
            Assert.Equal(tarefa.Nome, tarefaPostInputModel.Nome);
            Assert.Equal(tarefa.Descricao, tarefaPutInputModel.Descricao);
            Assert.Equal(tarefa.DataInicio, tarefaPutInputModel.DataInicio);
            Assert.Equal(tarefa.DataTermino, tarefaPutInputModel.DataTermino);
            Assert.Equal(tarefa.Prioridade, tarefaPutInputModel.Prioridade);

            tarefa.ShouldNotBeNull();
            tarefa.Id.ShouldBe(addedTarefa.Id);
            tarefa.Nome.ShouldBe(tarefaPostInputModel.Nome);
            tarefa.Descricao.ShouldBe(tarefaPutInputModel.Descricao);
            tarefa.DataInicio.ShouldBe(tarefaPutInputModel.DataInicio);
            tarefa.DataTermino.ShouldBe(tarefaPutInputModel.DataTermino);
            tarefa.Prioridade.ShouldBe(tarefaPutInputModel.Prioridade);
        }

        [Fact]
        public async void DeleteAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var addedTarefa = await tarefaService.AddAsync(tarefaPostInputModel);
            var deletedTarefa = await tarefaService.DeleteAsync(addedTarefa.Id);
            var tarefa = await tarefaService.GetByIdAsync(deletedTarefa.Id);

            // Assert
            Assert.NotNull(addedTarefa);
            Assert.True(addedTarefa.Id > 0);
            Assert.NotNull(deletedTarefa);
            Assert.Equal(deletedTarefa.Id, addedTarefa.Id);
            Assert.Null(tarefa);

            addedTarefa.ShouldNotBeNull();
            addedTarefa.Id.ShouldNotBe(0);
            deletedTarefa.ShouldNotBeNull();
            deletedTarefa.Id.ShouldBe(addedTarefa.Id);
            tarefa.ShouldBeNull();
        }

        [Fact]
        public void GetAll()
        {
            // Arrange
            var tarefaPostInputModel1 = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPostInputModel2 = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPostInputModel3 = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPostInputModel4 = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPostInputModel5 = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var deletedAll = tarefaService.DeleteAll();
            var addedTarefa1 = tarefaService.Add(tarefaPostInputModel1);
            var addedTarefa2 = tarefaService.Add(tarefaPostInputModel2);
            var addedTarefa3 = tarefaService.Add(tarefaPostInputModel3);
            var addedTarefa4 = tarefaService.Add(tarefaPostInputModel4);
            var addedTarefa5 = tarefaService.Add(tarefaPostInputModel5);
            var tarefas = tarefaService.GetAll();

            // Assert
            Assert.True(deletedAll);
            Assert.NotNull(tarefas);
            Assert.True(tarefas.Count() == 5);

            deletedAll.ShouldBe(true);
            tarefas.ShouldNotBeNull();
            tarefas.Count().ShouldBe(5);
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var addedTarefa = tarefaService.Add(tarefaPostInputModel);
            var tarefa = tarefaService.GetById(addedTarefa.Id);

            // Assert
            Assert.NotNull(tarefa);
            Assert.Equal(tarefa.Id, addedTarefa.Id);
            Assert.Equal(tarefa.Nome, tarefaPostInputModel.Nome);
            Assert.Equal(tarefa.Descricao, tarefaPostInputModel.Descricao);
            Assert.Equal(tarefa.DataInicio, tarefaPostInputModel.DataInicio);
            Assert.Equal(tarefa.DataTermino, tarefaPostInputModel.DataTermino);
            Assert.Equal(tarefa.Prioridade, tarefaPostInputModel.Prioridade);

            tarefa.ShouldNotBeNull();
            tarefa.Id.ShouldBe(addedTarefa.Id);
            tarefa.Nome.ShouldBe(tarefaPostInputModel.Nome);
            tarefa.Descricao.ShouldBe(tarefaPostInputModel.Descricao);
            tarefa.DataInicio.ShouldBe(tarefaPostInputModel.DataInicio);
            tarefa.DataTermino.ShouldBe(tarefaPostInputModel.DataTermino);
            tarefa.Prioridade.ShouldBe(tarefaPostInputModel.Prioridade);
        }

        [Fact]
        public void Add()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var tarefa = tarefaService.Add(tarefaPostInputModel);

            // Assert
            Assert.NotNull(tarefa);
            Assert.True(tarefa.Id > 0);
            Assert.Equal(tarefa.Nome, tarefaPostInputModel.Nome);
            Assert.Equal(tarefa.Descricao, tarefaPostInputModel.Descricao);
            Assert.Equal(tarefa.DataInicio, tarefaPostInputModel.DataInicio);
            Assert.Equal(tarefa.DataTermino, tarefaPostInputModel.DataTermino);
            Assert.Equal(tarefa.Prioridade, tarefaPostInputModel.Prioridade);

            tarefa.ShouldNotBeNull();
            tarefa.Id.ShouldNotBe(0);
            tarefa.Nome.ShouldBe(tarefaPostInputModel.Nome);
            tarefa.Descricao.ShouldBe(tarefaPostInputModel.Descricao);
            tarefa.DataInicio.ShouldBe(tarefaPostInputModel.DataInicio);
            tarefa.DataTermino.ShouldBe(tarefaPostInputModel.DataTermino);
            tarefa.Prioridade.ShouldBe(tarefaPostInputModel.Prioridade);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPutInputModel = new Fixture().Create<TarefaPutInputModel>();

            // Act
            var addedTarefa = tarefaService.Add(tarefaPostInputModel);
            var tarefa = tarefaService.Update(addedTarefa.Id, tarefaPutInputModel);

            // Assert
            Assert.NotNull(tarefa);
            Assert.Equal(tarefa.Id, addedTarefa.Id);
            Assert.Equal(tarefa.Nome, tarefaPostInputModel.Nome);
            Assert.Equal(tarefa.Descricao, tarefaPutInputModel.Descricao);
            Assert.Equal(tarefa.DataInicio, tarefaPutInputModel.DataInicio);
            Assert.Equal(tarefa.DataTermino, tarefaPutInputModel.DataTermino);
            Assert.Equal(tarefa.Prioridade, tarefaPutInputModel.Prioridade);

            tarefa.ShouldNotBeNull();
            tarefa.Id.ShouldBe(addedTarefa.Id);
            tarefa.Nome.ShouldBe(tarefaPostInputModel.Nome);
            tarefa.Descricao.ShouldBe(tarefaPutInputModel.Descricao);
            tarefa.DataInicio.ShouldBe(tarefaPutInputModel.DataInicio);
            tarefa.DataTermino.ShouldBe(tarefaPutInputModel.DataTermino);
            tarefa.Prioridade.ShouldBe(tarefaPutInputModel.Prioridade);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var addedTarefa = tarefaService.Add(tarefaPostInputModel);
            var deletedTarefa = tarefaService.Delete(addedTarefa.Id);
            var tarefa = tarefaService.GetById(deletedTarefa.Id);

            // Assert
            Assert.NotNull(addedTarefa);
            Assert.True(addedTarefa.Id > 0);
            Assert.NotNull(deletedTarefa);
            Assert.Equal(deletedTarefa.Id, addedTarefa.Id);
            Assert.Null(tarefa);

            addedTarefa.ShouldNotBeNull();
            addedTarefa.Id.ShouldNotBe(0);
            deletedTarefa.ShouldNotBeNull();
            deletedTarefa.Id.ShouldBe(addedTarefa.Id);
            tarefa.ShouldBeNull();
        }
    }
}
