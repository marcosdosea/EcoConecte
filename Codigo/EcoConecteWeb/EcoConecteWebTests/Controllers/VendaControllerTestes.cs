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
    public class VendaControllerTests
    {
        private static VendaController controller = null!;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IVendaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PessoaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestVenda());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetVenda());
            mockService.Setup(service => service.Edit(It.IsAny<Vendamaterial>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Vendamaterial>()))
                .Verifiable();
            controller = new VendaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<VendaViewModel>));

            List<VendaViewModel>? lista = (List<VendaViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VendaViewModel));
            VendaViewModel vendaModel = (VendaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("1", vendaModel.Id);
            Assert.AreEqual("Plastico", vendaModel.Tipo);
            Assert.AreEqual("R$ 100", vendaModel.Valor);
            Assert.AreEqual("50 Kg", vendaModel.Quantidade);

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
            var result = controller.Create(GetNewVenda());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VendaViewModel));
            VendaViewModel pessoaModel = (VendaViewModel)viewResult.ViewData.Model;


        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetVendaModel().Id, GetTargetVendaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VendaViewModel));
            VendaViewModel vendaModel = (VendaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("1", vendaModel.Id);
            Assert.AreEqual("Plastico", vendaModel.Tipo);
            Assert.AreEqual("R$ 100", vendaModel.Valor);
            Assert.AreEqual("50 Kg", vendaModel.Quantidade);

        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetVendaModel().Id, GetTargetVendaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        private static Vendamaterial GetTargetVenda()
        {
            return new Vendamaterial
            {
                Id = 1,
                Tipo = "Plastico",
                Valor = "R$ 100",
                Quantidade = "50 Kg",
            };
        }
        private VendaViewModel GetNewVenda()
        {
            return new VendaViewModel
            {
                Id = 2,
                Tipo = "Metal",
                Valor = "R$ 500",
                Quantidade = "25 Kg",
            };
        }
        private VendaViewModel GetTargetVendaModel()
        {
            return new VendaViewModel
            {
                Id = 3,
                Tipo = "Vidro",
                Valor = "R$ 1100",
                Quantidade = "45 Kg",
            };
        }
        private IEnumerable<Vendamaterial> GetTestVenda()
        {
            return new List<Vendamaterial>
            {
                new Vendamaterial
                {
                Id = 4,
                Tipo = "Vidro",
                Valor = "R$ 100",
                Quantidade = "2 Kg",
                },
                new Vendamaterial
                {
                Id = 5,
                Tipo = "Metal",
                Valor = "R$ 300",
                Quantidade = "10 Kg",
                },
                new Vendamaterial
                {
                Id = 6,
                Tipo = "Plastico",
                Valor = "R$ 500",
                Quantidade = "50 Kg",
                }
            };
        }
    }
}
