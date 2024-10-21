using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class VendaServiceTests
    {
        private EcoConecteContext _context;
        private IVendaService _vendaService;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<EcoConecteContext>();
            builder.UseInMemoryDatabase("ecoconecte");
            var options = builder.Options;

            _context = new EcoConecteContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var venda = new List<venda>
            {
                new venda {Id= 1, Tipo= "Plastico", Valor= "R$ 100", Quantidade="50 Kg"},
                new venda {Id= 2, Tipo= "Metal", Valor= "R$ 500", Quantidade="25 Kg"},
                new venda {Id= 3, Tipo= "Vidro", Valor= "R$ 1100", Quantidade="45 Kg"}
            };

            _context.AddRange(venda);
            _context.SaveChanges();

            _vendaService = new VendaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //act
            _vendaService.Create(new venda { Id = 4, Tipo = "Vidro", Valor = "R$ 100", Quantidade = "2 Kg", });
            //Assert
            Assert.AreEqual(4, _vendaService.GetAll().Count());
            var venda = _vendaService.Get(4);
            Assert.AreEqual("Vidro", venda.Tipo);
            Assert.AreEqual("R$ 100", venda.Valor);
            Assert.AreEqual("2 Kg", venda.Quantidade);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //act
            _vendaService.Delete(2);
            //Assert
            Assert.AreEqual(2, _vendaService.GetAll().Count());
            var venda = _vendaService.Get(2);
            Assert.AreEqual(null, venda);
        }

        [TestMethod()]
        public void EditTest()
        {
            //act
            var venda = _vendaService.Get(1);
            venda.Tipo = "Metal";
            venda.Valor = "R$ 550";
            venda.Quantidade = "85 Kg";
            _vendaService.Edit(venda);
            //Assert
            venda = _vendaService.Get(1);
            Assert.IsNotNull(venda);
            Assert.AreEqual("Metal", venda.Tipo);
            Assert.AreEqual("R$ 550", venda.Valor);
            Assert.AreEqual("85 Kg", venda.Quantidade);
        }

        [TestMethod()]
        public void GetTest()
        {
            //act
            var venda = _vendaService.Get(2);
            Assert.IsNotNull(venda);
            Assert.AreEqual("Plastico", venda.Tipo);
            Assert.AreEqual("R$ 754", venda.Valor);
            Assert.AreEqual("47 Kg", venda.Quantidade);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //act
            var listaVenda = _vendaService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaVenda, typeof(IEnumerable<venda>));
            Assert.IsNotNull(listaVenda);
            Assert.AreEqual(3, listaVenda.Count());
            Assert.AreEqual((uint)1, listaVenda.First().Id);
            Assert.AreEqual("Plastico", listaVenda.First().Tipo);
        }

    }
}