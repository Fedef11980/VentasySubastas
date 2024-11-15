using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        Sistema miSistema= new Sistema();

        public IActionResult Index()
        {
            return View();
        }                        
    }
}
