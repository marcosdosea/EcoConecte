using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Security.Claims;

namespace EcoConecteWeb.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;
        private readonly IMapper _mapper;

        public VendaController(IVendaService VendaService, IMapper mapper)
        {
            _vendaService = VendaService;
            _mapper = mapper;
        }

        // GET: VendaController
        public ActionResult Index(string tipoFiltro, string dataInicio, string dataFim, string idPessoaFiltro)
        {
            // Converte as datas de string para DateTime, se possível
            DateTime? dataInicial = null;
            DateTime? dataFinal = null;

            if (DateTime.TryParse(dataInicio, out DateTime parsedDataInicio))
            {
                dataInicial = parsedDataInicio;
            }

            if (DateTime.TryParse(dataFim, out DateTime parsedDataFim))
            {
                dataFinal = parsedDataFim;
            }

            // Obtém as vendas com base nos filtros
            var vendas = _vendaService.GetAll();

            // Aplica os filtros
            if (!string.IsNullOrEmpty(tipoFiltro))
            {
                vendas = vendas.Where(v => v.Tipo.Contains(tipoFiltro, StringComparison.OrdinalIgnoreCase));
            }

            if (dataInicial.HasValue)
            {
                vendas = vendas.Where(v => v.Data >= dataInicial.Value);
            }

            if (dataFinal.HasValue)
            {
                vendas = vendas.Where(v => v.Data <= dataFinal.Value);
            }

            if (!string.IsNullOrEmpty(idPessoaFiltro))
            {
                if (uint.TryParse(idPessoaFiltro, out uint idPessoa))
                {
                    vendas = vendas.Where(v => v.IdPessoa == idPessoa);
                }
            }

            // Mapeia para o ViewModel
            var ListaVendasModel = _mapper.Map<IEnumerable<VendaViewModel>>(vendas);

            // Passa os dados de filtro para a View
            ViewData["TipoFiltro"] = tipoFiltro;
            ViewData["DataInicio"] = dataInicio;
            ViewData["DataFim"] = dataFim;
            ViewData["IdPessoaFiltro"] = idPessoaFiltro;

            return View(ListaVendasModel);
        }

        // GET: VendaController
        // Ação para consultar as vendas
        public ActionResult ConsultaVenda(uint id)
        {
            // Supondo que o id logado seja o id de pessoa ou algo similar
            var userId = User.Identity.Name; // ou User.Identity.GetUserId() dependendo do seu método de autenticação

            // Recupera as vendas filtradas para o id da pessoa logada
            var vendas = _vendaService.GetAll()
                .Where(v => v.IdPessoa == id)  // Filtra pelas vendas da pessoa logada
                .ToList();

            // Mapeia para o ViewModel
            var ListaVendasModel = _mapper.Map<IEnumerable<VendaViewModel>>(vendas);

            // Passa o ID da pessoa logada para a View
            ViewData["PessoaId"] = userId;

            return View(ListaVendasModel);
        }

        // GET: VendaController
        public ActionResult ConsultaVendaPessoa(uint id)
        {
            var vendas = _vendaService.GetById(id);
            var ListaVendasModel = _mapper.Map<IEnumerable<VendaViewModel>>(vendas);
            return View(ListaVendasModel);
        }



        // GET: VendaController/Details/5
        public ActionResult Details(uint id)
        {
            var venda = _vendaService.GetById(id);
            var vendaModel = _mapper.Map<VendaViewModel>(venda);
            return View(vendaModel);
        }

        // GET: VendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaViewModel VendaModel)
        {
            if (ModelState.IsValid)
            {
                var CriaVenda = _mapper.Map<Venda>(VendaModel);
                _vendaService.Create(CriaVenda);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VendaController/Edit/5
        public ActionResult Edit(uint id)
        {
            var Venda = _vendaService.GetById(id); 
            var VendaViewModel = _mapper.Map<VendaViewModel>(Venda);
            return View(VendaViewModel);
        }

        // POST: VendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VendaViewModel VendaModel)
        {
            if (ModelState.IsValid)
            {
                var EditaVenda = _mapper.Map<Venda>(VendaModel);
                _vendaService.Update(EditaVenda);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VendaController/Delete/5
        public ActionResult Delete(uint id)
        {
            var Venda = _vendaService.GetById(id);
            var VendaViewModel = _mapper.Map<VendaViewModel>(Venda);
            return View(VendaViewModel);
        }

        // POST: VendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, VendaViewModel VendaModel)
        {
            _vendaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
