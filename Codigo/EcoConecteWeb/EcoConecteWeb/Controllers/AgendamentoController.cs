using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoService agendamentoService;
        private readonly IMapper mapper;

        public AgendamentoController(IAgendamentoService agendamentoService, IMapper mapper)
        {
            this.agendamentoService = agendamentoService;
            this.mapper = mapper;
        }

        // GET: AgendamentoController
        public ActionResult Index()
        {
            var agendamentos = agendamentoService.GetAll();
            var agendamentosViewModel = mapper.Map<IEnumerable<AgendamentoViewModel>>(agendamentos);
            return View(agendamentosViewModel);
        }

        // GET: AgendamentoController/Details/5
        public ActionResult Details(uint id)
        {
            var agendamento = agendamentoService.GetById(id);
            var agendamentoViewModel = mapper.Map<AgendamentoViewModel>(agendamento);
            return View(agendamentoViewModel);
        }

        // GET: AgendamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgendamentoViewModel agendamentoModel)
        {
            if (ModelState.IsValid)
            {
                var agendamento = mapper.Map<Agendamento>(agendamentoModel);
                agendamentoService.Create(agendamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AgendamentoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var agendamento = agendamentoService.GetById(id);
            var agendamentoViewModel = mapper.Map<AgendamentoViewModel>(agendamento);
            return View(agendamentoViewModel);
        }

        // POST: AgendamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, AgendamentoViewModel agendamento)
        {
            try
            {   
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgendamentoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var agendamento = agendamentoService.GetById(id);
            var agendamentoViewModel = mapper.Map<AgendamentoViewModel>(agendamento);
            return View(agendamentoViewModel);
        }

        // POST: AgendamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, AgendamentoViewModel agendamento)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
