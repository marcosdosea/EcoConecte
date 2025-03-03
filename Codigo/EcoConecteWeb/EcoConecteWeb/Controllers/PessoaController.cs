using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: Pessoa_Controller
        public ActionResult Index()
        {
            var listaPessoas = _pessoaService.GetAll();
            var listaPessoasModel = _mapper.Map<List<PessoaViewModel>>(listaPessoas);
            return View(listaPessoasModel);
        }

        // GET: Pessoa_Controller/Details/5
        public ActionResult Details(uint id)
        {
            Pessoa? pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // GET: Pessoa_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                _pessoaService.Create(pessoa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Pessoa_Controller/Edit/5
        public ActionResult Edit(uint id)
        {
            var pessoa = _pessoaService.Get(id);

            if (pessoa == null)
            {
                return NotFound(); // Retorna erro 404 se não encontrar
            }

            var pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: Pessoa_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(uint id, PessoaViewModel pessoaModel)
        {
            if (!ModelState.IsValid)
            {
                return View(pessoaModel);
            }

            var pessoaExistente = _pessoaService.Get(id);

            if (pessoaExistente == null)
            {
                return NotFound();
            }
            _mapper.Map(pessoaModel, pessoaExistente);
            _pessoaService.Edit(pessoaExistente);
            return RedirectToAction(nameof(Index));
        }


        // GET: Pessoa_Controller/Delete/5
        public ActionResult Delete(uint id)
        {
            Pessoa? pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: Pessoa_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, PessoaViewModel pessoaModel)
        {
            _pessoaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}