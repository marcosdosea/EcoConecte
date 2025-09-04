using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EcoConecteWeb.Controllers
{
    public class AdmRootController : Controller
    {
        private readonly ILogger<SuporteController> _logger;

        public AdmRootController(ILogger<SuporteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home()
        {
            return View();
        }
    }
} 