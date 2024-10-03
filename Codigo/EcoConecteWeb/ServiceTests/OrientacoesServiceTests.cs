using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class OrientacoesServiceTests
    {
        private EcoConecteContext _context;
        private IOrientacoesService _OrientacoesService;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<EcoConecteContext>();
            builder.UseInMemoryDatabase("ecoconecte");
            var options = builder.Options;

            _context = new EcoConecteContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var Orientacoess = new List<Orientacoes>
            {
                new Orientacoes {Id= 1, Titulo= "TituloOrientacoes", Descricao= "Orientacao 01 da classe", IdCooperativa= 1},
                new Orientacoes {Id= 2, Titulo= "TituloOrientacoes2", Descricao= "Orientacao 02 da classe", IdCooperativa= 2},
                new Orientacoes {Id= 3, Titulo= "TituloOrientacoes3", Descricao= "Orientacao 03 da classe", IdCooperativa= 3}
            };

            _context.AddRange(Orientacoess);
            _context.SaveChanges();

            _OrientacoesService = new OrientacoesService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //act
            _OrientacoesService.Create(new Orientacoes { Id = 4, Titulo = "TituloOrientacoes4", Descricao = "Orientacao 04 da classe", IdCooperativa = 4});
            //Assert
            Assert.AreEqual(4, _OrientacoesService.GetAll().Count());
            var Orientacoes = _OrientacoesService.GetById(4);
            Assert.AreEqual("TituloOrientacoes4", Orientacoes.Titulo);
            Assert.AreEqual("Hoje é tudo nosso! 4", Orientacoes.Descricao);
            Assert.AreEqual((uint)4, Orientacoes.IdCooperativa);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //act
            _OrientacoesService.Delete(2);
            //Assert
            Assert.AreEqual(2, _OrientacoesService.GetAll().Count());
            var Orientacoes = _OrientacoesService.GetById(2);
            Assert.AreEqual(null, Orientacoes);
        }

        [TestMethod()]
        public void EditTest()
        {
            //act
            var Orientacoes = _OrientacoesService.GetById(1);
            Orientacoes.Titulo = "TituloOrientacoes";
            Orientacoes.Descricao = "Orientacao 02 da classe";
            Orientacoes.IdCooperativa = 1;
            _OrientacoesService.Edit(Orientacoes);
            //Assert
            Orientacoes = _OrientacoesService.GetById(1);
            Assert.IsNotNull(Orientacoes);
            Assert.AreEqual("TituloOrientacoes", Orientacoes.Titulo);
            Assert.AreEqual("Orientacao 02 da classe", Orientacoes.Descricao);
            Assert.AreEqual((uint)1, Orientacoes.IdCooperativa);
        }

        [TestMethod()]
        public void GetTest()
        {
            //act
            var Orientacoes = _OrientacoesService.GetById(2);
            Assert.IsNotNull(Orientacoes);
            Assert.AreEqual("TituloOrientacoes2", Orientacoes.Titulo);
            Assert.AreEqual("Hoje é tudo nosso! 2", Orientacoes.Descricao);
            Assert.AreEqual((uint)2, Orientacoes.IdCooperativa);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //act
            var listaOrientacoes = _OrientacoesService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaOrientacoes, typeof(IEnumerable<Orientacoes>));
            Assert.IsNotNull(listaOrientacoes);
            Assert.AreEqual(3, listaOrientacoes.Count());
            Assert.AreEqual((uint)1, listaOrientacoes.First().Id);
            Assert.AreEqual("TituloOrientacoes", listaOrientacoes.First().Titulo);
        }

        [TestMethod()]
        public void GetByNameTest()
        {
            //act
            var Orientacoess = _OrientacoesService.GetByTitulo("TituloOrientacoes2");
            //Assert
            Assert.IsNotNull(Orientacoess);
            Assert.AreEqual(1, Orientacoess.Count());
            Assert.AreEqual("TituloOrientacoes2", Orientacoess.First().Titulo);
        }
    }
}