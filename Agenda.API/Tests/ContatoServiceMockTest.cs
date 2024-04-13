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
    public class ContatoServiceMockTest
    {
        private readonly Mock<IContatoRepository> contatoRepoMock;

        private readonly IContatoService contatoService;

        public ContatoServiceMockTest()
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
        public void Add()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var addedContato = contatoService.Add(contatoPostInputModel);

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

            contatoRepoMock.Verify(repo => repo.Add(It.IsAny<Contato>()), Times.Once);
        }
    }
}
