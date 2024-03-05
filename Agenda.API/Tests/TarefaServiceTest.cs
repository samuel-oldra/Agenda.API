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
    public class TarefaServiceTest
    {
        private readonly Mock<ITarefaRepository> tarefaRepoMock;

        private readonly ITarefaService tarefaService;

        public TarefaServiceTest()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();

            tarefaRepoMock = new Mock<ITarefaRepository>();

            tarefaService = new TarefaService(mapperMock.Object, tarefaRepoMock.Object);
        }

        [Fact]
        public void GetAllAsync()
        {
            // Act
            var tarefas = tarefaService.GetAllAsync();

            // Assert
            Assert.NotNull(tarefas);

            tarefas.ShouldNotBeNull();

            tarefaRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public void GetByIdAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var addedTarefa = tarefaService.AddAsync(tarefaPostInputModel);
            var tarefa = tarefaService.GetByIdAsync(addedTarefa.Id);

            // Assert
            Assert.NotNull(addedTarefa);
            Assert.NotNull(tarefa);

            addedTarefa.ShouldNotBeNull();
            tarefa.ShouldNotBeNull();

            tarefaRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Tarefa>()), Times.Once);
            tarefaRepoMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void AddAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var addedTarefa = tarefaService.AddAsync(tarefaPostInputModel);

            // Assert
            Assert.NotNull(addedTarefa);

            addedTarefa.ShouldNotBeNull();

            tarefaRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Tarefa>()), Times.Once);
        }

        [Fact]
        public void UpdateAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();
            var tarefaPutInputModel = new Fixture().Create<TarefaPutInputModel>();

            // Act
            var addedTarefa = tarefaService.AddAsync(tarefaPostInputModel);
            var updatedTarefa = tarefaService.UpdateAsync(addedTarefa.Id, tarefaPutInputModel);

            // Assert
            Assert.NotNull(addedTarefa);
            Assert.NotNull(updatedTarefa);

            addedTarefa.ShouldNotBeNull();
            updatedTarefa.ShouldNotBeNull();

            tarefaRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Tarefa>()), Times.Once);
            tarefaRepoMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
            tarefaRepoMock.Verify(repo => repo.UpdateAsync(It.IsAny<Tarefa>()), Times.AtMostOnce);
        }

        [Fact]
        public void DeleteAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            // Act
            var addedTarefa = tarefaService.AddAsync(tarefaPostInputModel);
            var deletedTarefa = tarefaService.DeleteAsync(addedTarefa.Id);

            // Assert
            Assert.NotNull(addedTarefa);
            Assert.NotNull(deletedTarefa);

            addedTarefa.ShouldNotBeNull();
            deletedTarefa.ShouldNotBeNull();

            tarefaRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Tarefa>()), Times.Once);
            tarefaRepoMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
            tarefaRepoMock.Verify(repo => repo.DeleteAsync(It.IsAny<Tarefa>()), Times.AtMostOnce);
        }
    }
}
