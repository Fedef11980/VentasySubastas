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
        private decimal _precioFinal;
        

        public Subasta (string nombre, DateTime fechaPublic, DateTime fechaFinaliz, Estado estado, double precioFinal):
             base(nombre, fechaPublic, fechaFinaliz, estado)
        {
            
        }

        public override void Validar()
        {
          base.Validar();
        }

        //propierty de precio final?

        public override double CalcularPrecio()
        {
            throw new NotImplementedException();
        }

    }
}
