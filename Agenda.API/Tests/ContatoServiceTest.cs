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
    public class ContatoServiceTest
    {
        private readonly Mock<IContatoRepository> contatoRepoMock;

        private readonly IContatoService contatoService;

        public ContatoServiceTest()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapper());
            });
            var mapperObject = mapperConfiguration.CreateMapper();

            contatoRepoMock = new Mock<IContatoRepository>();

            contatoService = new ContatoService(mapperObject, contatoRepoMock.Object);
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
        public async void AddAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var addedContato = await contatoService.AddAsync(contatoPostInputModel);

            // Assert
            Assert.NotNull(addedContato);
            Assert.Equal(addedContato.Nome, contatoPostInputModel.Nome);
            Assert.Equal(addedContato.Email, contatoPostInputModel.Email);
            Assert.Equal(addedContato.Telefone, contatoPostInputModel.Telefone);
            Assert.Equal(addedContato.DataNascimento, contatoPostInputModel.DataNascimento);

            addedContato.ShouldNotBeNull();
            addedContato.Nome.ShouldBe(contatoPostInputModel.Nome);
            addedContato.Email.ShouldBe(contatoPostInputModel.Email);
            addedContato.Telefone.ShouldBe(contatoPostInputModel.Telefone);
            addedContato.DataNascimento.ShouldBe(contatoPostInputModel.DataNascimento);

            contatoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Contato>()), Times.Once);
        }

        [Fact]
        public void UpdateAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();
            var contatoPutInputModel = new Fixture().Create<ContatoPutInputModel>();

            // Act
            var addedContato = contatoService.AddAsync(contatoPostInputModel);
            var updatedContato = contatoService.UpdateAsync(addedContato.Id, contatoPutInputModel);

            // Assert
            Assert.NotNull(addedContato);
            Assert.NotNull(updatedContato);

            addedContato.ShouldNotBeNull();
            updatedContato.ShouldNotBeNull();

            contatoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Contato>()), Times.Once);
            contatoRepoMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
            contatoRepoMock.Verify(repo => repo.UpdateAsync(It.IsAny<Contato>()), Times.AtMostOnce);
        }

        [Fact]
        public void DeleteAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var addedContato = contatoService.AddAsync(contatoPostInputModel);
            var deletedContato = contatoService.DeleteAsync(addedContato.Id);

            // Assert
            Assert.NotNull(addedContato);
            Assert.NotNull(deletedContato);

            addedContato.ShouldNotBeNull();
            deletedContato.ShouldNotBeNull();

            contatoRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Contato>()), Times.Once);
            contatoRepoMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
            contatoRepoMock.Verify(repo => repo.DeleteAsync(It.IsAny<Contato>()), Times.AtMostOnce);
        }
    }
}
