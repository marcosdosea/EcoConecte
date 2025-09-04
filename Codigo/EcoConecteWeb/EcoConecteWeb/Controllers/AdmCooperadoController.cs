using AutoMapper;
using Core;
using Core.Service;
using EcoConecteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace EcoConecteWeb.Controllers
{
    public class AdmCooperadoController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly IAgendamentoService _agendamentoService;
        private readonly IMapper _mapper;


        public AdmCooperadoController(IPessoaService pessoaService, IAgendamentoService agendamentoService, IMapper mapper)
        {
            _agendamentoService = agendamentoService;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: Cooperado_Controller
        public ActionResult Home(uint id)
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
    }
}