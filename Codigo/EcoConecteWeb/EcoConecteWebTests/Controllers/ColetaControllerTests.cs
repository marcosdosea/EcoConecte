using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcoConecteWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Core.Service;
using AutoMapper;
using EcoConecteWeb.Mapper;
using Core;
using static System.Runtime.InteropServices.JavaScript.JSType;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoConecteWeb.Controllers.Tests
{
    [TestClass()]
    public class ColetaControllerTests
    {
        private static ColetaController controller = null!;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IColetaService>();


            IMapper mapper = new MapperConfiguration(Cfg =>
                Cfg.AddProfile(new ColetaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestColeta());
            mockService.Setup(service => service.GetById(1))
               .Returns(GetTargetColeta());
            mockService.Setup(service => service.Update(It.IsAny<Coleta>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Coleta>()))
                .Returns((Coleta Coleta) => Coleta.Id)
                .Verifiable();

            controller = new ColetaController(mockService.Object, mapper);

        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ColetaViewModel>));

            List<ColetaViewModel>? lista = (List<ColetaViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ColetaViewModel));
            ColetaViewModel ColetaModel = (ColetaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("49570000", ColetaModel.Cep);
            Assert.AreEqual("Casa", ColetaModel.Logradouro);
            Assert.AreEqual(DateTime.Today, ColetaModel.DiaColeta);
            Assert.AreEqual(DateTime.Today, ColetaModel.HorarioInicio);
            Assert.AreEqual(DateTime.Today, ColetaModel.HorarioTermino);


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
            var result = controller.Create(GetNewColeta());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ColetaViewModel));
            ColetaViewModel ColetaModel = (ColetaViewModel)viewResult.ViewData.Model;
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetColetaModel().Id, GetTargetColetaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ColetaViewModel));
            ColetaViewModel ColetaModel = (ColetaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("49570000", ColetaModel.Cep);
            Assert.AreEqual("Casa", ColetaModel.Logradouro);
            Assert.AreEqual(DateTime.Today, ColetaModel.DiaColeta);
            Assert.AreEqual(DateTime.Today, ColetaModel.HorarioInicio);
            Assert.AreEqual(DateTime.Today, ColetaModel.HorarioTermino);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            //Act
            var result = controller.Delete(GetTargetColetaModel().Id, GetTargetColetaModel());
            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private static Coleta GetTargetColeta()
        {
            return new Coleta
            {
                Id = 1,
                Cep = "49570000",
                Logradouro = "Casa",
                DiaColeta = DateTime.Today,
                HorarioInicio = DateTime.Today,
                HorarioTermino = DateTime.Today,


            };
        }

        private ColetaViewModel GetNewColeta()
        {
            return new ColetaViewModel
            {
                Id = 4,
                Cep = "49370000",
                Logradouro = "Casa",
                DiaColeta = DateTime.Today,
                HorarioInicio = DateTime.Today,
                HorarioTermino = DateTime.Today,

            };
        }
        private ColetaViewModel GetTargetColetaModel()
        {
            return new ColetaViewModel
            {
                Id = 2,
                Cep = "49370000",
                Logradouro = "Casa",
                DiaColeta = DateTime.Today,
                HorarioInicio = DateTime.Today,
                HorarioTermino = DateTime.Today,
            };
        }
        private static Pessoa GetTargetPessoa()
        {
            return new Pessoa
            {
                Id = 1,
                Cpf = "31647924892",
                Nome = "Matheus",
                Bairro = "Suiça",
                Cidade = "Aracaju",
                Estado = "Sergipe",
                Logradouro = "Num sei",
                Numero = "22",
                Telefone = "47762145221",
                Status = "I"
            };
        }
        private IEnumerable<Coleta> GetTestColeta()
        {
            return new List<Coleta>()
            {
                new ()
                {
                Id = 1,
                Cep = "49370000",
                Logradouro = "Casa",
                DiaColeta = DateTime.Today,
                HorarioInicio = DateTime.Today,
                HorarioTermino = DateTime.Today,
                },
                  new ()
                {
                    Id = 2,
                    Cep = "49370000",
                    Logradouro = "Casa",
                    DiaColeta = DateTime.Today,
                    HorarioInicio = DateTime.Today,
                    HorarioTermino = DateTime.Today,
                },
                   new ()
                {
                    Id = 3,
                    Cep = "49370000",
                    Logradouro = "Casa",
                    DiaColeta = DateTime.Today,
                    HorarioInicio = DateTime.Today,
                    HorarioTermino = DateTime.Today,
                },
            };
        }
    }
}