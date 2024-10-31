using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Core.Service; // Namespace correto para INoticiaService
using AutoMapper; // Adicione este namespace se não estiver presente

namespace EcoConecteWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoticiaService _noticiaService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, INoticiaService noticiaService, IMapper mapper)
        {
            _logger = logger;
            _noticiaService = noticiaService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            // Recuperando todas as notícias
            var noticias = _noticiaService.GetAll();
            var noticiasModel = _mapper.Map<IEnumerable<NoticiaViewModel>>(noticias);

            return View(noticiasModel); // Passando a lista de notícias para a View
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
