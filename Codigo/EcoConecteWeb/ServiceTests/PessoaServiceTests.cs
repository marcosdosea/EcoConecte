using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class PessoaServiceTests
    {
        private EcoConecteContext _context;
        private IPessoaService _pessoaService;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<EcoConecteContext>();
            builder.UseInMemoryDatabase("ecoconecte");
            var options = builder.Options;

            _context = new EcoConecteContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var pessoas = new List<Pessoa>
            {
                new Pessoa {Id= 1, Cpf= "54786325484", Nome= "Carol", Bairro= "Longe", Cidade="Paulo Afonso", Estado="Bahia", Logradouro="Num sei", Numero="13", Telefone="71624626655", Status="A"},
                new Pessoa {Id= 2, Cpf= "31647924892", Nome= "Matheus", Bairro= "Suiça", Cidade="Aracaju", Estado="Sergipe", Logradouro="Num sei", Numero="22", Telefone="47762145221", Status="I"},
                new Pessoa {Id= 3, Cpf= "74423541255", Nome= "Frango", Bairro= "Não tem", Cidade="Itabaiana", Estado="Sergipe", Logradouro="Num sei", Numero="S/N", Telefone="79265123512", Status="A"}
            };

            _context.AddRange(pessoas);
            _context.SaveChanges();

            _pessoaService = new PessoaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //act
            _pessoaService.Create(new Pessoa { Id = 4, Cpf = "14876547823", Nome = "Sodre", Bairro = "Bem Longe", Cidade = "Irecê", Estado = "Bahia", Logradouro = "Num sei", Numero = "10", Telefone = "71458962354", Status = "I" });
            //Assert
            Assert.AreEqual(4, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(4);
            Assert.AreEqual("Sodre", pessoa.Nome);
            Assert.AreEqual("14876547823", pessoa.Cpf);
            Assert.AreEqual("Bem Longe", pessoa.Bairro);
            Assert.AreEqual("Irecê", pessoa.Cidade);
            Assert.AreEqual("Bahia", pessoa.Estado);
            Assert.AreEqual("Num sei", pessoa.Logradouro);
            Assert.AreEqual("10", pessoa.Numero);
            Assert.AreEqual("71458962354", pessoa.Telefone);
            Assert.AreEqual("I", pessoa.Status);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //act
            _pessoaService.Delete(2);
            //Assert
            Assert.AreEqual(2, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(2);
            Assert.AreEqual(null, pessoa);
        }

        [TestMethod()]
        public void EditTest()
        {
            //act
            var pessoa = _pessoaService.Get(1);
            pessoa.Logradouro = "Logo ali";
            pessoa.Bairro = "É bem longe mesmo";
            pessoa.Numero = "11";
            _pessoaService.Edit(pessoa);
            //Assert
            pessoa = _pessoaService.Get(1);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Logo ali", pessoa.Logradouro);
            Assert.AreEqual("É bem longe mesmo", pessoa.Bairro);
            Assert.AreEqual("11", pessoa.Numero);
        }

        [TestMethod()]
        public void GetTest()
        {
            //act
            var pessoa = _pessoaService.Get(2);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Matheus", pessoa.Nome);
            Assert.AreEqual("31647924892", pessoa.Cpf);
            Assert.AreEqual("Suiça", pessoa.Bairro);
            Assert.AreEqual("Aracaju", pessoa.Cidade);
            Assert.AreEqual("Sergipe", pessoa.Estado);
            Assert.AreEqual("Num sei", pessoa.Logradouro);
            Assert.AreEqual("22", pessoa.Numero);
            Assert.AreEqual("47762145221", pessoa.Telefone);
            Assert.AreEqual("I", pessoa.Status);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //act
            var listaPessoa = _pessoaService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaPessoa);
            Assert.AreEqual(3, listaPessoa.Count());
            Assert.AreEqual((uint)1, listaPessoa.First().Id);
            Assert.AreEqual("Carol", listaPessoa.First().Nome);
        }

        [TestMethod()]
        public void GetByNameTest()
        {
            //act
            var pessoas = _pessoaService.GetByName("Frango");
            //Assert
            Assert.IsNotNull(pessoas);
            Assert.AreEqual(1, pessoas.Count());
            Assert.AreEqual("Frango", pessoas.First().Nome);
        }
    }
}