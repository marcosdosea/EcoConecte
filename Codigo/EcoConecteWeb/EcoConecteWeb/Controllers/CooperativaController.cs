using AutoMapper;
using Core.Service;
using Core;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EcoConecteWeb.Controllers
{
    public class CooperativaController : Controller
    {
        private readonly ICooperativaService _cooperativaService;
        private readonly IMapper _mapper;

        public CooperativaController(ICooperativaService cooperativaService, IMapper mapper)
        {
            _cooperativaService = cooperativaService;
            _mapper = mapper;
        }

        // GET: Cooperativa_Controller
        public ActionResult Index()
        {
            var listaCooperativas = _cooperativaService.GetAll();
            var listaCooperativasModel = _mapper.Map<List<CooperativaViewModel>>(listaCooperativas);
            return View(listaCooperativasModel);
        }
        [Authorize(Roles = "ADMROOT, COOPERADO")]
        // GET: Cooperativa_Controller/Details/5
        public ActionResult Details(uint id)
        {
            Cooperativa? cooperativa = _cooperativaService.Get(id);
            CooperativaViewModel cooperativaModel = _mapper.Map<CooperativaViewModel>(cooperativa);
            return View(cooperativaModel);
        }

        // GET: Cooperativa_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cooperativa_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CooperativaViewModel cooperativaModel)
        {
            if (ModelState.IsValid)
            {
                var cooperativa = _mapper.Map<Cooperativa>(cooperativaModel);
                _cooperativaService.Create(cooperativa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Cooperativa_Controller/Edit/5
        public ActionResult Edit(uint id)
        {
            Cooperativa? cooperativa = _cooperativaService.Get(id);
            CooperativaViewModel cooperativaModel = _mapper.Map<CooperativaViewModel>(cooperativa);
            return View(cooperativaModel);
        }

        // POST: Cooperativa_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, CooperativaViewModel cooperativaModel)
        {
            if (ModelState.IsValid)
            {
                var cooperativa = _mapper.Map<Cooperativa>(cooperativaModel);
                _cooperativaService.Update(cooperativa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Cooperativa_Controller/Delete/5
        public ActionResult Delete(uint id)
        {
            Cooperativa? cooperativa = _cooperativaService.Get(id);
            CooperativaViewModel cooperativaModel = _mapper.Map<CooperativaViewModel>(cooperativa);
            return View(cooperativaModel);
        }

        // POST:Cooperativa_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, CooperativaViewModel cooperativaModel)
        {
            _cooperativaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
