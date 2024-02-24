using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace Agenda.API.Tests
{
    public class ContatoServiceTest
    {
        [Fact]
        public void GetAllAsync()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var contatoRepositoryMock = new Mock<IContatoRepository>();

            var contatoService = new ContatoService(
                mapperMock.Object,
                contatoRepositoryMock.Object
            );

            // Act
            var contatos = contatoService.GetAllAsync();

            // Assert
            Assert.NotNull(contatos);

            contatos.ShouldNotBeNull();

            contatoRepositoryMock.Verify(cr => cr.GetAllAsync(), Times.Once);
        }
    }
}
