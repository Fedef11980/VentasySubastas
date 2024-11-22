using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionesController : Controller
    {
        private Sistema miSistema = Sistema.Instancia; 

        public IActionResult ListarPublicaciones()
        {
            ViewBag.ListadoPublicaciones = miSistema.Publicaciones;
            return View();
        }
              
        public IActionResult BuscarPorPublicacion(string publicacion)
        {
            try
            {
                if (string.IsNullOrEmpty(publicacion)) throw new Exception ("Debe ingresar un tipo de publicacion");
                ViewBag.ListadoPublicaciones = miSistema.ObtenerPublicacionPorTipo(publicacion); 
            }
            catch (Exception ex)  
            {
                ViewBag.Error=ex.Message;
            }

            return View("ListarPublicaciones");
        }

        
    }
}
