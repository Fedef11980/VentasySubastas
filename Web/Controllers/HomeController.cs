using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
       private Sistema miSistema = Sistema.Instancia;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        Sistema miSistema = new Sistema();

        public IActionResult Index()
        {
            return View();
        }                        
    }
}
