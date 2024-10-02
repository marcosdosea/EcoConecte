using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoConecteWeb.Controllers
{
    public class ColetaController : Controller
    {
        private readonly IColetaService _coletaService;
        private readonly IMapper _mapper;

        public ColetaController(IColetaService coletaService, IMapper mapper)
        {
            this._coletaService = coletaService;
            this._mapper = mapper;
        }

        // GET: Coleta_Controller
        public ActionResult Index()
        {
            var listaColeta = _coletaService.GetAll();
            var listaColetaModel = _mapper.Map<IEnumerable<ColetaViewModel>>(listaColeta);
            return View(listaColetaModel);
        }

        // GET: Coleta_Controller/Details/5
        public ActionResult Details(uint id)
        {
            var coleta = _coletaService.GetById(id);
            var coletaViewModel = _mapper.Map<ColetaViewModel>(coleta);
            return View(coletaViewModel);
        }

        // GET: Coleta_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coleta_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ColetaViewModel coletaModel)
        {
            if (ModelState.IsValid)
            {
                var coleta = _mapper.Map<Coleta>(coletaModel);
                _coletaService.Create(coleta);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Coleta_Controller/Edit/5
        public ActionResult Edit(uint id)
        {
            var coleta = _coletaService.GetById(id);
            var coletaModel = _mapper.Map<ColetaViewModel>(coleta);
            return View(coletaModel);
        }

        // POST: Coleta_Controller/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ColetaViewModel coletaModel)
        {
            if (ModelState.IsValid)
            {
                var coleta = _mapper.Map<Coleta>(coletaModel);
                _coletaService.Edit(coleta);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Coleta_Controller/Delete/5
        public ActionResult Delete(uint id)
        {
            var coleta = _coletaService.GetById(id);
            var coletaModel = _mapper.Map<ColetaViewModel>(coleta);
            return View(coletaModel);
        }

        // POST: Coleta_Controller/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, ColetaViewModel coletaModel)
        {
            _coletaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}