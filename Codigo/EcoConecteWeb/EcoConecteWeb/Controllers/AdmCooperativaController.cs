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
        public async Task<IActionResult> AgendamentoDeleteConfirmed(uint id, int idCoop)
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

        // GET: Confirmar Exclusão da Coleta
        public async Task<IActionResult> ColetaDelete(uint id)
        {
            var coleta = await _coletaService.GetByIdAsync(id);
            if (coleta == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ColetaViewModel>(coleta);
            return View(viewModel);
        }

        // POST: Excluir Coleta
        [HttpPost, ActionName("ColetaDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ColetaDeleteConfirmed(uint id, int idCoop)
        {
            var coleta = await _coletaService.GetByIdAsync(id);
            if (coleta != null)
            {
                await _coletaService.DeleteAsync(id);
            }

            return RedirectToAction("ListaColetas", "AdmCooperativa", new { id = idCoop });
        }

        [HttpGet]
        public async Task<IActionResult> ColetaEdit(uint id)
        {
            var coleta = await _coletaService.GetByIdAsync(id);
            if (coleta == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ColetaViewModel>(coleta);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ColetaEdit(uint id, ColetaViewModel model)
        {
            var coleta = await _coletaService.GetByIdAsync(model.Id);
            if (coleta == null)
            {
                return NotFound();
            }

            // Atualiza os dados da coleta
            coleta.Logradouro = model.Logradouro;
            coleta.Numero = int.Parse(model.Numero);
            coleta.DiaColeta = model.DiaColeta;
            coleta.HorarioInicio = model.HorarioInicio;
            coleta.HorarioTermino = model.HorarioTermino;

            var sucesso = await _coletaService.UpdateAsync(coleta);
            if (!sucesso)
            {
                ModelState.AddModelError("", "Erro ao atualizar a coleta.");
                return View(model);
            }

            return RedirectToAction("ListaColetas", "AdmCooperativa", new { id = coleta.IdCooperativa });
        }

        [HttpGet]
        public async Task<IActionResult> NoticiasEdit(int id)
        {
            var noticia = await _noticiaService.GetNoticiaForEditAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }

            // Mapeia o Core.Noticia para NoticiaViewModel
            var noticiaViewModel = _mapper.Map<NoticiaViewModel>(noticia);

            ViewData["idCoop"] = id;
            return View(noticiaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> NoticiasEdit(NoticiaViewModel model, int idCoop)
        {
            if (ModelState.IsValid)
            {
                // Mapeia o NoticiaViewModel para Noticia
                var noticia = _mapper.Map<Noticia>(model);

                var isEdited = await _noticiaService.EditNoticiaAsync(noticia);
                if (isEdited)
                {
                    return RedirectToAction("ListaNoticias", "AdmCooperativa", new { id = idCoop });
                }

                ModelState.AddModelError("", "Erro ao editar a notícia.");
            }

            ViewData["idCoop"] = idCoop;
            return View(model);
        }

        public async Task<IActionResult> NoticiasDelete(int id, int idCoop)
        {
            var noticia = await _noticiaService.ObterPorIdAsync(id);

            if (noticia == null)
                return NotFound();

            // Conversão manual de Noticia para NoticiaViewModel
            var noticiaViewModel = new NoticiaViewModel
            {
                Id = noticia.Id,
                Titulo = noticia.Titulo,
                Conteudo = noticia.Conteudo,
                Data = noticia.Data.ToString("dd/MM/yyyy")
            };

            ViewData["idCoop"] = idCoop;
            return View(noticiaViewModel);
        }

        // Confirma e processa a exclusão
        [HttpPost]
        public async Task<IActionResult> NoticiaDeleteConfirmed(int id, int idCoop)
        {
            var sucesso = await _noticiaService.ApagarNoticiaAsync(id);
            if (!sucesso)
                return NotFound();

            // Redireciona para a lista de notícias da cooperativa
            return RedirectToAction("ListaNoticias", "AdmCooperativa", new { id = idCoop });
        }

        // GET: Exibe a view de edição
        public async Task<IActionResult> OrientacoesEdit(uint id)
        {
            var orientacao = await _orientacoesService.ObterPorIdAsync(id);
            if (orientacao == null)
            {
                return NotFound();
            }

            var viewModel = new OrientacoesViewModel
            {
                Id = orientacao.Id,
                Titulo = orientacao.Titulo,
                Descricao = orientacao.Descricao
            };

            ViewData["idCoop"] = orientacao.IdCooperativa;
            return View(viewModel);
        }

        // POST: Salva a edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrientacoesEdit(OrientacoesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Erro ao editar a orientação."); ;
            }

            var orientacao = new Core.Orientacoes
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                IdCooperativa = uint.Parse(model.IdCooperativa)
            };

            var sucesso = await _orientacoesService.AtualizarAsync(orientacao);

            if (!sucesso)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao atualizar a orientação.");
                return View(model);
            }

            return RedirectToAction("ListaOrientacoes", new { id = model.IdCooperativa });
        }

        // Exibe a tela de confirmação da exclusão
        [HttpGet]
        public async Task<IActionResult> OrientacoesDelete(uint id)
        {
            var orientacao = await _orientacoesService.ObterPorIdAsync(id);
            if (orientacao == null) return NotFound();

            // Converter manualmente para ViewModel
            var model = new OrientacoesViewModel
            {
                Id = orientacao.Id,
                Titulo = orientacao.Titulo,
                Descricao = orientacao.Descricao,
                IdCooperativa = orientacao.IdCooperativa.ToString()
            };

            return View(model);
        }

        // Confirma e executa a exclusão
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrientacaoDeleteConfirmed(uint id, int idCoop)
        {
            var sucesso = await _orientacoesService.ExcluirAsync(id);
            if (!sucesso)
            {
                ModelState.AddModelError("", "Erro ao excluir a orientação.");
                return View("OrientacaoDelete", await _orientacoesService.ObterPorIdAsync(id));
            }

            return RedirectToAction("ListaOrientacoes", "AdmCooperativa", new { id = idCoop });
        }

    }
}