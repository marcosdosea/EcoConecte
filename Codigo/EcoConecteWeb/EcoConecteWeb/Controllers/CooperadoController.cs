using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class CooperadoController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly IAgendamentoService _agendamentoService;
        private readonly IMapper _mapper;


        public CooperadoController(IPessoaService pessoaService, IAgendamentoService agendamentoService, IMapper mapper)
        {
            _agendamentoService = agendamentoService;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: Cooperado_Controller
        public ActionResult Index(uint id)
        {
            if (id == 0)
            {
                return NotFound(); // Evita erro se o ID for inválido
            }
            ViewData["PessoaId"] = id; // Passa o ID para a View
            Pessoa? pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }
        // GET: Cooperado_Controller/Edit/5
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

        // POST: Cooperado_Controller/Edit/5
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
            return RedirectToAction("Index", new { id = id });
        }
    }
}