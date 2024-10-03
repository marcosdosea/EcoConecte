using Core.Service;
using Moq;
using AutoMapper;
using EcoConecteWeb.Mapper;
using Core;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoConecteWeb.Controllers.Tests
{
    [TestClass()]
    public class NoticiaControllerTests
    {
        private static NoticiaController controller = null!;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<INoticiaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new NoticiaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestNoticias());
            mockService.Setup(service => service.GetById(1))
                .Returns(GetTargetNoticia());
            mockService.Setup(service => service.Edit(It.IsAny<Noticia>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Noticia>()))
                .Verifiable();
            controller = new NoticiaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<NoticiaViewModel>));

            List<NoticiaViewModel>? lista = (List<NoticiaViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest_valido()
        {
            //Act
            var result = controller.Details(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(NoticiaViewModel));
            NoticiaViewModel NoticiaModel = (NoticiaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("TituloNoticia2", NoticiaModel.Titulo);
            Assert.AreEqual("02/10/2024 00:00:00", NoticiaModel.Data);
            Assert.AreEqual("1", NoticiaModel.IdCooperativa);
            Assert.AreEqual("Hoje é tudo nosso!", NoticiaModel.Conteudo);
        }

        [TestMethod()]
        public void CreateTest_Get_Valido()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valido()
        {
            // Act
            var result = controller.Create(GetNewNoticia());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Valido()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(NoticiaViewModel));
            NoticiaViewModel NoticiaModel = (NoticiaViewModel)viewResult.ViewData.Model;


        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetNoticiaModel().Id, GetTargetNoticiaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(NoticiaViewModel));
            NoticiaViewModel NoticiaModel = (NoticiaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("TituloNoticia2", NoticiaModel.Titulo);
            Assert.AreEqual("02/10/2024 00:00:00", NoticiaModel.Data);
            Assert.AreEqual("1", NoticiaModel.IdCooperativa);
            Assert.AreEqual("Hoje é tudo nosso!", NoticiaModel.Conteudo);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetNoticiaModel().Id, GetTargetNoticiaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        private static Noticia GetTargetNoticia()
        {
            return new Noticia
            {
                Id = 2,
                Titulo = "TituloNoticia2",
                Data = DateTime.Today,
                IdCooperativa = 1,
                Conteudo = "Hoje é tudo nosso!",
            };
        }
        private NoticiaViewModel GetNewNoticia()
        {
            return new NoticiaViewModel
            {
                Id = 1,
                Titulo = "TituloNoticia",
                Data = "02/10/2024 00:00:00",
                IdCooperativa = "1",
                Conteudo = "Hoje é tudo nosso!",
            };
        }
        private NoticiaViewModel GetTargetNoticiaModel()
        {
            return new NoticiaViewModel
            {
                Id = 2,
                Titulo = "TituloNotici2",
                Data = "02/10/2024 00:00:00",
                IdCooperativa = "2",
                Conteudo = "Hoje é tudo nosso!",
            };
        }
        private IEnumerable<Noticia> GetTestNoticias()
        {
            return new List<Noticia>
            {
                new Noticia
                {                   
                    Id = 1,
                    Titulo = "TituloNoticia",
                    Data = DateTime.Today,
                    IdCooperativa = 1,
                    Conteudo = "Hoje é tudo nosso!",
                },
                new Noticia
                {
                    Id = 2,
                    Titulo = "TituloNoticia2",
                    Data = DateTime.Today,
                    IdCooperativa = 2,
                    Conteudo = "Hoje é tudo nosso!",
                },
                new Noticia
                {
                    Id = 3,
                    Titulo = "TituloNoticia3",
                    Data = DateTime.Today,
                    IdCooperativa = 3,
                    Conteudo = "Hoje é tudo nosso!",
                }
            };
        }
    }
}