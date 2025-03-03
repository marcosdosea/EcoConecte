using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IPessoaService _pessoaService;
		private readonly IAgendamentoService _agendamentoService;
		private readonly IMapper _mapper;
    

        public UsuarioController(IPessoaService pessoaService, IAgendamentoService agendamentoService, IMapper mapper)
        {
            _agendamentoService = agendamentoService;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: Pessoa_Controller
        public IActionResult Index(int id)
        {
            if (id == 0)
            {
                return NotFound(); // Evita erro se o ID for inválido
            }

            ViewData["PessoaId"] = id; // Passa o ID para a View
            return View();
        }
        public ActionResult Edit(uint id)
        {
            Pessoa? pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        public ActionResult Agendamento()
        {
            return View();
        }

        
        // POST: AgendamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgendamentoViewModel agendamentoModel, int id)
        {
            
            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoModel);
                ViewData["PessoaId"] = id; // Passa o ID para a View
                _agendamentoService.Create(agendamento);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}