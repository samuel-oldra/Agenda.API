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
    public class ContatoServiceTest
    {
        private readonly IContatoRepository contatoRepository;

        private readonly IContatoService contatoService;

        public ContatoServiceTest()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapper());
            });

            var mapper = mapperConfiguration.CreateMapper();

            DbContextOptions<DataContext> dataContextOptions =
                new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("dados").Options;

            DataContext dataContext = new DataContext(dataContextOptions);

            contatoRepository = new ContatoRepository(dataContext);

            contatoService = new ContatoService(mapper, contatoRepository);
        }

        [Fact]
        public async void GetAllAsync()
        {
            // Arrange
            var contatoPostInputModel1 = new Fixture().Create<ContatoPostInputModel>();
            var contatoPostInputModel2 = new Fixture().Create<ContatoPostInputModel>();
            var contatoPostInputModel3 = new Fixture().Create<ContatoPostInputModel>();
            var contatoPostInputModel4 = new Fixture().Create<ContatoPostInputModel>();
            var contatoPostInputModel5 = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var deletedAll = await contatoService.DeleteAllAsync();
            var addedContato1 = await contatoService.AddAsync(contatoPostInputModel1);
            var addedContato2 = await contatoService.AddAsync(contatoPostInputModel2);
            var addedContato3 = await contatoService.AddAsync(contatoPostInputModel3);
            var addedContato4 = await contatoService.AddAsync(contatoPostInputModel4);
            var addedContato5 = await contatoService.AddAsync(contatoPostInputModel5);
            var contatos = await contatoService.GetAllAsync();

            // Assert
            Assert.True(deletedAll);
            Assert.NotNull(contatos);
            Assert.True(contatos.Count() == 5);

            deletedAll.ShouldBe(true);
            contatos.ShouldNotBeNull();
            contatos.Count().ShouldBe(5);
        }

        [Fact]
        public async void GetByIdAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var addedContato = await contatoService.AddAsync(contatoPostInputModel);
            var contato = await contatoService.GetByIdAsync(addedContato.Id);

            // Assert
            Assert.NotNull(contato);
            Assert.True(contato.Id > 0);
            Assert.Equal(contato.Nome, contatoPostInputModel.Nome);
            Assert.Equal(contato.Email, contatoPostInputModel.Email);
            Assert.Equal(contato.Telefone, contatoPostInputModel.Telefone);
            Assert.Equal(contato.DataNascimento, contatoPostInputModel.DataNascimento);

            contato.ShouldNotBeNull();
            contato.Id.ShouldNotBe(0);
            contato.Nome.ShouldBe(contatoPostInputModel.Nome);
            contato.Email.ShouldBe(contatoPostInputModel.Email);
            contato.Telefone.ShouldBe(contatoPostInputModel.Telefone);
            contato.DataNascimento.ShouldBe(contatoPostInputModel.DataNascimento);
        }

        [Fact]
        public async void AddAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var contato = await contatoService.AddAsync(contatoPostInputModel);

            // Assert
            Assert.NotNull(contato);
            Assert.True(contato.Id > 0);
            Assert.Equal(contato.Nome, contatoPostInputModel.Nome);
            Assert.Equal(contato.Email, contatoPostInputModel.Email);
            Assert.Equal(contato.Telefone, contatoPostInputModel.Telefone);
            Assert.Equal(contato.DataNascimento, contatoPostInputModel.DataNascimento);

            contato.ShouldNotBeNull();
            contato.Id.ShouldNotBe(0);
            contato.Nome.ShouldBe(contatoPostInputModel.Nome);
            contato.Email.ShouldBe(contatoPostInputModel.Email);
            contato.Telefone.ShouldBe(contatoPostInputModel.Telefone);
            contato.DataNascimento.ShouldBe(contatoPostInputModel.DataNascimento);
        }

        [Fact]
        public async void UpdateAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();
            var contatoPutInputModel = new Fixture().Create<ContatoPutInputModel>();

            // Act
            var addedContato = await contatoService.AddAsync(contatoPostInputModel);
            var contato = await contatoService.UpdateAsync(addedContato.Id, contatoPutInputModel);

            // Assert
            Assert.NotNull(contato);
            Assert.True(contato.Id > 0);
            Assert.Equal(contato.Nome, contatoPostInputModel.Nome);
            Assert.Equal(contato.Email, contatoPutInputModel.Email);
            Assert.Equal(contato.Telefone, contatoPutInputModel.Telefone);
            Assert.Equal(contato.DataNascimento, contatoPutInputModel.DataNascimento);

            contato.ShouldNotBeNull();
            contato.Id.ShouldNotBe(0);
            contato.Nome.ShouldBe(contatoPostInputModel.Nome);
            contato.Email.ShouldBe(contatoPutInputModel.Email);
            contato.Telefone.ShouldBe(contatoPutInputModel.Telefone);
            contato.DataNascimento.ShouldBe(contatoPutInputModel.DataNascimento);
        }

        [Fact]
        public async void DeleteAsync()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var addedContato = await contatoService.AddAsync(contatoPostInputModel);
            var deletedContato = await contatoService.DeleteAsync(addedContato.Id);
            var contato = await contatoService.GetByIdAsync(deletedContato.Id);

            // Assert
            Assert.NotNull(addedContato);
            Assert.True(addedContato.Id > 0);
            Assert.NotNull(deletedContato);
            Assert.True(deletedContato.Id > 0);
            Assert.Null(contato);

            addedContato.ShouldNotBeNull();
            addedContato.Id.ShouldNotBe(0);
            deletedContato.ShouldNotBeNull();
            deletedContato.Id.ShouldNotBe(0);
            contato.ShouldBeNull();
        }

        [Fact]
        public void GetAll()
        {
            // Arrange
            var contatoPostInputModel1 = new Fixture().Create<ContatoPostInputModel>();
            var contatoPostInputModel2 = new Fixture().Create<ContatoPostInputModel>();
            var contatoPostInputModel3 = new Fixture().Create<ContatoPostInputModel>();
            var contatoPostInputModel4 = new Fixture().Create<ContatoPostInputModel>();
            var contatoPostInputModel5 = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var deletedAll = contatoService.DeleteAll();
            var addedContato1 = contatoService.Add(contatoPostInputModel1);
            var addedContato2 = contatoService.Add(contatoPostInputModel2);
            var addedContato3 = contatoService.Add(contatoPostInputModel3);
            var addedContato4 = contatoService.Add(contatoPostInputModel4);
            var addedContato5 = contatoService.Add(contatoPostInputModel5);
            var contatos = contatoService.GetAll();

            // Assert
            Assert.True(deletedAll);
            Assert.NotNull(contatos);
            Assert.True(contatos.Count() == 5);

            deletedAll.ShouldBe(true);
            contatos.ShouldNotBeNull();
            contatos.Count().ShouldBe(5);
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var addedContato = contatoService.Add(contatoPostInputModel);
            var contato = contatoService.GetById(addedContato.Id);

            // Assert
            Assert.NotNull(contato);
            Assert.True(contato.Id > 0);
            Assert.Equal(contato.Nome, contatoPostInputModel.Nome);
            Assert.Equal(contato.Email, contatoPostInputModel.Email);
            Assert.Equal(contato.Telefone, contatoPostInputModel.Telefone);
            Assert.Equal(contato.DataNascimento, contatoPostInputModel.DataNascimento);

            contato.ShouldNotBeNull();
            contato.Id.ShouldNotBe(0);
            contato.Nome.ShouldBe(contatoPostInputModel.Nome);
            contato.Email.ShouldBe(contatoPostInputModel.Email);
            contato.Telefone.ShouldBe(contatoPostInputModel.Telefone);
            contato.DataNascimento.ShouldBe(contatoPostInputModel.DataNascimento);
        }

        [Fact]
        public void Add()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var contato = contatoService.Add(contatoPostInputModel);

            // Assert
            Assert.NotNull(contato);
            Assert.True(contato.Id > 0);
            Assert.Equal(contato.Nome, contatoPostInputModel.Nome);
            Assert.Equal(contato.Email, contatoPostInputModel.Email);
            Assert.Equal(contato.Telefone, contatoPostInputModel.Telefone);
            Assert.Equal(contato.DataNascimento, contatoPostInputModel.DataNascimento);

            contato.ShouldNotBeNull();
            contato.Id.ShouldNotBe(0);
            contato.Nome.ShouldBe(contatoPostInputModel.Nome);
            contato.Email.ShouldBe(contatoPostInputModel.Email);
            contato.Telefone.ShouldBe(contatoPostInputModel.Telefone);
            contato.DataNascimento.ShouldBe(contatoPostInputModel.DataNascimento);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();
            var contatoPutInputModel = new Fixture().Create<ContatoPutInputModel>();

            // Act
            var addedContato = contatoService.Add(contatoPostInputModel);
            var contato = contatoService.Update(addedContato.Id, contatoPutInputModel);

            // Assert
            Assert.NotNull(contato);
            Assert.True(contato.Id > 0);
            Assert.Equal(contato.Nome, contatoPostInputModel.Nome);
            Assert.Equal(contato.Email, contatoPutInputModel.Email);
            Assert.Equal(contato.Telefone, contatoPutInputModel.Telefone);
            Assert.Equal(contato.DataNascimento, contatoPutInputModel.DataNascimento);

            contato.ShouldNotBeNull();
            contato.Id.ShouldNotBe(0);
            contato.Nome.ShouldBe(contatoPostInputModel.Nome);
            contato.Email.ShouldBe(contatoPutInputModel.Email);
            contato.Telefone.ShouldBe(contatoPutInputModel.Telefone);
            contato.DataNascimento.ShouldBe(contatoPutInputModel.DataNascimento);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var contatoPostInputModel = new Fixture().Create<ContatoPostInputModel>();

            // Act
            var addedContato = contatoService.Add(contatoPostInputModel);
            var deletedContato = contatoService.Delete(addedContato.Id);
            var contato = contatoService.GetById(deletedContato.Id);

            // Assert
            Assert.NotNull(addedContato);
            Assert.True(addedContato.Id > 0);
            Assert.NotNull(deletedContato);
            Assert.True(deletedContato.Id > 0);
            Assert.Null(contato);

            addedContato.ShouldNotBeNull();
            addedContato.Id.ShouldNotBe(0);
            deletedContato.ShouldNotBeNull();
            deletedContato.Id.ShouldNotBe(0);
            contato.ShouldBeNull();
        }
    }
}
