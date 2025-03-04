using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service;
using EcoConecteWeb.Areas.Identity.Data;

namespace EcoConecteWeb.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly EcoConecteContext _contextEcoconecte;
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(
            IPessoaService pessoaService,
            IMapper mapper,
            UserManager<UsuarioIdentity> userManager,
            EcoConecteContext contextEcoconecte,
            ILogger<PessoaController> logger)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
            _userManager = userManager;
            _contextEcoconecte = contextEcoconecte;
            _logger = logger;
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            var listaPessoas = _pessoaService.GetAll();
            var listaPessoasModel = _mapper.Map<List<PessoaViewModel>>(listaPessoas);
            return View(listaPessoasModel);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(uint id)
        {
            var pessoa = _pessoaService.Get(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                _pessoaService.Create(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaModel);
        }

        // GET: Pessoa/Edit/5
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

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return RedirectToAction(nameof(Index));
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(uint id)
        {
            var pessoa = _pessoaService.Get(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var pessoa = _pessoaService.Get(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var usuario = await _userManager.Users.FirstOrDefaultAsync(u => u.PessoaId == id);

            using var transaction = await _contextEcoconecte.Database.BeginTransactionAsync();
            try
            {
                // Excluir a pessoa do banco EcoConecte
                _pessoaService.Delete(id);
                await _contextEcoconecte.SaveChangesAsync();

                // Se houver um usuário no Identity, excluir também
                if (usuario != null)
                {
                    var result = await _userManager.DeleteAsync(usuario);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Erro ao excluir o usuário no Identity.");
                    }
                }

                await transaction.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Erro ao excluir Pessoa e Usuário Identity.");
                ModelState.AddModelError(string.Empty, "Erro ao excluir o cadastro. Tente novamente.");
                return View(pessoa);
            }
        }
    }
}
