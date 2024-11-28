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
                HttpContext.Session.SetString ("email", email);
                HttpContext.Session.SetInt32 ("id", usuario.Id);
                HttpContext.Session.SetString("nombre", usuario.Nombre);
                HttpContext.Session.SetString ("rol", usuario.Rol());

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

        [HttpGet]
        public IActionResult Registro()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Admin")
            {

            }
            return View();
        }


        [HttpPost]
        public IActionResult Registro(string nombre, string apellido, string email, string contrasena)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede ser vacio");
                if (string.IsNullOrEmpty(apellido)) throw new Exception("El apellido no puede ser vacio");
                if (string.IsNullOrEmpty(email)) throw new Exception("El email no puede ser vacio");
                if (contrasena.Length < 8) throw new Exception("la clave debe tener minimo 8 digitos");

                Usuario c = new Cliente (nombre, apellido, email, contrasena);
                miSistema.AltaUsuario(c);
                ViewBag.Exito = $"Usuario cliente {nombre} dada de alta con exito";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Nombre = nombre;
                ViewBag.Apellido = apellido;
                ViewBag.email = email;
                ViewBag.Contrasena = contrasena;
            }
            return View();
        }
    }
}

