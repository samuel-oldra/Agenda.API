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
    public class ContatoServiceTest
    {
        [Fact]
        [Benchmark]
        public void ContatoServiceTest_GetAllAsync()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var contatoRepoMock = new Mock<IContatoRepository>();

            var contatoService = new ContatoService(mapperMock.Object, contatoRepoMock.Object);

            // Act
            var contatos = contatoService.GetAllAsync();

            // Assert
            Assert.NotNull(contatos);

            contatos.ShouldNotBeNull();

            contatoRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public void ContatoServiceTest_GetByIdAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            var mapperMock = new Mock<IMapper>();
            var contatoRepoMock = new Mock<IContatoRepository>();

            var contatoService = new ContatoService(mapperMock.Object, contatoRepoMock.Object);

            // Act
            var addedContato = contatoService.AddAsync(contatoPostInputModel);
            var contato = contatoService.GetByIdAsync(addedContato.Id);

            // Assert
            Assert.NotNull(addedContato);
            Assert.NotNull(contato);

            addedContato.ShouldNotBeNull();
            contato.ShouldNotBeNull();

            contatoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Contato>()), Times.Once);
            contatoRepoMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
