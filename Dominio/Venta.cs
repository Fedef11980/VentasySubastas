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


    }
}
