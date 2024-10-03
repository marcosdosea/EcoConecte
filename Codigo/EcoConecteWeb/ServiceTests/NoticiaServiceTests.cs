using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class NoticiaServiceTests
    {
        private EcoConecteContext _context;
        private INoticiaService _NoticiaService;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<EcoConecteContext>();
            builder.UseInMemoryDatabase("ecoconecte");
            var options = builder.Options;

            _context = new EcoConecteContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var Noticias = new List<Noticia>
            {
                new Noticia {Id= 1, Titulo= "TituloNoticia", Conteudo= "Hoje é tudo nosso!", IdCooperativa= 1, Data=DateTime.Today},
                new Noticia {Id= 2, Titulo= "TituloNoticia2", Conteudo= "Hoje é tudo nosso! 2", IdCooperativa= 2, Data=DateTime.Today},
                new Noticia {Id= 3, Titulo= "TituloNoticia3", Conteudo= "Hoje é tudo nosso! 3", IdCooperativa= 3, Data=DateTime.Today}
            };

            _context.AddRange(Noticias);
            _context.SaveChanges();

            _NoticiaService = new NoticiaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //act
            _NoticiaService.Create(new Noticia { Id = 4, Titulo = "TituloNoticia4", Conteudo = "Hoje é tudo nosso! 4", IdCooperativa = 4, Data = DateTime.Today });
            //Assert
            Assert.AreEqual(4, _NoticiaService.GetAll().Count());
            var Noticia = _NoticiaService.GetById(4);
            Assert.AreEqual("TituloNoticia4", Noticia.Titulo);
            Assert.AreEqual("Hoje é tudo nosso! 4", Noticia.Conteudo);
            Assert.AreEqual((uint)4, Noticia.IdCooperativa);
            Assert.AreEqual(Noticia.Data, DateTime.Today);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //act
            _NoticiaService.Delete(2);
            //Assert
            Assert.AreEqual(2, _NoticiaService.GetAll().Count());
            var Noticia = _NoticiaService.GetById(2);
            Assert.AreEqual(null, Noticia);
        }

        [TestMethod()]
        public void EditTest()
        {
            //act
            var Noticia = _NoticiaService.GetById(1);
            Noticia.Titulo = "Logo ali";
            Noticia.Conteudo = "É bem longe mesmo";
            Noticia.IdCooperativa = 1;
            _NoticiaService.Edit(Noticia);
            //Assert
            Noticia = _NoticiaService.GetById(1);
            Assert.IsNotNull(Noticia);
            Assert.AreEqual("Logo ali", Noticia.Titulo);
            Assert.AreEqual("É bem longe mesmo", Noticia.Conteudo);
            Assert.AreEqual((uint)1, Noticia.IdCooperativa);
        }

        [TestMethod()]
        public void GetTest()
        {
            //act
            var Noticia = _NoticiaService.GetById(2);
            Assert.IsNotNull(Noticia);
            Assert.AreEqual("TituloNoticia2", Noticia.Titulo);
            Assert.AreEqual("Hoje é tudo nosso! 2", Noticia.Conteudo);
            Assert.AreEqual((uint)2, Noticia.IdCooperativa);
            Assert.AreEqual(DateTime.Today, Noticia.Data);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //act
            var listaNoticia = _NoticiaService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaNoticia, typeof(IEnumerable<Noticia>));
            Assert.IsNotNull(listaNoticia);
            Assert.AreEqual(3, listaNoticia.Count());
            Assert.AreEqual((uint)1, listaNoticia.First().Id);
            Assert.AreEqual("TituloNoticia", listaNoticia.First().Titulo);
        }

        [TestMethod()]
        public void GetByNameTest()
        {
            //act
            var Noticias = _NoticiaService.GetByTitulo("TituloNoticia2");
            //Assert
            Assert.IsNotNull(Noticias);
            Assert.AreEqual(1, Noticias.Count());
            Assert.AreEqual("TituloNoticia2", Noticias.First().Titulo);
        }
    }
}