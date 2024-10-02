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
    public class AgendamentoControllerTests
    {
        private static AgendamentoController controller;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IAgendamentoService>();

            IMapper mapper = new MapperConfiguration(Cfg =>
                Cfg.AddProfile(new AgendamentoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAgendamentos());
            mockService.Setup(service => service.GetById(1))
               .Returns(GetTargetAgendamento());
            mockService.Setup(service => service.Update(It.IsAny<Agendamento>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Agendamento>()))
                .Verifiable();
            controller = new AgendamentoController(mockService.Object, mapper);

        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AgendamentoViewModel>));

            List<AgendamentoViewModel>? lista = (List<AgendamentoViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AgendamentoViewModel>));
            AgendamentoViewModel agendamentoModel = (AgendamentoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("49555000", agendamentoModel.Cep);
            Assert.AreEqual("Casa", agendamentoModel.Logradouro);
            Assert.AreEqual("Centro", agendamentoModel.Bairro);
            Assert.AreEqual("Salvador", agendamentoModel.Cidade);
            Assert.AreEqual("Bahia", agendamentoModel.Estado);
            Assert.AreEqual("665", agendamentoModel.Numero);
            Assert.AreEqual("F", agendamentoModel.Status);
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
            var result = controller.Create(GetNewAgendamento());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AgendamentoViewModel));
            AgendamentoViewModel agendamentoModel = (AgendamentoViewModel)viewResult.ViewData.Model;
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetAgendamentoModel().Id, GetTargetAgendamentoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AgendamentoViewModel));
            AgendamentoViewModel agendamentoModel = (AgendamentoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("49570000", agendamentoModel.Cep);
            Assert.AreEqual("Casa", agendamentoModel.Logradouro);
            Assert.AreEqual("Suiça", agendamentoModel.Bairro);
            Assert.AreEqual("Aracaju", agendamentoModel.Cidade);
            Assert.AreEqual("Sergipe", agendamentoModel.Estado);
            Assert.AreEqual("230", agendamentoModel.Numero);
            Assert.AreEqual("A", agendamentoModel.Status);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            //Act
            var result = controller.Delete(GetTargetAgendamentoModel().Id, GetTargetAgendamentoModel());
            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private static Agendamento GetTargetAgendamento()
        {
            return new Agendamento
            {
                Id = 1,
                Data = DateTime.Now,
                Cep = "49570000",
                Logradouro = "Casa",
                Numero = "230",
                Bairro = "Suiça",
                Cidade = "Aracaju",
                Estado = "Sergipe",
                Status = "A",
            };
        }

        private AgendamentoViewModel GetNewAgendamento()
        {
            return new AgendamentoViewModel
            {
                Id = 4,
                Data = DateTime.Now,
                Cep = "49370000",
                Logradouro = "Rua",
                Numero = "130",
                Bairro = "rio de janeiro",
                Cidade = "paquetá",
                Estado = "Sergipe",
                Status = "D",
            };
        }
        private AgendamentoViewModel GetTargetAgendamentoModel()
        {
            return new AgendamentoViewModel
            {
                Id = 2,
                Data = DateTime.Now,
                Cep = "49580000",
                Logradouro = "Prédio",
                Numero = "100",
                Bairro = "holanda",
                Cidade = "amsterdam",
                Estado = "piaui",
                Status = "B",
            };
        }
        private IEnumerable<Agendamento> GetTestAgendamentos()
        {
            return new List<Agendamento>()
            {
                new ()
                {
                    Id = 1,
                    Data = DateTime.Now,
                    Cep="49570000",
                    Logradouro="Casa",
                    Numero="230",
                    Bairro="Suiça",
                    Cidade="Aracaju",
                    Estado="Sergipe",
                    Status="A",
                },
                  new ()
                {
                    Id = 2,
                    Data = DateTime.Now,
                    Cep="49580000",
                    Logradouro="Prédio",
                    Numero="100",
                    Bairro="holanda",
                    Cidade="amsterdam",
                    Estado="piaui",
                    Status="B",
                },
                   new ()
                {
                    Id = 3,
                    Data = DateTime.Now,
                    Cep="49580000",
                    Logradouro="Travessa",
                    Numero="130",
                    Bairro="Centro",
                    Cidade="coritiba",
                    Estado="paraná",
                    Status="C",
                },
            };
        }
    }
}