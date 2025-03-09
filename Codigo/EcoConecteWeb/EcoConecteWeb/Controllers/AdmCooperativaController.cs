using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Migrations;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class AdmCooperativaController : Controller
    {
        private readonly ICooperativaService _cooperativaService;
        private readonly IPessoaService _pessoaService;
        private readonly IAgendamentoService _agendamentoService;
        private readonly IColetaService _coletaService;
        private readonly INoticiaService _noticiaService;
        private readonly IOrientacoesService _orientacoesService;
        private readonly IVendaService _vendaService;
        private readonly IMapper _mapper;

        public AdmCooperativaController(IAgendamentoService agendamentoService, IPessoaService pessoaService, 
                                        ICooperativaService cooperativaService, IMapper mapper,
                                        IColetaService coletaService, INoticiaService noticiaService,
                                        IOrientacoesService orientacoesService, IVendaService vendaService)
        {
            _cooperativaService = cooperativaService;
            _pessoaService = pessoaService;
            _agendamentoService = agendamentoService;
            _coletaService = coletaService;
            _noticiaService = noticiaService;
            _orientacoesService = orientacoesService;
            _mapper = mapper;
            _orientacoesService = orientacoesService;
            _vendaService = vendaService;
        }

        // GET: Pessoa_Controller
        public ActionResult Index(uint id)
        {
            if (id == 0)
            {
                return NotFound(); // Evita erro se o ID for inválido
            }
            ViewData["PessoaId"] = id; // Passa o ID para a View
            Cooperativa? cooperativa = _cooperativaService.Get(id);
            CooperativaViewModel cooperativaModel = _mapper.Map<CooperativaViewModel>(cooperativa);
            return View(cooperativaModel);
        }

        // GET: Cooperativa_Controller/Edit/5
        public ActionResult Edit(uint id)
        {
            Cooperativa? cooperativa = _cooperativaService.Get(id);
            CooperativaViewModel cooperativaModel = _mapper.Map<CooperativaViewModel>(cooperativa);
            return View(cooperativaModel);
        }

        // POST: Cooperativa_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, CooperativaViewModel cooperativaModel)
        {
            if (ModelState.IsValid)
            {
                var cooperativa = _mapper.Map<Cooperativa>(cooperativaModel);
                _cooperativaService.Update(cooperativa);
            }
            return RedirectToAction("Index", "AdmCooperativa", new { id = id });
        }

        /// <summary>
        /// Busca Cooperativas pelo CEP
        /// </summary>
        /// <param name="CepCoop"></param>
        /// <returns></returns>
        public int buscaCoopCep(string CepCoop)
        {
            var listaCooperativa = _cooperativaService.GetAll().Where(a => a.Cep == CepCoop).ToList();
            var idCoop = listaCooperativa[0].Id;
            return (int)idCoop;
        }

        public ActionResult ListaCooperados(int id)
        {
            // Filtra as pessoas pelo IdCooperativa e apenas com Status diferente de "I"
            var listaPessoas = _pessoaService.GetAll()
                                              .Where(p => p.IdCooperativa == id && p.Status != "I")
                                              .ToList();

            ViewData["PessoaId"] = id; // Passa o ID para a View
            // Mapeia para a ViewModel
            var listaPessoasModel = _mapper.Map<List<PessoaViewModel>>(listaPessoas);
            return View(listaPessoasModel);
        }

        public ActionResult ListaAgendamentos(int id)
        {
            // Buscar a cooperativa pelo ID
            var cooperativa = _cooperativaService.Get((uint)id);
            if (cooperativa == null)
            {
                return NotFound("Cooperativa não encontrada.");
            }

            // Obter o CEP da cooperativa
            string cepCooperativa = cooperativa.Cep;

            // Filtrar os agendamentos cujo CEP seja igual ao da cooperativa
            var listaAgendamentos = _agendamentoService.GetAll()
                                                       .Where(a => a.Cep == cepCooperativa)
                                                       .ToList();

            ViewData["PessoaId"] = id; // Passa o ID para a View
            // Mapear para a ViewModel
            var listaAgendamentosModel = _mapper.Map<List<AgendamentoViewModel>>(listaAgendamentos);

            return View(listaAgendamentosModel);
        }

        public async Task<IActionResult> AgendamentosEdit(uint id, string CepCoop)
        {
            var agendamento = await _agendamentoService.GetByIdAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            var idCoop = buscaCoopCep(CepCoop);
            ViewData["idCoop"] = idCoop;
            var ViewModel = _mapper.Map<AgendamentoViewModel>(agendamento);
            return View(ViewModel);
        }

        // POST: Agendamento/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgendamentosEdit(AgendamentoViewModel ViewModel, int idCoop)
        {
            var agendamentoAtual = await _agendamentoService.GetByIdAsync(ViewModel.Id);

            // Atualiza os campos necessários
            agendamentoAtual.Data = ViewModel.Data;
            agendamentoAtual.Status = ViewModel.Status;
            
            var sucesso = await _agendamentoService.UpdateAsync(agendamentoAtual);
            if (sucesso == false)
            {
                return NotFound("Agendamento não foi atualizado!.");
            }
            return RedirectToAction("ListaAgendamentos", "AdmCooperativa", new { id = idCoop });

        }


        // GET: Confirmação de Exclusão
        public async Task<IActionResult> AgendamentosDelete(uint id, string CepCoop)
        {
            var agendamento = await _agendamentoService.ObterPorIdAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            var idCoop = buscaCoopCep(CepCoop);
            ViewData["idCoop"] = idCoop;
            var viewModel = _mapper.Map<AgendamentoViewModel>(agendamento);
            return View(viewModel);
        }

        // POST: Exclusão do Agendamento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id, int idCoop)
        {
            var agendamento = await _agendamentoService.ObterPorIdAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            await _agendamentoService.ExcluirAsync(id);
            return RedirectToAction("ListaAgendamentos", "AdmCooperativa", new { id = idCoop });
        }

        public ActionResult ListaColetas(int id)
        {
            // Filtrar as coletas apenas da cooperativa informada
            var listaColetas = _coletaService.GetAll()
                                             .Where(c => c.IdCooperativa == id)
                                             .ToList();

            // Mapear para a ViewModel
            var listaColetasModel = _mapper.Map<List<ColetaViewModel>>(listaColetas);

            return View(listaColetasModel);
        }

        public ActionResult ListaNoticias(int id)
        {
            // Filtrar as notícias pela cooperativa informada
            var listaNoticias = _noticiaService.GetAll()
                                               .Where(n => n.IdCooperativa == id)
                                               .ToList();

            // Mapear para a ViewModel
            var listaNoticiasModel = _mapper.Map<List<NoticiaViewModel>>(listaNoticias);

            return View(listaNoticiasModel);
        }

        public ActionResult ListaOrientacoes(int id)
        {
            // Filtrar as orientações pela cooperativa informada
            var listaOrientacoes = _orientacoesService.GetAll()
                                                      .Where(o => o.IdCooperativa == id)
                                                      .ToList();

            // Mapear para a ViewModel
            var listaOrientacoesModel = _mapper.Map<List<OrientacoesViewModel>>(listaOrientacoes);

            return View(listaOrientacoesModel);
        }

        public ActionResult ListaVenda(int id)
        {
            // Obter todas as pessoas da cooperativa informada
            var pessoasDaCooperativa = _pessoaService.GetAll()
                                                     .Where(p => p.IdCooperativa == id)
                                                     .Select(p => p.Id)
                                                     .ToList();

            // Filtrar as vendas pelas pessoas que pertencem à cooperativa
            var listaVendas = _vendaService.GetAll()
                                           .Where(v => pessoasDaCooperativa.Contains(v.IdPessoa))
                                           .ToList();

            // Mapear para a ViewModel
            var listaVendasModel = _mapper.Map<List<VendaViewModel>>(listaVendas);

            return View(listaVendasModel);
        }

    }
}