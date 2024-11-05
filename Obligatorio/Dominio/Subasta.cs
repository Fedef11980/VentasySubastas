using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion 
    {

        private List<Oferta> _ofertas = new List<Oferta>();
        

        public Subasta (string nombre, DateTime fechaPublic, DateTime fechaFinaliz, Estado estado):
             base(nombre,fechaPublic, fechaFinaliz,estado)
        {
            
        }

        public void Validar()
        {
            if (_precioFinal > 0) throw new Exception("El precio no puede ser cero");
            base.Validar();
        }
    }
}
