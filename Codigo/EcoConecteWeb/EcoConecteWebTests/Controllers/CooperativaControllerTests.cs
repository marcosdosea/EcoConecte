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
    public class CooperativaControllerTests
    {
        private static CooperativaController controller = null!;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<ICooperativaService>();
            var mockPessoaService = new Mock<IPessoaService>();

            IMapper mapper = new MapperConfiguration(Cfg =>
                Cfg.AddProfile(new CooperativaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestCooperativas());
            mockService.Setup(service => service.Get(1))
               .Returns(GetTargetCooperativa());
            mockService.Setup(service => service.Update(It.IsAny<Cooperativa>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Cooperativa>()))
                .Returns((Cooperativa cooperativa) => cooperativa.Id)
                .Verifiable();

            controller = new CooperativaController(mockService.Object, mapper);

        }
  
        [TestMethod()]
        public void IndexTest_Valido()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CooperativaViewModel>));

            List<CooperativaViewModel>? lista = (List<CooperativaViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CooperativaViewModel));
            CooperativaViewModel cooperativaModel = (CooperativaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("49570000", cooperativaModel.Cep);
            Assert.AreEqual("Suiça", cooperativaModel.Bairro);
            Assert.AreEqual("Casa", cooperativaModel.Logradouro);
            Assert.AreEqual("230", cooperativaModel.Numero);
            Assert.AreEqual("A", cooperativaModel.Status);
            Assert.AreEqual("cooperfarma@email.com", cooperativaModel.Email);
            Assert.AreEqual("CooperFARMA", cooperativaModel.Nome);
            Assert.AreEqual("12121212", cooperativaModel.InscricaoEstadual);
            Assert.AreEqual("13131313", cooperativaModel.InscricaoMunicipal);
            Assert.AreEqual("11111111111111", cooperativaModel.Cnpj);
            Assert.AreEqual("99999999999", cooperativaModel.Telefone);
            Assert.AreEqual(1u, cooperativaModel.IdPessoaRepresentate);
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
            var result = controller.Create(GetNewCooperativa());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CooperativaViewModel));
            CooperativaViewModel cooperativaModel = (CooperativaViewModel)viewResult.ViewData.Model;
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Delete((uint)GetTargetCooperativaModel().Id, GetTargetCooperativaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CooperativaViewModel));
            CooperativaViewModel cooperativaModel = (CooperativaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("49570000", cooperativaModel.Cep);
            Assert.AreEqual("Suiça", cooperativaModel.Bairro);
            Assert.AreEqual("Casa", cooperativaModel.Logradouro);
            Assert.AreEqual("230", cooperativaModel.Numero);
            Assert.AreEqual("A", cooperativaModel.Status);
            Assert.AreEqual("cooperfarma@email.com", cooperativaModel.Email);
            Assert.AreEqual("CooperFARMA", cooperativaModel.Nome);
            Assert.AreEqual("12121212", cooperativaModel.InscricaoEstadual);
            Assert.AreEqual("13131313", cooperativaModel.InscricaoMunicipal);
            Assert.AreEqual("11111111111111", cooperativaModel.Cnpj);
            Assert.AreEqual("99999999999", cooperativaModel.Telefone);
            Assert.AreEqual(1u, cooperativaModel.IdPessoaRepresentate);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            //Act
            var result = controller.Delete((uint)GetTargetCooperativaModel().Id, GetTargetCooperativaModel());
            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private static Cooperativa GetTargetCooperativa()
        {
            return new Cooperativa
            {
                Id = 2,
                Nome = "CooperITA",
                InscricaoEstadual = "15151515",
                InscricaoMunicipal = "14141414",
                Cnpj = "12311111111111",
                Cep = "49580000",
                Bairro = "Novo",
                Logradouro = "Zona Rural",
                Numero = "430",
                Status = "I",
                Email = "cooperita@email.com",
                Telefone = "79996218534",
                IdPessoaRepresentate = 2
            };
        }

        private CooperativaViewModel GetNewCooperativa()
        {
            return new CooperativaViewModel
            {
                Id = 3,
                Nome = "CooperFRUTA",
                InscricaoEstadual = "16161616",
                InscricaoMunicipal = "15151515",
                Cnpj = "15611111111111",
                Cep = "49590000",
                Bairro = "Piruleta",
                Logradouro = "Casa",
                Numero = "570",
                Status = "A",
                Email = "cooperfruta@email.com",
                Telefone = "99999991468",
                IdPessoaRepresentate = 3

            };
        }
        private CooperativaViewModel GetTargetCooperativaModel()
        {
            return new CooperativaViewModel
            {
                Id = 1,
                Nome = "CooperFARMA",
                InscricaoEstadual = "12121212",
                InscricaoMunicipal = "13131313",
                Cnpj = "11111111111111",
                Cep = "49570000",
                Bairro = "Suiça",
                Logradouro = "Casa",
                Numero = "230",
                Status = "A",
                Email = "cooperfarma@email.com",
                Telefone = "99999999999",
                IdPessoaRepresentate = 1,
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
        private IEnumerable<Cooperativa> GetTestCooperativas()
        {
            return new List<Cooperativa>()
            {
                new ()
                {
                    Id= 1,
                    Nome = "CooperFARMA",
                    InscricaoEstadual ="12121212",
                    InscricaoMunicipal = "13131313",
                    Cnpj = "11111111111111",
                    Cep= "49570000",
                    Bairro= "Suiça",
                    Logradouro="Casa",
                    Numero="230",
                    Status="A",
                    Email = "cooperfarma@email.com",
                    Telefone = "99999999999",
                    IdPessoaRepresentate = 1,
                },
                  new ()
                {
                    Id= 2,
                    Nome = "CooperITA",
                    InscricaoEstadual ="15151515",
                    InscricaoMunicipal = "14141414",
                    Cnpj = "12311111111111",
                    Cep= "49580000",
                    Bairro= "Novo",
                    Logradouro="Zona Rural",
                    Numero="430",Status="I",
                    Email = "cooperita@email.com",
                    Telefone = "79996218534",
                    IdPessoaRepresentate = 2
                },
                   new ()
                {
                    Id= 3,
                    Nome = "CooperFRUTA",
                    InscricaoEstadual ="16161616",
                    InscricaoMunicipal = "15151515",
                    Cnpj = "15611111111111",
                    Cep= "49590000",
                    Bairro= "Piruleta",
                    Logradouro="Casa",
                    Numero="570",
                    Status="A",
                    Email = "cooperfruta@email.com",
                    Telefone = "99999991468",
                    IdPessoaRepresentate = 3
                },

             };
        }
    }
}