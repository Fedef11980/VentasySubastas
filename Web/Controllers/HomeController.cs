using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
       private Sistema miSistema = Sistema.Instancia;

        public IActionResult Index()
        {
            return View();
        }                        
    }
}
