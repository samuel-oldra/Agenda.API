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
    public class TarefaServiceTest
    {
        [Fact]
        [Benchmark]
        public void TarefaServiceTest_GetAllAsync()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var tarefaRepoMock = new Mock<ITarefaRepository>();

            var tarefaService = new TarefaService(mapperMock.Object, tarefaRepoMock.Object);

            // Act
            var tarefas = tarefaService.GetAllAsync();

            // Assert
            Assert.NotNull(tarefas);

            tarefas.ShouldNotBeNull();

            tarefaRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public void TarefaServiceTest_GetByIdAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            var mapperMock = new Mock<IMapper>();
            var tarefaRepoMock = new Mock<ITarefaRepository>();

            var tarefaService = new TarefaService(mapperMock.Object, tarefaRepoMock.Object);

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
        public void TarefaServiceTest_AddAsync()
        {
            // Arrange
            var tarefaPostInputModel = new Fixture().Create<TarefaPostInputModel>();

            var mapperMock = new Mock<IMapper>();
            var tarefaRepoMock = new Mock<ITarefaRepository>();

            var tarefaService = new TarefaService(mapperMock.Object, tarefaRepoMock.Object);

            // Act
            var addedTarefa = tarefaService.AddAsync(tarefaPostInputModel);

            // Assert
            Assert.NotNull(addedTarefa);

            addedTarefa.ShouldNotBeNull();

            tarefaRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Tarefa>()), Times.Once);
        }
    }
}
