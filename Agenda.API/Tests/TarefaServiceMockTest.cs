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
    public class TarefaServiceMockTest
    {
        private readonly Mock<ITarefaRepository> tarefaRepoMock;

        private readonly ITarefaService tarefaService;

        public TarefaServiceMockTest()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TarefaMapper());
            });
            var mapperObject = mapperConfiguration.CreateMapper();

            tarefaRepoMock = new Mock<ITarefaRepository>();

            tarefaService = new TarefaService(mapperObject, tarefaRepoMock.Object);
        }

        [Fact]
        public async void AddAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var addedTarefa = await tarefaService.AddAsync(tarefaPostInputModel);

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

            tarefaRepoMock.Verify(rep => rep.AddAsync(It.IsAny<Tarefa>()), Times.Once);
        }

        [Fact]
        public async void UpdateAsync()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var tarefaPutInputModel = new Fixture().Create<TarefaPutInputModel>();

            // Act
            var updatedTarefa = await tarefaService.UpdateAsync(id, tarefaPutInputModel);

            // Assert
            tarefaRepoMock.Verify(rep => rep.GetByIdAsync(It.IsAny<int>()), Times.Once);
            tarefaRepoMock.Verify(rep => rep.UpdateAsync(It.IsAny<Tarefa>()), Times.AtMostOnce());
        }

        [Fact]
        public async void DeleteAsync()
        {
            // Arrange
            var id = new Fixture().Create<int>();

            // Act
            var deletedTarefa = await tarefaService.DeleteAsync(id);

            // Assert
            tarefaRepoMock.Verify(rep => rep.GetByIdAsync(It.IsAny<int>()), Times.Once);
            tarefaRepoMock.Verify(rep => rep.DeleteAsync(It.IsAny<Tarefa>()), Times.AtMostOnce());
        }

        [Fact]
        public void Add()
        {
            // Arrange
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

            tarefaRepoMock.Verify(rep => rep.Add(It.IsAny<Tarefa>()), Times.Once);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var tarefaPutInputModel = new Fixture().Create<TarefaPutInputModel>();

            // Act
            var updatedTarefa = tarefaService.Update(id, tarefaPutInputModel);

            // Assert
            tarefaRepoMock.Verify(rep => rep.GetById(It.IsAny<int>()), Times.Once);
            tarefaRepoMock.Verify(rep => rep.Update(It.IsAny<Tarefa>()), Times.AtMostOnce());
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var id = new Fixture().Create<int>();

            // Act
            var deletedTarefa = tarefaService.Delete(id);

            // Assert
            tarefaRepoMock.Verify(rep => rep.GetById(It.IsAny<int>()), Times.Once);
            tarefaRepoMock.Verify(rep => rep.Delete(It.IsAny<Tarefa>()), Times.AtMostOnce());
        }
    }
}
