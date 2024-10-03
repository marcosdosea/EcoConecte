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
    public class AgendamentoServiceTests
    {
        private EcoConecteContext _context = null!;
        private IAgendamentoService _agendamentoService = null!;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<EcoConecteContext>();
            builder.UseInMemoryDatabase("ecoconecte");
            var options = builder.Options;

            _context = new EcoConecteContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var agendamentos = new List<Agendamento>
            {
                new Agendamento {Id= 1, Cep= "49570000",Bairro= "Suiça", Cidade="Aracaju", Estado="Sergipe", Logradouro="Casa", Numero="230",Status="A"},
                new Agendamento {Id= 2, Cep= "49670000",Bairro= "holanda",Cidade="amsterdam", Estado="piaui", Logradouro="Prédio", Numero="100",Status="B"},
                new Agendamento {Id= 3, Cep= "49580000",Bairro= "Centro", Cidade="coritiba", Estado="paraná", Logradouro="Travessa", Numero="130",Status="C"}
            };
            _context.AddRange(agendamentos);
            _context.SaveChanges();

            _agendamentoService = new AgendamentoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //act
            var id = _agendamentoService.Create(new Agendamento {Data = DateTime.Now, Cep = "49570000", Logradouro = "Casa", Numero = "230", Bairro = "Suiça", Cidade = "Aracaju", Estado = "Sergipe", Status = "A", });
            //Assert
            Assert.AreEqual(4, _agendamentoService.GetAll().Count());
            Assert.AreEqual((uint)4, id);
            var agendamento = _agendamentoService.GetById(1);
            Assert.IsNotNull(agendamento);
            Assert.AreEqual("49570000", agendamento.Cep);
            Assert.AreEqual("Suiça", agendamento.Bairro);
            Assert.AreEqual("Aracaju", agendamento.Cidade);
            Assert.AreEqual("Sergipe", agendamento.Estado);
            Assert.AreEqual("Casa", agendamento.Logradouro);
            Assert.AreEqual("230", agendamento.Numero);
            Assert.AreEqual("A", agendamento.Status);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //act
            _agendamentoService.Delete(2);
            //Assert
            Assert.AreEqual(2, _agendamentoService.GetAll().Count());
            var agendamento = _agendamentoService.GetById(2);
            Assert.AreEqual(null, agendamento);
        }

        [TestMethod()]
        public void EditTest()
        {
            //act
            var agendamento = _agendamentoService.GetById(1);
            Assert.IsNotNull(agendamento);
            agendamento.Logradouro = "Logo ali";
            agendamento.Bairro = "É bem longe mesmo";
            agendamento.Numero = "11";
            _agendamentoService.Update(agendamento);
            //Assert
            agendamento = _agendamentoService.GetById(1);
            Assert.IsNotNull(agendamento);
            Assert.AreEqual("Logo ali", agendamento.Logradouro);
            Assert.AreEqual("É bem longe mesmo", agendamento.Bairro);
            Assert.AreEqual("11", agendamento.Numero);
        }
        [TestMethod()]
        public void GetTest()
        {
            //act
            var agendamento = _agendamentoService.GetById(2);
            Assert.IsNotNull(agendamento);
            Assert.AreEqual("49670000", agendamento.Cep);
            Assert.AreEqual("holanda", agendamento.Bairro);
            Assert.AreEqual("amsterdam", agendamento.Cidade);
            Assert.AreEqual("piaui", agendamento.Estado);
            Assert.AreEqual("Prédio", agendamento.Logradouro);
            Assert.AreEqual("100", agendamento.Numero);
            Assert.AreEqual("B", agendamento.Status);
        }
        [TestMethod()]
        public void GetAllTest()
        {
            //act
            var listaAgendamento = _agendamentoService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaAgendamento, typeof(IEnumerable<Agendamento>));
            Assert.IsNotNull(listaAgendamento);
            Assert.AreEqual(3, listaAgendamento.Count());
            Assert.AreEqual((uint)1, listaAgendamento.First().Id);
        }

    }
}