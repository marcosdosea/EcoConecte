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
        public ActionResult Index(string dataFiltro, string statusFiltro)
        {
            // Buscar todos os agendamentos
            var agendamentos = agendamentoService.GetAll();

            // Aplicar o filtro de Data, caso o parâmetro seja fornecido
            if (!string.IsNullOrEmpty(dataFiltro))
            {
                DateTime dataFiltroParsed;
                if (DateTime.TryParse(dataFiltro, out dataFiltroParsed))
                {
                    agendamentos = agendamentos.Where(a => a.Data.Date == dataFiltroParsed.Date);
                }
            }

            // Aplicar o filtro de Status, caso o parâmetro seja fornecido
            if (!string.IsNullOrEmpty(statusFiltro))
            {
                agendamentos = agendamentos.Where(a => a.Status.Equals(statusFiltro, StringComparison.OrdinalIgnoreCase));
            }

            // Mapear os agendamentos para o ViewModel
            var agendamentosViewModel = mapper.Map<IEnumerable<AgendamentoViewModel>>(agendamentos);

            // Passar os valores dos filtros para a View
            ViewData["DataFiltro"] = dataFiltro;
            ViewData["StatusFiltro"] = statusFiltro;

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
        public ActionResult Edit(uint id, AgendamentoViewModel agendamentoModel)
        {
            if (ModelState.IsValid)
            {
                var agendamento = mapper.Map<Agendamento>(agendamentoModel);
                agendamentoService.Edit(agendamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AgendamentoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var agendamento = agendamentoService.GetById(id);
            var agendamentoModel = mapper.Map<AgendamentoViewModel>(agendamento);
            return View(agendamentoModel);
        }

        // POST: AgendamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, AgendamentoViewModel agendamento)
        {
            agendamentoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
