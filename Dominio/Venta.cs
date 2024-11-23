using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta : Publicacion
    {
        private bool _ofertaRelampago = false;      

        public Venta (string nombre, DateTime fechaPublic, DateTime fechaFinaliz, Estado estado, bool ofertaRelampago):
            base(nombre, fechaPublic, fechaFinaliz,estado)
        {
            _ofertaRelampago = ofertaRelampago;
        }

        public override double CalcularPrecio()
        {
            double precio = 0;
            foreach (Articulo a in _articulos )
            {
                 precio += a.Precio; 
            }
            if (_ofertaRelampago) precio *= 0.8;
            return precio;
        }

        public override string TipoDePublicacíon()
        {
            return "Venta";
        }
    }
}
