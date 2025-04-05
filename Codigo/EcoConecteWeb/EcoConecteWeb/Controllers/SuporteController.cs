using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EcoConecteWeb.Controllers
{
    public class SuporteController : Controller
    {
        private readonly ILogger<SuporteController> _logger;

        public SuporteController(ILogger<SuporteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
} 