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

            contatoRepoMock.Verify(rep => rep.AddAsync(It.IsAny<Contato>()), Times.Once);
        }

        [Fact]
        public async void UpdateAsync()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var contatoPutInputModel = new Fixture().Create<ContatoPutInputModel>();

            // Act
            var updatedContato = await contatoService.UpdateAsync(id, contatoPutInputModel);

            // Assert
            contatoRepoMock.Verify(rep => rep.GetByIdAsync(It.IsAny<int>()), Times.Once);
            contatoRepoMock.Verify(rep => rep.UpdateAsync(It.IsAny<Contato>()), Times.AtMostOnce());
        }

        [Fact]
        public async void DeleteAsync()
        {
            // Arrange
            var id = new Fixture().Create<int>();

            // Act
            var deletedContato = await contatoService.DeleteAsync(id);

            // Assert
            contatoRepoMock.Verify(rep => rep.GetByIdAsync(It.IsAny<int>()), Times.Once);
            contatoRepoMock.Verify(rep => rep.DeleteAsync(It.IsAny<Contato>()), Times.AtMostOnce());
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

            contatoRepoMock.Verify(rep => rep.Add(It.IsAny<Contato>()), Times.Once);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var contatoPutInputModel = new Fixture().Create<ContatoPutInputModel>();

            // Act
            var updatedContato = contatoService.Update(id, contatoPutInputModel);

            // Assert
            contatoRepoMock.Verify(rep => rep.GetById(It.IsAny<int>()), Times.Once);
            contatoRepoMock.Verify(rep => rep.Update(It.IsAny<Contato>()), Times.AtMostOnce());
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var id = new Fixture().Create<int>();

            // Act
            var deletedContato = contatoService.Delete(id);

            // Assert
            contatoRepoMock.Verify(rep => rep.GetById(It.IsAny<int>()), Times.Once);
            contatoRepoMock.Verify(rep => rep.Delete(It.IsAny<Contato>()), Times.AtMostOnce());
        }
    }
}
