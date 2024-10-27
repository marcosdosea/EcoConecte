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
    public class ColetaServiceTests
    {
        private EcoConecteContext _context = null!;
        private IColetaService _ColetaService = null!;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<EcoConecteContext>();
            builder.UseInMemoryDatabase("ecoconecte");
            var options = builder.Options;

            _context = new EcoConecteContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var Coletas = new List<Coleta>
            {
                new Coleta {Id= 1, Cep= "49570000",Logradouro="Casa", Numero= 230,DiaColeta= DateTime.Today, HorarioInicio= DateTime.Today,HorarioTermino= DateTime.Today,IdCooperativa=1},
                new Coleta {Id= 2, Cep= "49500000",Logradouro="Casa", Numero= 1830,DiaColeta= DateTime.Today, HorarioInicio= DateTime.Today,HorarioTermino= DateTime.Today,IdCooperativa=2},
                new Coleta {Id= 3, Cep= "49700000",Logradouro="Casa", Numero= 21,DiaColeta= DateTime.Today, HorarioInicio= DateTime.Today,HorarioTermino= DateTime.Today,IdCooperativa=3},
            };
            _context.AddRange(Coletas);
            _context.SaveChanges();

            _ColetaService = new ColetaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //act
            var id = _ColetaService.Create(new Coleta
            {
                Cep = "49570000",
                Logradouro = "Casa",
                Numero = 230,
                DiaColeta = DateTime.Today,
                HorarioInicio = DateTime.Today,
                HorarioTermino = DateTime.Today,
                IdCooperativa = 1 });
            //Assert
            Assert.AreEqual(4, _ColetaService.GetAll().Count());
                Assert.AreEqual((uint)4, id);
                var Coleta = _ColetaService.GetById(1);
                Assert.IsNotNull(Coleta);
                Assert.AreEqual("49570000", Coleta.Cep);
                Assert.AreEqual("Casa", Coleta.Logradouro);
                Assert.AreEqual(230, Coleta.Numero);
                Assert.AreEqual(DateTime.Today, Coleta.DiaColeta);
                
            }

        [TestMethod()]
        public void DeleteTest()
            {
                //act
                _ColetaService.Delete(2);
                //Assert
                Assert.AreEqual(2, _ColetaService.GetAll().Count());
                var Coleta = _ColetaService.GetById(2);
                Assert.AreEqual(null, Coleta);
            }

            [TestMethod()]
            public void EditTest()
            {
                //act
                var Coleta = _ColetaService.GetById(1);
                Assert.IsNotNull(Coleta);
                Coleta.Logradouro = "Logo ali";
                Coleta.Numero = 11;
                _ColetaService.Update(Coleta);
                //Assert
                Coleta = _ColetaService.GetById(1);
                Assert.IsNotNull(Coleta);
                Assert.AreEqual("Logo ali", Coleta.Logradouro);
                Assert.AreEqual(DateTime.Today, Coleta.HorarioInicio);
                Assert.AreEqual(DateTime.Today, Coleta.HorarioTermino);
                Assert.AreEqual(11, Coleta.Numero);
            }
            [TestMethod()]
            public void GetTest()
            {
                //act
                var Coleta = _ColetaService.GetById(2);
                Assert.IsNotNull(Coleta);
                Assert.AreEqual("49500000", Coleta.Cep);
                Assert.AreEqual("Casa", Coleta.Logradouro);
                Assert.AreEqual(1830, Coleta.Numero);
                Assert.AreEqual(DateTime.Today, Coleta.HorarioInicio);
                Assert.AreEqual(DateTime.Today, Coleta.DiaColeta);

            }
            [TestMethod()]
            public void GetAllTest()
            {
                //act
                var listaColeta = _ColetaService.GetAll();
                //Assert
                Assert.IsInstanceOfType(listaColeta, typeof(IEnumerable<Coleta>));
                Assert.IsNotNull(listaColeta);
                Assert.AreEqual(3, listaColeta.Count());
                Assert.AreEqual((uint)1, listaColeta.First().Id);
            }

        }
    }