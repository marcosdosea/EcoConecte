using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoConecteWeb.Controllers
{
    public class NoticiumController : Controller
    {
        private readonly INoticiumServices _noticiumService;
        private readonly IMapper _mapper;

        public NoticiumController(INoticiumServices noticiumService, IMapper mapper)
        {
            _noticiumService = noticiumService;
            _mapper = mapper;
        }

        // GET: Noticium_Controller
        public ActionResult Index()
        {
            var listaNotinium = _noticiumService.GetAll();
            var listaNoticiumModel = _mapper.Map<List<NoticiumViewModel>>(listaNotinium);
            return View(listaNoticiumModel);
        }

        // GET: Noticium_Controller/Details/5
        public ActionResult Detalhes(uint id)
        {
            Noticium? noticium = _noticiumService.GetById(id);
            NoticiumViewModel noticiumModel = _mapper.Map<NoticiumViewModel>(noticium);
            return View(noticiumModel);
        }

        // GET: Noticium_Controller/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: Noticium_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(NoticiumViewModel noticiumModel)
        {
            if (ModelState.IsValid)
            {
                var noticium = _mapper.Map<Noticium>(noticiumModel);
                _noticiumService.Inserir(noticium);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Noticium_Controller/Edit/5
        public ActionResult Editar(uint id)
        {
            Noticium? noticium = _noticiumService.GetById(id);
            NoticiumViewModel noticiumModel = _mapper.Map<NoticiumViewModel>(noticium);
            return View(noticiumModel);
        }

        // POST: Noticium_Controller/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(uint id, NoticiumViewModel noticiumModel)
        {
            if (ModelState.IsValid)
            {
                var noticium = _mapper.Map<Noticium>(noticiumModel);
                _noticiumService.Editar(noticium);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Noticium_Controller/Excluir/5
        public ActionResult Excluir(uint id)
        {
            Noticium? noticium = _noticiumService.GetById(id);
            NoticiumViewModel noticiumModel = _mapper.Map<NoticiumViewModel>(noticium);
            return View(noticiumModel);
        }

        // POST: Noticium_Controller/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(uint id, NoticiumViewModel noticiumModel)
        {
            _noticiumService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
