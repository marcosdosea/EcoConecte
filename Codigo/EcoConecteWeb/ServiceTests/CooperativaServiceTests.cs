using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class CooperativaServiceTests
    {
        private EcoConecteContext _context = null!;
        private ICooperativaService _cooperativaService = null!;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<EcoConecteContext>();
            builder.UseInMemoryDatabase("ecoconecte");
            var options = builder.Options;

            _context = new EcoConecteContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var cooperativa = new List<Cooperativa>
            {
                new Cooperativa {Id= 1,Nome = "CooperFARMA",InscricaoEstadual ="12121212", InscricaoMunicipal = "13131313",Cnpj = "11111111111111", Cep= "49570000",Bairro= "Suiça",Logradouro="Casa", Numero="230",Status="A", Email = "cooperfarma@email.com", Telefone = "99999999999", IdPessoaRepresentate = 1},
                new Cooperativa {Id= 2,Nome = "CooperITA",InscricaoEstadual ="15151515", InscricaoMunicipal = "14141414",Cnpj = "12311111111111", Cep= "49580000",Bairro= "Novo",Logradouro="Zona Rural", Numero="430",Status="I", Email = "cooperita@email.com", Telefone = "79996218534", IdPessoaRepresentate = 2},
                new Cooperativa {Id= 3,Nome = "CooperFRUTA",InscricaoEstadual ="16161616", InscricaoMunicipal = "15151515",Cnpj = "15611111111111", Cep= "49590000",Bairro= "Piruleta",Logradouro="Casa", Numero="570",Status="A", Email = "cooperfruta@email.com", Telefone = "99999991468", IdPessoaRepresentate = 3},
            };
            _context.AddRange(cooperativa);
            _context.SaveChanges();

            _cooperativaService = new CooperativaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //act
            var id = _cooperativaService.Create(new Cooperativa { Nome = "CooperFARMA", InscricaoEstadual = "12121212", InscricaoMunicipal = "13131313", Cnpj = "11111111111111", Cep = "49570000", Bairro = "Suiça", Logradouro = "Casa", Numero = "230", Status = "A", Email = "cooperfarma@email.com", Telefone = "99999999999", IdPessoaRepresentate = 1});
            //Assert
            Assert.AreEqual(4, _cooperativaService.GetAll().Count());
            Assert.AreEqual((uint)4, id);
            var cooperativa = _cooperativaService.Get(1);
            Assert.IsNotNull(cooperativa);
            Assert.AreEqual("49570000", cooperativa.Cep);
            Assert.AreEqual("Suiça", cooperativa.Bairro);
            Assert.AreEqual("Casa", cooperativa.Logradouro);
            Assert.AreEqual("230", cooperativa.Numero);
            Assert.AreEqual("A", cooperativa.Status);
            Assert.AreEqual("cooperfarma@email.com", cooperativa.Email);
            Assert.AreEqual("CooperFARMA", cooperativa.Nome);
            Assert.AreEqual("12121212", cooperativa.InscricaoEstadual);
            Assert.AreEqual("13131313", cooperativa.InscricaoMunicipal);
            Assert.AreEqual("11111111111111", cooperativa.Cnpj);
            Assert.AreEqual("99999999999", cooperativa.Telefone);
            Assert.AreEqual(1u, cooperativa.IdPessoaRepresentate);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            //act
            _cooperativaService.Delete(1);
            //Assert
            Assert.AreEqual(2, _cooperativaService.GetAll().Count());
            var cooperativa = _cooperativaService.Get(1);
            Assert.AreEqual(null, cooperativa);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            //act
            var cooperativa = _cooperativaService.Get(1);
            Assert.IsNotNull(cooperativa);
            cooperativa.Logradouro = "Logo ali";
            cooperativa.Bairro = "É bem longe mesmo";
            cooperativa.Numero = "11";
            _cooperativaService.Update(cooperativa);
            //Assert
            cooperativa = _cooperativaService.Get(1);
            Assert.IsNotNull(cooperativa);
            Assert.AreEqual("Logo ali", cooperativa.Logradouro);
            Assert.AreEqual("É bem longe mesmo", cooperativa.Bairro);
            Assert.AreEqual("11", cooperativa.Numero);
        }

        [TestMethod()]
        public void GetTest()
        {
            //act
            var cooperativa = _cooperativaService.Get(2);
            Assert.IsNotNull(cooperativa);
            Assert.AreEqual("49580000", cooperativa.Cep);
            Assert.AreEqual("Novo", cooperativa.Bairro);
            Assert.AreEqual("Zona Rural", cooperativa.Logradouro);
            Assert.AreEqual("430", cooperativa.Numero);
            Assert.AreEqual("I", cooperativa.Status);
            Assert.AreEqual("cooperita@email.com", cooperativa.Email);
            Assert.AreEqual("CooperITA", cooperativa.Nome);
            Assert.AreEqual("15151515", cooperativa.InscricaoEstadual);
            Assert.AreEqual("14141414", cooperativa.InscricaoMunicipal);
            Assert.AreEqual("12311111111111", cooperativa.Cnpj);
            Assert.AreEqual("79996218534", cooperativa.Telefone);
            Assert.AreEqual(2u, cooperativa.IdPessoaRepresentate);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //act
            var listacooperativa = _cooperativaService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listacooperativa, typeof(IEnumerable<Cooperativa>));
            Assert.IsNotNull(listacooperativa);
            Assert.AreEqual(3, listacooperativa.Count());
            Assert.AreEqual(1u, listacooperativa.First().Id);
        }
    }
}