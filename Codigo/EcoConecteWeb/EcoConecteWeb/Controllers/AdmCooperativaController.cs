using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Migrations;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using System.Security.Claims;

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

        public ActionResult CooperadosList(int id, string nomeFiltro, string cpfFiltro, string cidadeFiltro)
        {
            var pessoas = _pessoaService.GetAll()
                                        .Where(p => p.IdCooperativa == id && p.Status != "I");

            if (!string.IsNullOrWhiteSpace(nomeFiltro))
                pessoas = pessoas.Where(p => p.Nome.Contains(nomeFiltro));

            if (!string.IsNullOrWhiteSpace(cpfFiltro))
                pessoas = pessoas.Where(p => p.Cpf.Contains(cpfFiltro));

            if (!string.IsNullOrWhiteSpace(cidadeFiltro))
                pessoas = pessoas.Where(p => p.Cidade.Contains(cidadeFiltro));

            ViewData["PessoaId"] = id;
            ViewData["NomeFiltro"] = nomeFiltro;
            ViewData["CpfFiltro"] = cpfFiltro;
            ViewData["CidadeFiltro"] = cidadeFiltro;
            ViewData["FormAction"] = "CooperadosList"; // usado na View

            var listaPessoasModel = _mapper.Map<List<PessoaViewModel>>(pessoas.ToList());
            return View(listaPessoasModel);
        }


        public ActionResult AgendamentosList(int id)
        {
            // Buscar a cooperativa pelo ID
            var cooperativa = _cooperativaService.Get((uint)id);
            if (cooperativa == null)
            {
                return NotFound("Cooperativa não encontrada.");
            }

            // Obter o CEP da cooperativa
            string cepCooperativa = cooperativa.Cep;

            var AgendamentosList = _agendamentoService.GetAll()
                                                       .Where(a => a.Cep == cepCooperativa)
                                                       .ToList();

            ViewData["PessoaId"] = id; // Passa o ID para a View
            // Mapear para a ViewModel
            var AgendamentosListModel = _mapper.Map<List<AgendamentoViewModel>>(AgendamentosList);

            return View(AgendamentosListModel);
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
            return RedirectToAction("AgendamentosList", "AdmCooperativa", new { id = idCoop });

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
            return RedirectToAction("AgendamentosList", "AdmCooperativa", new { id = idCoop });
        }

        public ActionResult ColetasList(int id, string cepFiltro, string logradouroFiltro, string diaColetaFiltro)
        {
            // Filtrar as coletas apenas da cooperativa informada
            var coletasQuery = _coletaService.GetAll().Where(c => c.IdCooperativa == id);

            // Aplicar filtros, se forem fornecidos
            if (!string.IsNullOrEmpty(cepFiltro))
            {
                coletasQuery = coletasQuery.Where(c => c.Cep.Contains(cepFiltro));
            }

            if (!string.IsNullOrEmpty(logradouroFiltro))
            {
                coletasQuery = coletasQuery.Where(c => c.Logradouro.Contains(logradouroFiltro));
            }

            if (!string.IsNullOrEmpty(diaColetaFiltro))
            {
                DateTime diaColeta;
                if (DateTime.TryParse(diaColetaFiltro, out diaColeta))
                {
                    coletasQuery = coletasQuery.Where(c => c.DiaColeta.Date == diaColeta.Date);
                }
            }

            // Obter as coletas filtradas
            var coletasList = coletasQuery.ToList();

            // Mapear para a ViewModel
            var coletasListModel = _mapper.Map<List<ColetaViewModel>>(coletasList);

            // Passar os filtros de volta para a View (para preenchimento dos campos de filtro)
            ViewData["CepFiltro"] = cepFiltro;
            ViewData["LogradouroFiltro"] = logradouroFiltro;
            ViewData["DiaColetaFiltro"] = diaColetaFiltro;
            ViewData["IdCoop"] = id;

            return View(coletasListModel);
        }


        public ActionResult NoticiasList(int id, string tipoFiltro, string dataInicial)
        {
            // Filtrar as notícias pela cooperativa informada
            var NoticiasList = _noticiaService.GetAll()
                                              .Where(n => n.IdCooperativa == id)
                                              .ToList();

            // Aplicar filtro por título (Tipo do Material)
            if (!string.IsNullOrWhiteSpace(tipoFiltro))
            {
                NoticiasList = NoticiasList
                    .Where(n => n.Titulo.Contains(tipoFiltro, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Aplicar filtro por data (Data Inicial)
            if (!string.IsNullOrWhiteSpace(dataInicial) && DateTime.TryParse(dataInicial, out var data))
            {
                NoticiasList = NoticiasList
                    .Where(n => n.Data >= data)
                    .ToList();
            }

            // Mapear para a ViewModel
            var NoticiasListModel = _mapper.Map<List<NoticiaViewModel>>(NoticiasList);

            // Passar parâmetros de filtro para a view
            ViewData["TituloFiltro"] = tipoFiltro;
            ViewData["DataFiltro"] = dataInicial;
            ViewData["idCoop"] = id;
            ViewData["FormAction"] = "NoticiasList";

            return View(NoticiasListModel);
        }


        public IActionResult OrientacoesList(int id, string tipoFiltro)
        {
            ViewData["TituloFiltro"] = tipoFiltro;
            ViewData["FormAction"] = "OrientacoesList";

            // Busca todas as orientações vinculadas à cooperativa (pessoaId)
            var orientacoes = _orientacoesService.GetAll()
                .Where(o => o.IdCooperativa == id);

            // Aplica o filtro, se informado
            if (!string.IsNullOrWhiteSpace(tipoFiltro))
            {
                orientacoes = orientacoes
                    .Where(o => o.Titulo.Contains(tipoFiltro));
            }

            var viewModel = orientacoes
                .Select(o => new OrientacoesViewModel
                {
                    Id = o.Id,
                    Titulo = o.Titulo,
                    Descricao = o.Descricao
                })
                .ToList();

            return View(viewModel);
        }


        public ActionResult VendasList(int id, string tipoFiltro, DateTime? dataInicial, DateTime? dataFinal)
        {
            // Obter todas as pessoas da cooperativa informada
            var pessoasDaCooperativa = _pessoaService.GetAll()
                                                     .Where(p => p.IdCooperativa == id)
                                                     .Select(p => p.Id)
                                                     .ToList();

            // Filtrar as vendas pelas pessoas que pertencem à cooperativa
            var vendas = _vendaService.GetAll()
                                      .Where(v => pessoasDaCooperativa.Contains(v.IdPessoa));

            // Aplicar o filtro por tipo, se fornecido
            if (!string.IsNullOrEmpty(tipoFiltro))
            {
                vendas = vendas.Where(v => v.Tipo.Contains(tipoFiltro)); // Usar Contains para filtrar por parte do tipo
            }

            // Aplicar o filtro por data, se fornecido
            if (dataInicial.HasValue)
            {
                vendas = vendas.Where(v => v.Data >= dataInicial.Value);
            }

            if (dataFinal.HasValue)
            {
                vendas = vendas.Where(v => v.Data <= dataFinal.Value);
            }

            // Obter as vendas filtradas
            var vendasList = vendas.ToList();

            // Mapear para a ViewModel
            var vendasListModel = _mapper.Map<List<VendaViewModel>>(vendasList);

            // Definir os filtros aplicados para a View
            ViewData["TipoFiltro"] = tipoFiltro;
            ViewData["DataInicio"] = dataInicial?.ToString("yyyy-MM-dd");
            ViewData["DataFim"] = dataFinal?.ToString("yyyy-MM-dd");

            return View(vendasListModel);
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

            return RedirectToAction("ColetasList", "AdmCooperativa", new { id = idCoop });
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

            return RedirectToAction("ColetasList", "AdmCooperativa", new { id = coleta.IdCooperativa });
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
                    return RedirectToAction("NoticiasList", "AdmCooperativa", new { id = idCoop });
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
            return RedirectToAction("NoticiasList", "AdmCooperativa", new { id = idCoop });
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

            return RedirectToAction("OrientacoesList", new { id = model.IdCooperativa });
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

            return RedirectToAction("OrientacoesList", "AdmCooperativa", new { id = idCoop });
        }

        public ActionResult OrientacoesCreate(int pessoaId)
        {
            ViewData["PessoaId"] = pessoaId;
            return View();
        }

        // POST: AdmCooperativa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrientacoesCreate(OrientacoesViewModel orientacoesModel)
        {
            if (ModelState.IsValid)
            {
                var orientacoes = _mapper.Map<Orientacoes>(orientacoesModel);
                _orientacoesService.Create(orientacoes);

                return RedirectToAction("OrientacoesList", "AdmCooperativa", new { id = orientacoesModel.IdCooperativa });
            }
            ViewData["PessoaId"] = orientacoesModel.IdCooperativa;
            ViewData["Erro"] = "Não foi possível criar a orientação. Verifique os campos e tente novamente.";
            return View(orientacoesModel);
        }

        public async Task<IActionResult> VendasEdit(uint id, int idCoop)
        {
            var venda = await _vendaService.ObterPorIdAsync(id);
            if (venda == null) return NotFound();

            var vendaViewModel = new VendaViewModel
            {
                Id = venda.Id,
                Tipo = venda.Tipo,
                Valor = venda.Valor,
                Quantidade = venda.Quantidade,
                Data = venda.Data,
                IdPessoa = venda.IdPessoa
            };

            ViewData["idCoop"] = idCoop;
            return View(vendaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> VendasEdit(VendaViewModel vendaViewModel, int idCoop)
        {
            ModelState.Remove("IdPessoaNavigation"); // Se houver erro de validação nesse campo, ele será ignorado
            if (!ModelState.IsValid)
            {
                return View(vendaViewModel);
            }

            try
            {
                var venda = new Venda
                {
                    Id = vendaViewModel.Id,
                    Tipo = vendaViewModel.Tipo,
                    Valor = vendaViewModel.Valor,
                    Quantidade = vendaViewModel.Quantidade,
                    Data = vendaViewModel.Data,
                    IdCooperativa = (uint)idCoop,
                    IdPessoa = vendaViewModel.IdPessoa,
                };

                await _vendaService.AtualizarAsync(venda);
                return RedirectToAction("VendasList", "AdmCooperativa", new { id = idCoop });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao atualizar a venda: " + ex.Message);
                return View(vendaViewModel);
            }
        }

        public async Task<IActionResult> VendasDelete(uint id, int idCoop)
        {
            var venda = await _vendaService.ObterPorIdAsync(id);
            if (venda == null) return NotFound();

            var vendaViewModel = _mapper.Map<VendaViewModel>(venda);
            ViewData["idCoop"] = idCoop;
            return View(vendaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> VendasDeleteConfirmed(uint id, int idCoop)
        {
            var sucesso = await _vendaService.ExcluirAsync(id);
            if (!sucesso)
            {
                ModelState.AddModelError("", "Erro ao excluir a venda.");
                return View();
            }
            ViewData["idCoop"] = idCoop;
            return RedirectToAction("VendasList", "AdmCooperativa", new { id = idCoop });
        }

        public IActionResult ColetasCreate(int pessoaId)
        {
            ViewData["PessoaId"] = pessoaId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ColetasCreate(ColetaViewModel coletaViewModel)
        {
            if (ModelState.IsValid)
            {
                var coleta = _mapper.Map<Coleta>(coletaViewModel);
                _coletaService.Create(coleta);

                // Redireciona de volta para a listagem da cooperativa
                return RedirectToAction("ColetasList", new { id = coletaViewModel.IdCooperativa });
            }

            // Caso haja erro, mantém o PessoaId e exibe uma mensagem
            ViewData["PessoaId"] = coletaViewModel.IdCooperativa;
            ViewData["Erro"] = "Não foi possível cadastrar a coleta. Verifique os campos.";
            return View(coletaViewModel);
        }

        public IActionResult NoticiasCreate(int pessoaId)
        {
            ViewData["PessoaId"] = pessoaId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NoticiasCreate(NoticiaViewModel noticiaModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var noticia = _mapper.Map<Noticia>(noticiaModel);
                    _noticiaService.Create(noticia);

                    // Redireciona para a lista de notícias, passando o id da cooperativa
                    return RedirectToAction("NoticiasList", new { id = noticia.IdCooperativa });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível cadastrar a notícia. Erro: " + ex.Message);
                }
            }

            ViewData["PessoaId"] = noticiaModel.IdCooperativa; // Garante que o valor seja mantido ao retornar a view
            return View(noticiaModel);
        }

        public IActionResult VendasCreate(int pessoaId)
        {
            ViewData["PessoaId"] = pessoaId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VendasCreate(VendaViewModel vendaModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var venda = _mapper.Map<Venda>(vendaModel);
                    _vendaService.Create(venda);

                    // Redireciona para a lista de vendas da cooperativa
                    return RedirectToAction("VendasList", new { id = venda.IdCooperativa });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível cadastrar a venda. Erro: " + ex.Message);
                }
            }

            // Garante que o IdCooperativa continue visível após erro de validação
            ViewData["PessoaId"] = vendaModel.IdCooperativa;

            return View(vendaModel);
        }

        // GET: Pessoa/Edit/5
        public ActionResult CooperadosEdit(uint id)
        {
            var pessoa = _pessoaService.Get(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CooperadosEdit(uint id, PessoaViewModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pessoaExistente = _pessoaService.Get(id);
                    if (pessoaExistente == null)
                    {
                        return NotFound();
                    }

                    _mapper.Map(pessoaModel, pessoaExistente);
                    _pessoaService.Edit(pessoaExistente);

                    return RedirectToAction("CooperadosList", new { id = pessoaExistente.IdCooperativa });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível atualizar pessoa. Erro: " + ex.Message);
                }
            }

            // Retorna a View com os dados preenchidos em caso de erro
            return View(pessoaModel);
        }

        public IActionResult BuscarCooperado(int idCooperativa)
        {
            var pessoas = _pessoaService.GetAll()
                .Where(p => p.IdCooperativa == idCooperativa);

            var pessoasViewModel = pessoas.Select(p => new PessoaViewModel
            {
                Id = p.Id,
                Nome = p.Nome
            }).ToList();

            return View(pessoasViewModel);
        }

    }
}