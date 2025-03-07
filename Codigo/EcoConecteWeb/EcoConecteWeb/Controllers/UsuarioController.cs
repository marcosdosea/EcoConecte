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
        // GET: Usuario_Controller/Edit/5
        public ActionResult Edit(uint id)
        {
            var pessoa = _pessoaService.Get(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            var pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: Usuario_Controller/Edit/5
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

        public ActionResult AgendamentoEdit(uint id)
        {
            var agendamento = _agendamentoService.GetById(id);
            var agendamentoViewModel = _mapper.Map<AgendamentoViewModel>(agendamento);
            // Adiciona o ID da pessoa no ViewData para que a View tenha acesso
            ViewData["PessoaId"] = agendamentoViewModel.IdPessoa;
            return View(agendamentoViewModel);
        }

        // POST: AgendamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgendamentoEdit(uint id, AgendamentoViewModel agendamentoModel)
        {
            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoModel);
                _agendamentoService.Edit(agendamento);
            }
            return RedirectToAction("Agendadas", "Usuario", new { id = agendamentoModel.IdPessoa });
        }

        // GET: AgendamentoController/Delete/5
        public ActionResult AgendamentoDelete(uint id)
        {
            var agendamento = _agendamentoService.GetById(id);
            var agendamentoModel = _mapper.Map<AgendamentoViewModel>(agendamento);
            return View(agendamentoModel);
        }

        // POST: AgendamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgendamentoDelete(uint id, AgendamentoViewModel agendamento)
        {
            _agendamentoService.Delete(id);
            return RedirectToAction();
        }

    }
}