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
    public class PessoaControllerTests
    {
        private static PessoaController controller;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IPessoaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PessoaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestPessoas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPessoa());
            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Pessoa>()))
                .Verifiable();
            controller = new PessoaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaViewModel>));

            List<PessoaViewModel>? lista = (List<PessoaViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaViewModel>));
            PessoaViewModel pessoaModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Carol", pessoaModel.Nome);
            Assert.AreEqual("54786325484", pessoaModel.Cpf);
            Assert.AreEqual("Longe", pessoaModel.Bairro);
            Assert.AreEqual("Paulo Afonso", pessoaModel.Cidade);
            Assert.AreEqual("Bahia", pessoaModel.Estado);
            Assert.AreEqual("Num sei", pessoaModel.Logradouro);
            Assert.AreEqual("13", pessoaModel.Numero);
            Assert.AreEqual("71624626655", pessoaModel.Telefone);
            Assert.AreEqual("A", pessoaModel.Status);
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
            var result = controller.Create(GetNewPessoa());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaViewModel));
            PessoaViewModel pessoaModel = (PessoaViewModel)viewResult.ViewData.Model;


        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetPessoaModel().Id, GetTargetPessoaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaViewModel));
            PessoaViewModel pessoaModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Matheus", pessoaModel.Nome);
            Assert.AreEqual("31647924892", pessoaModel.Cpf);
            Assert.AreEqual("Suiça", pessoaModel.Bairro);
            Assert.AreEqual("Aracaju", pessoaModel.Cidade);
            Assert.AreEqual("Sergipe", pessoaModel.Estado);
            Assert.AreEqual("Num sei", pessoaModel.Logradouro);
            Assert.AreEqual("22", pessoaModel.Numero);
            Assert.AreEqual("47762145221", pessoaModel.Telefone);
            Assert.AreEqual("I", pessoaModel.Status);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetPessoaModel().Id, GetTargetPessoaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
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
        private PessoaViewModel GetNewPessoa()
        {
            return new PessoaViewModel
            {
                Id = 4,
                Cpf = "14876547823",
                Nome = "Sodre",
                Bairro = "Bem Longe",
                Cidade = "Irecê",
                Estado = "Bahia",
                Logradouro = "Num sei",
                Numero = "10",
                Telefone = "71458962354",
                Status = "I"
            };
        }
        private PessoaViewModel GetTargetPessoaModel()
        {
            return new PessoaViewModel
            {
                Id = 2,
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
        private IEnumerable<Pessoa> GetTestPessoas()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {   Id= 1,
                    Cpf= "54786325484",
                    Nome= "Carol",
                    Bairro= "Longe",
                    Cidade="Paulo Afonso",
                    Estado="Bahia",
                    Logradouro="Num sei",
                    Numero="13",
                    Telefone="71624626655",
                    Status="A"
                },
                new Pessoa
                {
                    Id= 2,
                    Cpf= "31647924892",
                    Nome= "Matheus",
                    Bairro= "Suiça",
                    Cidade="Aracaju",
                    Estado="Sergipe",
                    Logradouro="Num sei",
                    Numero="22",
                    Telefone="47762145221",
                    Status="I"},
                new Pessoa
                {
                    Id= 3,
                    Cpf= "74423541255",
                    Nome= "Frango",
                    Bairro= "Não tem",
                    Cidade="Itabaiana",
                    Estado="Sergipe",
                    Logradouro="Num sei",
                    Numero="S/N",
                    Telefone="79265123512",
                    Status="A"
                }
            };
        }
    }
}