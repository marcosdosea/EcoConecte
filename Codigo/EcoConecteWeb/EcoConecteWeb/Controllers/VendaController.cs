using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;
        private readonly IMapper _mapper;

        public VendaController(IVendaService VendaService, IMapper mapper)
        {
            _vendaService = VendaService;
            _mapper = mapper;
        }

        // GET: VendaController
        public ActionResult Index()
        {
            var ListaVendas = _vendaService.GetAll();
            var ListaVendasModel = _mapper.Map<IEnumerable<VendaViewModel>>(ListaVendas);
            return View(ListaVendasModel);
        }

        // GET: VendaController/Details/5
        public ActionResult Details(uint id)
        {
           var Vendas = _vendaService.GetAll();
           var VendasModel = _mapper.Map<List<VendaViewModel>>(Vendas);
           return View(Vendas);
        }

        // GET: VendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaViewModel VendaModel)
        {
            if (ModelState.IsValid)
            {
                var CriaVenda = _mapper.Map<Vendamaterial>(VendaModel);
                _vendaService.Create(CriaVenda);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VendaController/Edit/5
        public ActionResult Edit(uint id)
        {
            var Venda = _vendaService.GetById(id); 
            var VendaViewModel = _mapper.Map<VendaViewModel>(Venda);
            return View(VendaViewModel);
        }

        // POST: VendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VendaViewModel VendaModel)
        {
            if (ModelState.IsValid)
            {
                var EditaVenda = _mapper.Map<Vendamaterial>(VendaModel);
                _vendaService.Update(EditaVenda);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VendaController/Delete/5
        public ActionResult Delete(uint id)
        {
            var Venda = _vendaService.GetById(id);
            var VendaViewModel = _mapper.Map<VendaViewModel>(Venda);
            return View(VendaViewModel);
        }

        // POST: VendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, VendaViewModel VendaModel)
        {
            _vendaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
