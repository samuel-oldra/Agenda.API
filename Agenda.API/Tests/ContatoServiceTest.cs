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
    public class ContatoServiceTest
    {
        private readonly Mock<IContatoRepository> contatoRepoMock;

        private readonly IContatoService contatoService;

        public ContatoServiceTest()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();

            contatoRepoMock = new Mock<IContatoRepository>();

            contatoService = new ContatoService(mapperMock.Object, contatoRepoMock.Object);
        }

        [Fact]
        public void GetAllAsync()
        {
            // Act
            var contatos = contatoService.GetAllAsync();

            // Assert
            Assert.NotNull(contatos);

            contatos.ShouldNotBeNull();

            contatoRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public void GetByIdAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

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

        [Fact]
        public void AddAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var addedContato = contatoService.AddAsync(contatoPostInputModel);

            // Assert
            Assert.NotNull(addedContato);

            addedContato.ShouldNotBeNull();

            contatoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Contato>()), Times.Once);
        }
    }
}
