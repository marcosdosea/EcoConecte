using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoConecteWeb.Controllers
{
    public ColetaController(IColetaService coletaService, IMapper mapper)
    {
        _coletaService = coletaService;
        _mapper = mapper;
    }

    // GET: Coleta
    public ActionResult Index()
    {
        var listaColetas = _coletaService.GetAll();
        var listaColetasModel = _mapper.Map<List<ColetaViewModel>>(listaColetas);
        return View(listaColetasModel);
    }

    // GET: Coleta/Details/5
    public ActionResult Details(uint id)
    {
        Coleta? coleta = _coletaService.GetById(id);
        ColetaViewModel coletaModel = _mapper.Map<ColetaViewModel>(coleta);
        return View(coletaModel);
    }

    // GET: Coleta/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Coleta/Create
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

    // GET: Coleta/Edit/5
    public ActionResult Edit(uint id)
    {
        Coleta? coleta = _coletaService.GetById(id);
        ColetaViewModel coletaModel = _mapper.Map<ColetaViewModel>(coleta);
        return View(coletaModel);
    }

    // POST: Coleta/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, ColetaViewModel coletaModel)
    {
        if (ModelState.IsValid)
        {
            var coleta = _mapper.Map<Coleta>(coletaModel);
            _coletaService.Update(coleta);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Coleta/Delete/5
    public ActionResult Delete(uint id)
    {
        Coleta? coleta = _coletaService.GetById(id);
        ColetaViewModel coletaModel = _mapper.Map<ColetaViewModel>(coleta);
        return View(coletaModel);
    }

    // POST: Coleta/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, ColetaViewModel coletaModel)
    {
        _coletaService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}