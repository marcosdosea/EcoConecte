using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class ColetaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly IColetaService _coletaService;
        private readonly IMapper _mapper;

        public ColetaController(IColetaService coletaService, IMapper mapper, IPessoaService pessoaService)
        {
            this._coletaService = coletaService;
            this._mapper = mapper;
            _pessoaService = pessoaService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarPorCep(string cep)
        {
            // Tratando cep para remover o hifen
            var cepLimpo = cep.Replace("-", "").Trim();

            if (string.IsNullOrEmpty(cepLimpo))
            {
                ModelState.AddModelError("Cep", "O CEP é obrigatório.");
                return View("Index");
            }
            var coletas = _coletaService.GetByCep(cepLimpo);
            if (coletas == null || !coletas.Any())
            {
                ModelState.AddModelError("Cep", "Nenhuma coleta encontrada.");
                return View("BuscarPorCep");
            }


            if (_mapper == null)
            {
                ModelState.AddModelError("", "Erro interno");
                return View("Index");
            }

            var coletaViewModels = _mapper.Map<IEnumerable<ColetaViewModel>>(coletas);
            return View("BuscarPorCep", coletaViewModels);
        }

        [HttpGet]
        public IActionResult BuscarPorCep()
        {
            return View("Index");
        }


        // GET: Coleta_Controller
        public ActionResult Index()
        {
            var listaColeta = _coletaService.GetAll();
            var listaColetaModel = _mapper.Map<IEnumerable<ColetaViewModel>>(listaColeta);
            return View(listaColetaModel);
        }


        public ActionResult AgendamentoCoop(uint id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Buscar a pessoa pelo ID
            var pessoa = _pessoaService.Get(id);
           
            // buscar as coletas da cooperativa desse cooperado
            var listaColeta = _coletaService.GetByCooperativaId(pessoa.IdCooperativa.Value);
            var listaColetaModel = _mapper.Map<IEnumerable<ColetaViewModel>>(listaColeta);

            ViewData["PessoaId"] = userId; // Mantendo o ID do usuário na View
            return View(listaColetaModel);
        }





        // GET: Coleta_Controller/Details/5
        public ActionResult Details(uint id)
        {
            var coleta = _coletaService.GetById(id);
            var coletaViewModel = _mapper.Map<ColetaViewModel>(coleta);
            return View(coletaViewModel);
        }

        // GET: Coleta_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coleta_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ColetaViewModel coletaModel)
        {
            if (ModelState.IsValid)
            {
                var coleta = _mapper.Map<Coleta>(coletaModel);
                _coletaService.Create(coleta);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Coleta_Controller/Edit/5
        public ActionResult Edit(uint id)
        {
            var coleta = _coletaService.GetById(id);
            var coletaModel = _mapper.Map<ColetaViewModel>(coleta);
            return View(coletaModel);
        }

        // POST: Coleta_Controller/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ColetaViewModel coletaModel)
        {
            if (ModelState.IsValid)
            {
                var coleta = _mapper.Map<Coleta>(coletaModel);
                _coletaService.Edit(coleta);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Coleta_Controller/Delete/5
        public ActionResult Delete(uint id)
        {
            var coleta = _coletaService.GetById(id);
            var coletaModel = _mapper.Map<ColetaViewModel>(coleta);
            return View(coletaModel);
        }

        // POST: Coleta_Controller/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, ColetaViewModel coletaModel)
        {
            _coletaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}