﻿using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiaService _noticiaService;
        private readonly IMapper _mapper;

        public NoticiaController(INoticiaService noticiaService, IMapper mapper)
        {
            this._noticiaService = noticiaService;
            this._mapper = mapper;
        }

        // GET: Lista pública de notícias
        [AllowAnonymous]
        public ActionResult ListaPublica()
        {
            var listaNoticia = _noticiaService.GetAll();
            var listaNoticiaModel = _mapper.Map<IEnumerable<NoticiaViewModel>>(listaNoticia);
            return View(listaNoticiaModel);
        }

        // GET: Detalhes públicos da notícia
        [AllowAnonymous]
        public ActionResult Detalhes(uint id)
        {
            var noticia = _noticiaService.GetById(id);
            if (noticia == null)
            {
                return NotFound();
            }
            var noticiaViewModel = _mapper.Map<NoticiaViewModel>(noticia);
            return View(noticiaViewModel);
        }

        // GET: Noticia_Controller
        [Authorize]
        public ActionResult Index()
        {
            var listaNoticia = _noticiaService.GetAll();
            var listaNoticiaModel = _mapper.Map<IEnumerable<NoticiaViewModel>>(listaNoticia);
            return View(listaNoticiaModel);
        }

        // GET: Noticia_Controller/Details/5
        [Authorize]
        public ActionResult Details(uint id)
        {
            var noticia = _noticiaService.GetById(id);
            var noticiaViewModel = _mapper.Map<NoticiaViewModel>(noticia);
            return View(noticiaViewModel);
        }

        // GET: Noticia_Controller/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Noticia_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(NoticiaViewModel noticiaModel)
        {
            if (ModelState.IsValid)
            {
                var noticia = _mapper.Map<Noticia>(noticiaModel);
                _noticiaService.Create(noticia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Noticia_Controller/Edit/5
        [Authorize]
        public ActionResult Edit(uint id)
        {
            var noticia = _noticiaService.GetById(id);
            var noticiaModel = _mapper.Map<NoticiaViewModel>(noticia);
            return View(noticiaModel);
        }

        // POST: Noticia_Controller/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(uint id, NoticiaViewModel noticiaModel)
        {
            if (ModelState.IsValid)
            {
                var noticia = _mapper.Map<Noticia>(noticiaModel);
                _noticiaService.Edit(noticia);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Noticia_Controller/Delete/5
        [Authorize]
        public ActionResult Delete(uint id)
        {
            var noticia = _noticiaService.GetById(id);
            var noticiaModel = _mapper.Map<NoticiaViewModel>(noticia);
            return View(noticiaModel);
        }

        // POST: Noticia_Controller/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(uint id, NoticiaViewModel noticiaModel)
        {
            _noticiaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
