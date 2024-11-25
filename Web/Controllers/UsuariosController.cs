using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {

        Sistema miSistema = Sistema.Instancia;
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {

            try
            {
                if (string.IsNullOrEmpty(email)) throw new Exception("Debe ingresar un email");
                if (string.IsNullOrEmpty(pass)) throw new Exception("Debe ingresar una contraseña");
                Usuario usuario = miSistema.Login(email, pass);
                if (usuario == null) throw new Exception("Email o contraseña incorrectas");

                ViewBag.Exito = $"Usuario Logueado{email}";
                //Declaracion de variables de session
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("rol", usuario.Rol());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

