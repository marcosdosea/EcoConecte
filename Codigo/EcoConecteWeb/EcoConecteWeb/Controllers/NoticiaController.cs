using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiaServices _noticiaService;
        private readonly IMapper _mapper;

        public NoticiaController(INoticiaServices noticiaService, IMapper mapper)
        {
            this._noticiaService = noticiaService;
            this._mapper = mapper;
        }

        // GET: Noticium_Controller
        public ActionResult Index()
        {
            var listaNoticia = _noticiaService.GetAll();
            var listaNoticiaModel = _mapper.Map<IEnumerable<NoticiaViewModel>>(listaNoticia);
            return View(listaNoticiaModel);
        }

        // GET: Noticium_Controller/Details/5
        public ActionResult Details(uint id)
        {
            var noticia = _noticiaService.GetById(id);
            var noticiaViewModel = _mapper.Map<NoticiaViewModel>(noticia);
            return View(noticiaViewModel);
        }

        // GET: Noticium_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Noticium_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoticiaViewModel noticiaModel)
        {
            if (ModelState.IsValid)
            {
                var noticia = _mapper.Map<Noticia>(noticiaModel);
                _noticiaService.Create(noticia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Noticium_Controller/Edit/5
        public ActionResult Edit(uint id)
        {
            var noticia = _noticiaService.GetById(id);
            var noticiaModel = _mapper.Map<NoticiaViewModel>(noticia);
            return View(noticiaModel);
        }

        // POST: Noticium_Controller/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, NoticiaViewModel noticiaModel)
        {
            if (ModelState.IsValid)
            {
                var noticia = _mapper.Map<Noticia>(noticiaModel);
                _noticiaService.Edit(noticia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Noticium_Controller/Delete/5
        public ActionResult Delete(uint id)
        {
            var noticia = _noticiaService.GetById(id);
            var noticiaModel = _mapper.Map<NoticiaViewModel>(noticia);
            return View(noticiaModel);
        }

        // POST: Noticium_Controller/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, NoticiaViewModel noticiaModel)
        {
            _noticiaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
