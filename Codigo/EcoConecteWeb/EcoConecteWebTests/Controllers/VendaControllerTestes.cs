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
                cfg.AddProfile(new VendaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestVenda());
            mockService.Setup(service => service.GetById(1))
                .Returns(GetTargetVenda());
            mockService.Setup(service => service.Update(It.IsAny<Venda>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Venda>()))
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
            Assert.AreEqual(1u, vendaModel.Id);
            Assert.AreEqual("Plastico", vendaModel.Tipo);
            Assert.AreEqual(100, vendaModel.Valor);
            Assert.AreEqual(50, vendaModel.Quantidade);

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
            var result = controller.Edit((int)GetTargetVendaModel().Id, GetTargetVendaModel());

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
            Assert.AreEqual((uint)1, vendaModel.Id);
            Assert.AreEqual("Plastico", vendaModel.Tipo);
            Assert.AreEqual(100, vendaModel.Valor);
            Assert.AreEqual(50, vendaModel.Quantidade);

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


        private static Venda GetTargetVenda()
        {
            return new Venda
            {
                Id = 1,
                Tipo = "Plastico",
                Valor = 100,
                Quantidade = 50,
            };
        }
        private VendaViewModel GetNewVenda()
        {
            return new VendaViewModel
            {
                Id = 2,
                Tipo = "Metal",
                Valor = 500,
                Quantidade = 25,
            };
        }
        private VendaViewModel GetTargetVendaModel()
        {
            return new VendaViewModel
            {
                Id = 3,
                Tipo = "Vidro",
                Valor = 1100,
                Quantidade = 45,
            };
        }
        private IEnumerable<Venda> GetTestVenda()
        {
            return new List<Venda>
            {
                new Venda
                {
                Id = 4,
                Tipo = "Vidro",
                Valor = 100,
                Quantidade = 2,
                },
                new Venda
                {
                Id = 5,
                Tipo = "Metal",
                Valor = 300,
                Quantidade = 10,
                },
                new Venda
                {
                Id = 6,
                Tipo = "Plastico",
                Valor = 500,
                Quantidade = 50,
                }
            };
        }
    }
}
