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
        public ActionResult Edit(uint id)
        {
            ViewData["PessoaId"] = id; // Passa o ID para a View
            Pessoa? pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        public ActionResult Agendamento(uint id)
        {
            ViewData["PessoaId"] = id; // Passa o ID para a View
            return View();
        }


        // POST: AgendamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgendamentoViewModel agendamentoModel)
        {

            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoModel);
                _agendamentoService.Create(agendamento);
                var pessoaId = agendamento.IdPessoa;
                return RedirectToAction("Agendadas", "Usuario", new { id = pessoaId });
            }
            return View(agendamentoModel);
        }

        public ActionResult Agendadas(uint id)
        {
            ViewData["PessoaId"] = id; // Passa o ID para a View
            var agendamentos = _agendamentoService.GetAll()
       .Where(a => a.IdPessoa == id)
       .Select(a => new AgendamentoViewModel
       {
           Id = a.Id,
           IdPessoa = a.IdPessoa,
           Data = a.Data,
           Cep = a.Cep,
           Logradouro = a.Logradouro,
           Numero = a.Numero,
           Bairro = a.Bairro,
           Cidade = a.Cidade,
           Estado = a.Estado,
           Status = a.Status
       }).ToList();

            return View(agendamentos);
        }


        // POST: AgendamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AgendamentoViewModel agendamentoModel)
        {

            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoModel);
                _agendamentoService.GetAll();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}