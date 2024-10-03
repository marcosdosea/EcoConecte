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
    public class OrientacoesControllerTests
    {
        private static OrientacoesController controller = null!;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IOrientacoesService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new OrientcoesProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestOrientacoess());
            mockService.Setup(service => service.GetById(1))
                .Returns(GetTargetOrientacoes());
            mockService.Setup(service => service.Edit(It.IsAny<Orientacoes>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Orientacoes>()))
                .Verifiable();
            controller = new OrientacoesController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<OrientacoesViewModel>));

            List<OrientacoesViewModel>? lista = (List<OrientacoesViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrientacoesViewModel));
            OrientacoesViewModel OrientacoesModel = (OrientacoesViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Orientcoes02", OrientacoesModel.Titulo);
            Assert.AreEqual("Orientacao 02 da classe", OrientacoesModel.Descricao);
            Assert.AreEqual("1", OrientacoesModel.IdCooperativa);
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
            var result = controller.Create(GetNewOrientacoes());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrientacoesViewModel));
            OrientacoesViewModel OrientacoesModel = (OrientacoesViewModel)viewResult.ViewData.Model;


        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetOrientacoesModel().Id, GetTargetOrientacoesModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrientacoesViewModel));
            OrientacoesViewModel OrientacoesModel = (OrientacoesViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Orientcoes02", OrientacoesModel.Titulo);
            Assert.AreEqual("Orientacao 02 da classe", OrientacoesModel.Descricao);
            Assert.AreEqual("2", OrientacoesModel.IdCooperativa);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetOrientacoesModel().Id, GetTargetOrientacoesModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        private static Orientacoes GetTargetOrientacoes()
        {
            return new Orientacoes
            {
                Id = 2,
                Titulo = "Orientacoes02",
                Descricao = "Orientacao 02 da classe",
                IdCooperativa = 2,
            };
        }
        private OrientacoesViewModel GetNewOrientacoes()
        {
            return new OrientacoesViewModel
            {
                Id = 1,
                Titulo = "Orientacoes01",
                Descricao = "Orientacao 01 da classe",
                IdCooperativa = "1",
            };
        }
        private OrientacoesViewModel GetTargetOrientacoesModel()
        {
            return new OrientacoesViewModel
            {
                Id = 2,
                Titulo = "Orientacoes02",
                Descricao = "Orientacao 02 da classe",
                IdCooperativa = "2",
            };
        }
        private IEnumerable<Orientacoes> GetTestOrientacoess()
        {
            return new List<Orientacoes>
            {
                new Orientacoes
                {
                    Id = 1,
                    Titulo = "Orientacoes01",
                    Descricao = "Orientacao 01 da classe",
                    IdCooperativa = 1,
                },
                new Orientacoes
                {
                    Id = 2,
                    Titulo = "Orientacoes02",
                    Descricao = "Orientacao 02 da classe",
                    IdCooperativa = 2,
                },
                new Orientacoes
                {
                    Id = 3,
                    Titulo = "Orientacoes03",
                    Descricao = "Orientacao 03 da classe",
                    IdCooperativa = 3,
                }
            };
        }
    }
}