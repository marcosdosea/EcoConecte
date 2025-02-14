using AutoMapper;
using Core.Service;
using Core;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class OrientacoesController : Controller
    {
        private readonly IOrientacoesService _orientacoesService;
        private readonly IMapper _mapper;

        public OrientacoesController(IOrientacoesService orientacoesService, IMapper mapper)
        {
            this._orientacoesService = orientacoesService;
            this._mapper = mapper;
        }

        // GET: Orientcoes_Controller
        public ActionResult Index()
        {
            var listaOrientacoes = _orientacoesService.GetAll();
            var listaOrientacoesModel = _mapper.Map<IEnumerable<OrientacoesViewModel>>(listaOrientacoes);
            return View(listaOrientacoesModel);
        }
        // GET: Orientcoes_Controller/Details/5
        public ActionResult ConsultarOrientacoes()
        {
            var listaOrientacoes = _orientacoesService.GetAll();
            var listaOrientacoesModel = _mapper.Map<IEnumerable<OrientacoesViewModel>>(listaOrientacoes);
            return View(listaOrientacoesModel);
        }

        // GET: Orientcoes_Controller/Details/5
        public ActionResult Details(uint id)
        {
            var orientcoes = _orientacoesService.GetById(id);
            var orientacoesViewModel = _mapper.Map<OrientacoesViewModel>(orientcoes);
            return View(orientacoesViewModel);
        }

        // GET: Orientcoes_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orientcoes_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrientacoesViewModel orientcoesModel)
        {
            if (ModelState.IsValid)
            {
                var orientacoes = _mapper.Map<Orientacoes>(orientcoesModel);
                _orientacoesService.Create(orientacoes);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Orientcoes_Controller/Edit/5
        public ActionResult Edit(uint id)
        {
            var orientcoes = _orientacoesService.GetById(id);
            var orientacoesModel = _mapper.Map<OrientacoesViewModel>(orientcoes);
            return View(orientacoesModel);
        }

        // POST: Orientcoes_Controller/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, OrientacoesViewModel orientacoesModel)
        {
            if (ModelState.IsValid)
            {
                var orientacoes = _mapper.Map<Orientacoes>(orientacoesModel);
                _orientacoesService.Edit(orientacoes);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Orientcoes_Controller/Delete/5
        public ActionResult Delete(uint id)
        {
            var orientacoes = _orientacoesService.GetById(id);
            var orientacoesModel = _mapper.Map<OrientacoesViewModel>(orientacoes);
            return View(orientacoesModel);
        }

        // POST: Orientcoes_Controller/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, OrientacoesViewModel orientacoesModel)
        {
            _orientacoesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
